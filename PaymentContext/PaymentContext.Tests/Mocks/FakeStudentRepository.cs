using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;

namespace PaymentContext.Tests.Mocks
{
    public class FakeStudentRepository : IStudentRepository
    {
        public void CreateSubscrption(Student student)
        {

        }

        public bool DocumentExists(string document)
        {
            if (document == "99999")
                return true;
            return false;
        }

        public bool EmailExists(string email)
        {
            if (email == "teste@email.com")
                return true;
            return false;
        }
    }
}