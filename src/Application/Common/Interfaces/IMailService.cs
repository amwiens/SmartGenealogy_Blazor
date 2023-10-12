using FluentEmail.Core.Models;

namespace SmartGenealogy.Application.Common.Interfaces;

public interface IMailService
{
    Task<SendResponse> SendAsync(string to, string subject, string body);

    Task<SendResponse> SendAsync(string to, string subject, string template, object model);
}