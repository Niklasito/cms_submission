using cms_submission.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace cms_submission.Models;

public class ContactForm
{
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    public string Message { get; set; } = null!;

    public string? RedirectUrl { get; set; } = "/";



    public static implicit operator ContactEntity(ContactForm contactForm)
    {
        var contactEntity = new ContactEntity
        {
            Name = contactForm.Name,
            Email = contactForm.Email,
            Message = contactForm.Message
        };
            return contactEntity;
        
    }

    

}


