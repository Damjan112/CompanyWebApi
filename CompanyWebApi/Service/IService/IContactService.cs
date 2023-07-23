using CompanyWebApi.Models;
using CompanyWebApi.Models.Dto;

namespace CompanyWebApi.Service.IService
{
    public interface IContactService
    {
        Task<List<ContactDto>> GetAllContactsWithIdAndName();
        Task<List<Contact>> GetAllContacts();
        Task<Contact> GetContactById(int contactId);
        Task<Contact> CreateContact(Contact contact);
        Task<Contact> UpdateContact(int contactId, Contact contact);
        Task<bool> DeleteContact(int contactId);
        Task<List<Contact>> FilterContacts(int? countryId, int? companyId);
       
    }
}
