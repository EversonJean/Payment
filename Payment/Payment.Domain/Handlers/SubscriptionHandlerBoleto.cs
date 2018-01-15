using Flunt.Notifications;
using Payment.Domain.Commands;
using Payment.Domain.Entities;
using Payment.Domain.Enums;
using Payment.Domain.Repositories;
using Payment.Domain.Services;
using Payment.Domain.ValueObjects;
using Payment.Shared.Commands;
using Payment.Shared.Handlers;
using System;

namespace Payment.Domain.Handlers
{
    public class SubscriptionHandlerBoleto : Notifiable, IHandler<CreateBoletoSubscriptionCommand>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IEmailService _emailService;

        public SubscriptionHandlerBoleto(IStudentRepository studentRepository, IEmailService emailService)
        {
            _studentRepository = studentRepository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            //Fail Fast Validation

            if (!command.Validate())
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possivel realizar sua assinatura.");
            }

            if (_studentRepository.DocumentExistis(command.DocumentNumber))
                AddNotification("Document", "CPF já em uso.");

            if (_studentRepository.EmailExists(command.Email))
                AddNotification("Email", "E-mail já em uso.");

            if (command.Valid)
            {
                var name = new Name(command.FirstName, command.LastName);
                var document = new Document(command.DocumentNumber, EDocumentType.CPF);
                var email = new Email(command.Email);
                var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);

                var student = new Student(name, document, email);
                var subscription = new Subscription(DateTime.Now.AddMonths(1));
                var payment = new BoletoPayment(
                    command.BarCode,
                    command.BoletoNumber,
                    command.PaidDate,
                    command.ExpireDate,
                    command.Total,
                    command.TotalPaid,
                    address,
                    new Document(command.PayerDocument, command.PayerDocumentType),
                    command.Payer,
                    email
               );

                //Relacionamentos
                subscription.AddPayment(payment);
                student.AddSubscription(subscription);

                AddNotifications(name,document, email,address, student, subscription, payment);

                if(Valid)
                {
                    _studentRepository.CreateSubscription(student);
                    _emailService.Send(student.Name.ToString(), student.Email.Address, "Bem Vindo", "Assinatura criada!");
                    return new CommandResult(true, "Assinatura realizada com sucesso");
                }

            }
            return new CommandResult(false, "Não foi possivel realizar sua assinatura.");

        }
    }
}
