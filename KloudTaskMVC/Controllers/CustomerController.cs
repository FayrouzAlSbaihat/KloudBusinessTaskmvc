using KloudTaskMVC.data;
using KloudTaskMVC.Models;
using KloudTaskMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.Extensions.Hosting;
using System.Net;
using System.Net.Mail;
using System.Net.Security;

namespace KloudTaskMVC.Controllers
{
    public class CustomerController : Controller
    {
    SystemContext context;
        ICustomerService customerService;
        public CustomerController(SystemContext _context, ICustomerService _customerService)
        {
            context=_context;
            customerService = _customerService;
        }

        public IActionResult Customer()
        {
            return View();
        }


        public IActionResult Save(UsersDTO usersDTO)
        {
            customerService.saveCustomer(usersDTO);

            return Json("Success");
        }

        public IActionResult LoadOffers()
        {
           List<OffersDTO> offers= customerService.LoadAllOffers();
            return Json(offers);

        }


        public IActionResult LoadTimeInterested()
        {
           List<OrderTimeDTO> orderTimes= customerService.LoadATime();
            return Json(orderTimes);
        }

        public IActionResult SendEmail(EmailDataDTO emailData)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("fairouzal.sbihat@gmail.com");
                mail.To.Add(emailData.email);
                mail.Subject = "Test";
                mail.Body = emailData.name + Environment.NewLine + emailData.phone.ToString() + Environment.NewLine + emailData.offer + Environment.NewLine + emailData.orderTime;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("fairouzal.sbihat@gmail.com", "zuuhfszcydiczofi");
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Send(mail);


                return Json("");
            }
            catch(Exception ex)
            {
                return Json("");
            }
        }
    }
}
