using cms_submission.Contexts;
using cms_submission.Models.Entities;

namespace cms_submission.Services;

public class ContactRequestService
{

    private readonly DataContext _context;

    public ContactRequestService(DataContext context)
    {
        _context = context;
    }

    public async Task<ContactEntity> Create(ContactEntity contactEntity)
    {
        _context.ContactRequests.Add(contactEntity);
        await _context.SaveChangesAsync();
        return contactEntity;
    }

   

    
}
