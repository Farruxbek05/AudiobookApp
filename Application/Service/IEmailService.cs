﻿namespace Application.Service;

public interface IEmailService
{
    Task<bool> SendEmailAsync(string email, string subject);
}
