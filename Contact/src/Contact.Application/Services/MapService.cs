using ContactSystem.Application.Dtos.ContactDtos;
using ContactSystem.Domain.Entities;


public static class MapService
{
    public static Contact ConvertToContact(ContactCreateDto contactDto)
    {
        return new Contact
        {
            Name = contactDto.Name,
            Address = contactDto.Address,
            Phone = contactDto.Phone,
            Email = contactDto.Email,

        };
    }
    public static ContactDto ConvertToContactDto(Contact contact)
    {
        return new ContactDto
        {
            Name = contact.Name,
            Address = contact.Address,
            Phone = contact.Phone,
            Email = contact.Email,
            ContactId = contact.ContactId,

        };
    }
}

