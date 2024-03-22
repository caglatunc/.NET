using CleanArchitecture.Application.Features.Auth.Register;
using CleanArchitecture.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using FluentEmail.Core;
using FluentEmail.Core.Models;
using CleanArchitecture.Application.Utilities;

namespace CleanArchitecture.Presentation.Controllers;

public sealed class AuthController : ApiController
{
    private readonly IFluentEmail _fluentEmail;  
    public AuthController(IMediator mediator, IFluentEmail fluentEmail) : base(mediator)
    {
        _fluentEmail = fluentEmail;
    }

    [HttpPost]
    [Validation<RegisterCommandValidator>]
    public async Task<IActionResult> Register(RegisterCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);

        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    //public async  Task<IActionResult> SendTestEmail(CancellationToken cancellationToken)
    //{
    //    //using (MailMessage mail = new MailMessage())
    //    //{
    //    //    mail.From = new MailAddress("test@test.com");
    //    //    mail.To.Add("caglatuncsavas@gmail.com");
    //    //    mail.Subject = "Test Maili";
    //    //    mail.Body = "<h1>Test Mailidir</h1>";
    //    //    mail.IsBodyHtml = true;

    //    //    using (SmtpClient smtp = new SmtpClient("localhost", 2525))
    //    //    {
    //    //        smtp.UseDefaultCredentials = false;
    //    //        // smtp.Credentials = new NetworkCredential("","");
    //    //        smtp.EnableSsl = false;
    //    //        // smtp.Port = 25;
    //    //        await smtp.SendMailAsync(mail);
    //    //    }
    //    //}

      
    //    return Ok(new { Message = "Sending email completed successfully!" });
    //}
}