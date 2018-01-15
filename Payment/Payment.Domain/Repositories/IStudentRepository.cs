using Payment.Domain.Entities;

namespace Payment.Domain.Repositories
{
    public interface IStudentRepository
    {
        bool DocumentExistis(string student);

        bool EmailExists(string email);

        void CreateSubscription(Student student);
    }
}
