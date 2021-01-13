using ABSA.PhoneBookAPI.Data.Models;
using ABSA.PhoneBookAPI.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABSA.PhoneBookAPI.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<List<Contact>> GetAllContactsAsync()
        {
            return await _contactRepository.GetAll();
        }
        
        public async Task<Contact> AddContactAsync(Contact contact)
        {
            return await _contactRepository.Add(contact);
        }

        public async Task<Contact> UpdateContactAsync(Contact contact)
        {
            return await _contactRepository.Update(contact);
        }

        public async Task<Contact> DeleteContactByIdAsync(int id)
        {
            return await _contactRepository.Delete(id);
        }
    }
}