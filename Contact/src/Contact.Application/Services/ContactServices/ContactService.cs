using ContactSystem.Application.Dtos.ContactDtos;
using ContactSystem.Application.Interfaces;
using ContactSystem.Application.Services.ContactServices;
public class ContactService : IContactService
{
    private readonly IContactRepository _contactRepository;
    public ContactService(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }
    public async Task DeleteAsync(long contactId)
    {
        var contact = await _contactRepository.SelectByIdAsync(contactId);
        if (contact == null)
        {
            throw new Exception("contact not found ");
        }
        await _contactRepository.DeleteAsync(contact);
    }

    public ICollection<ContactDto> GetAll()
    {
        var query = _contactRepository.SelectAll();
        var contacts = query.ToList();
        var contactDtos = contacts.Select(c => MapService.ConvertToContactDto(c)).ToList();
        return contactDtos;
    }

    public async Task<ContactDto> GetByIdAsync(long contactId)
    {
        var contact = await _contactRepository.SelectByIdAsync(contactId);
        if (contact == null)
        {
            throw new Exception("contact is not found");
        }
        return MapService.ConvertToContactDto(contact);
    }

    public async Task<long> PostAsync(ContactCreateDto contactCreateDto)
    {
        var contact = MapService.ConvertToContact(contactCreateDto);
        var contactId = await _contactRepository.InsertAsync(contact);
        return contactId;
    }

    public async Task UpdateAsync(ContactDto contactDto)
    {
        var contact = await _contactRepository.SelectByIdAsync(contactDto.ContactId);
        if (contact == null)
        {
            throw new Exception($"Contact not fount to update with id {contactDto.ContactId}");
        }

        contact.Phone = contactDto.Phone;
        contact.Email = contactDto.Email;
        contact.Address = contactDto.Address;
        contact.Name = contactDto.Name;

        await _contactRepository.UpdateAsync(contact);
    }
}

