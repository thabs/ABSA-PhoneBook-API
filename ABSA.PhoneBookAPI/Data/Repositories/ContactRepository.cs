using ABSA.PhoneBookAPI.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABSA.PhoneBookAPI.Data.Repositories
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(PhoneBookContext phoneBookContext) : base(phoneBookContext)
        {    
        }
    }
}