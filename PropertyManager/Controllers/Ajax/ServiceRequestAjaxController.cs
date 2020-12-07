using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MimeKit;
using PropertyManager.Models.Property;
using PropertyManager.Services;
using PropertyManager.Services.Property;

namespace PropertyManager.Controllers.Ajax
{
    [Authorize]
    public class ServiceRequestAjaxController : Controller
    {
        private readonly IMaintenanceService _maintenanceService;
        private readonly IPropertyService _propertyService;
        private readonly IServiceProviderService _serviceProviderService;
        public ServiceRequestAjaxController(IMaintenanceService maintenanceService, IPropertyService propertyService, IServiceProviderService serviceProviderService)
        {
            _maintenanceService = maintenanceService;
            _propertyService = propertyService;
            _serviceProviderService = serviceProviderService;
            dfdsf
        }

       
        public async Task SendServiceRequestEmail(string companyName, string companyEmail, string ccEmail, string maintenanceCategory, int propertyId, string subject, string message)
        {
           if(!String.IsNullOrEmpty(companyEmail) && !String.IsNullOrEmpty(ccEmail) && !String.IsNullOrEmpty(subject) && !String.IsNullOrEmpty(companyName) && !String.IsNullOrEmpty(message))
            {
                var property = await _propertyService.GetProperty(propertyId);
                if(property.UserId == User.Identity.Name)
                {
                    var routineRequest = new MaintenanceRequest();
                    routineRequest.CompanyEmail = companyEmail;
                    routineRequest.SubmitterEmail = User.Identity.Name;
                    routineRequest.CompanyUsed = companyName;
                    routineRequest.FullDescription = message;
                    routineRequest.MaintenanceType = maintenanceCategory;
                    routineRequest.PropertyOwnerId = User.Identity.Name;
                    routineRequest.PropertyId = propertyId;
                    routineRequest.Status = "Open";
                    routineRequest.RequestSentDate = DateTime.Now;
                    routineRequest.ResponseCode = Guid.NewGuid();
                    await _maintenanceService.AddRoutineMaintenanceRequest(routineRequest);
                    var mailMessage = new MimeMessage();
                    mailMessage.From.Add(new MailboxAddress("MyLandlord", "mylandlordalerts@gmail.com"));
                    mailMessage.To.Add(new MailboxAddress(companyName, companyEmail));
                    mailMessage.Subject = subject;
                    var linkString = "<a href='https://localhost:5001/RespondToServiceRequest?responseCode=" + routineRequest.ResponseCode + "'>View Service Request</>";
                    mailMessage.Body = new TextPart("html") { Text= "<div>" + message + "</div>" + linkString };
                  

                    mailMessage.Cc.Add(new MailboxAddress(ccEmail, ccEmail));
                    using (var smtpClient = new SmtpClient())
                    {
                        smtpClient.Connect("smtp.gmail.com", 465, true);
                        smtpClient.Authenticate("mylandlordalerts@gmail.com", "Joseph0521$");
                        await smtpClient.SendAsync(mailMessage);
                        smtpClient.Disconnect(true);
                    }

                }
                // trying to access property that's not theirs
                else
                {
                    throw new Exception("Error. You are attempting to access resources that you do not have permission to view.");
                }
               
               
                
            }
        }

        public async Task<ActionResult> LoadServiceProvders(int propertyId)
        {
            var property = await _propertyService.GetProperty(propertyId);
            if (property.UserId == User.Identity.Name)
            {
                var providers = _serviceProviderService.GetServiceProvidersByProperty(propertyId);
                return Ok(providers);
            }
            else
            {
                throw new Exception("Not authorized to access resource.");
            }
        }
        
    }

}