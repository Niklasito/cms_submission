using cms_submission.Models;
using cms_submission.Models.Entities;
using cms_submission.Services;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

namespace cms_submission.Controllers
{
    public class NewsLetterController : SurfaceController
    {
        private readonly NewsLetterService _newsLetterService;
        public NewsLetterController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider, NewsLetterService newsLetterService) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _newsLetterService = newsLetterService;
        }


        [HttpPost]
        public async Task<IActionResult> Index(NewsLetterForm newsLetterForm)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }
            else 
            {
                NewsLetterEntity newsLetterEntity = newsLetterForm;

                await _newsLetterService.Create(newsLetterEntity);

                using var mail = new MailService("no-reply@crito.com", "smtp.crito.com", 587, "contactform@crito.com", "BytMig123!");

                await mail.SendAsync(newsLetterForm.Email, "Your request was recieved", "Congratulations! You have successfully subscribed to our awesome newsletter!").ConfigureAwait(false);

                return LocalRedirect(newsLetterForm.RedirectUrl ?? "/");

            }
        }
    }
}
