using ABSA.PhoneBookAPI.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABSA.PhoneBookAPI.Services
{
    public interface IContactService
    {
        Task<List<Contact>> GetAllContactsAsync();
        Task<Contact> AddContactAsync(Contact contact);
        Task<Contact> UpdateContactAsync(Contact contact);
        Task<Contact> DeleteContactByIdAsync(int id);
    }
}