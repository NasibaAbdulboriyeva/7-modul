
using ContactSystem.Application.Interfaces;
using ContactSystem.Domain.Entities;
using Moq;
using Xunit;

namespace ContactSystem.Tests.XUnitTests;

public class ContactTest
{
    private readonly Mock<IContactRepository> _mockRepository;
    private readonly ContactService _contactService;
    public ContactTest()
    {
        _mockRepository = new Mock<IContactRepository>();
        _contactService = new ContactService(_mockRepository.Object);
    }

    [Fact]
    public async Task DeleteContactAsync_RemovesContact()
    {
        // Arrange
        var contactId = 1L;
        var contact = new Contact { ContactId = contactId };
        _mockRepository.Setup(x => x.SelectByIdAsync(contactId));

        // Act
        await _contactService.DeleteAsync(contactId);

        // Assert
        _mockRepository.Verify(x => x.DeleteAsync(contact), Times.Once);
    }
    [Fact]
    public async Task DeleteContactAsync_ContactNotFound_ThrowException()
    {
        //Arrange 
        var contactId = 1L;
        _mockRepository.Setup(x => x.SelectByIdAsync(contactId)).ReturnsAsync((Contact)null);
        //Act & ASsert
        await Assert.ThrowsAsync<Exception>(()=>_contactService.DeleteAsync(contactId));

    }
}
