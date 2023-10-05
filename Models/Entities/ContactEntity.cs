using MessagePack.Formatters;
using Umbraco.Cms.Infrastructure.Examine;

namespace cms_submission.Models.Entities;

public class ContactEntity
{
    public int Id { get; set; }

    public Guid ContactUmbracoKey { get; set; }
    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Message { get; set; } = null!;

}
