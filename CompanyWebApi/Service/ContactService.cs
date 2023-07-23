using CompanyWebApi.Context;
using CompanyWebApi.Models;
using CompanyWebApi.Models.Dto;
using CompanyWebApi.Service.IService;
using Microsoft.EntityFrameworkCore;

namespace CompanyWebApi.Service
{
    public class ContactService : IContactService
    {
        private readonly ApiContext _dbContext;

        public ContactService(ApiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Contact>> GetAllContacts()
        {
            return await _dbContext.contacts
                .Include(c => c.Company)
                .Include(c => c.Country)
                .ToListAsync();
        }
        public async Task<List<ContactDto>> GetAllContactsWithIdAndName()
        {
            return await _dbContext.contacts
                .Select(c => new ContactDto
                {
                    ContactId = c.ContactId,
                    ContactName = c.ContactName
                })
                .ToListAsync();
        }

        public async Task<Contact> GetContactById(int contactId)
        {
            return await _dbContext.contacts
                .Include(c => c.Company)
                .Include(c => c.Country)
                .FirstOrDefaultAsync(c => c.ContactId == contactId);
        }

        public async Task<Contact> CreateContact(Contact contact)
        {
            var existingCompany = await _dbContext.companies.FindAsync(contact.CompanyId);
            var existingCountry = await _dbContext.countries.FindAsync(contact.CountryId);

            if (existingCompany == null || existingCountry == null)
            {
                _dbContext.contacts.Add(contact);
            }

            else
            {
                contact.Company = existingCompany;
                contact.Country = existingCountry;
            }

            _dbContext.contacts.Add(contact);
            await _dbContext.SaveChangesAsync();
            return contact;
        }

        public async Task<Contact> UpdateContact(int contactId, Contact updatedContact)
        {
            var existingContact = await _dbContext.contacts.FindAsync(contactId);

            if (existingContact == null)
            {
                return null;
            }

            existingContact.ContactName = updatedContact.ContactName;
            existingContact.CompanyId = updatedContact.CompanyId;
            existingContact.CountryId = updatedContact.CountryId;

            await _dbContext.SaveChangesAsync();

            return existingContact;
        }

        public async Task<bool> DeleteContact(int contactId)
        {
            var existingContact = await _dbContext.contacts.FindAsync(contactId);

            if (existingContact == null)
            {
                return false;
            }

            _dbContext.contacts.Remove(existingContact);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        public async Task<List<Contact>> FilterContacts(int? companyId, int? countryId)
        {
            var query = _dbContext.contacts.AsQueryable();

            if (companyId.HasValue)
            {
                query = query.Where(c => c.CompanyId == companyId);
            }

            if (countryId.HasValue)
            {
                query = query.Where(c => c.CountryId == countryId);
            }

            return await query
                .Include(c => c.Company)
                .Include(c => c.Country)
                .ToListAsync();
        }
    }
}
