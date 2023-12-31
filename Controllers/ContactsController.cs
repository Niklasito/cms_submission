﻿using cms_submission.Contexts;
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
    public class ContactsController : SurfaceController
    {

        private readonly ContactRequestService _contactRequestService;

        public ContactsController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider, ContactRequestService contactRequestService) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _contactRequestService = contactRequestService;
        }


        [HttpPost]
        public async Task<IActionResult> Index(ContactForm contactForm)
        {

            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            else {

            ContactEntity contactEntity = contactForm;

            await _contactRequestService.Create(contactEntity);

            using var mail = new MailService("no-reply@crito.com", "smtp.crito.com", 587, "contactform@crito.com", "BytMig123!");
            
            await mail.SendAsync(contactForm.Email, "Your request was recieved", "Hello, your request has been recieved and we will contact you shortly").ConfigureAwait(false);

            await mail.SendAsync("umbraco@crito.com" , $"{contactForm.Name} sent a contact request.", contactForm.Message).ConfigureAwait(false);

            return LocalRedirect(contactForm.RedirectUrl ?? "/");

            }

  

        }
        
    }
}
