using ContactSystem.Domain.Entities;
using System.Linq;

namespace ContactSystem.Application.Interfaces;

public interface IContactRepository
{
    Task<long> InsertContactAsync(Contact contact);
    Task<Contact> SelectContactByIdAsync(long id);
    Task DeleteContactAsync(Contact contact);
    IQueryable<Contact> SelectAll();
}
