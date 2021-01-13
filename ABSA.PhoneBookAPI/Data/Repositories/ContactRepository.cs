using ABSA.PhoneBookAPI.Data.Models;

namespace ABSA.PhoneBookAPI.Data.Repositories
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(PhoneBookContext phoneBookContext) : base(phoneBookContext)
        {    
        }
    }
}