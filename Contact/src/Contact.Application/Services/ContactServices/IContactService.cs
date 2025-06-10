using ContactSystem.Application.Dtos.ContactDtos;

namespace ContactSystem.Application.Services.ContactServices;

public interface IContactService
{
    Task<long> PostAsync(ContactCreateDto contact);
    Task DeleteAsync(long contactId);
    Task<ContactDto> GetByIdAsync(long contactId);
    ICollection<ContactDto> GetAll();
    Task UpdateAsync(ContactDto contact);
}