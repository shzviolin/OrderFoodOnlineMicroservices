﻿using Microsoft.EntityFrameworkCore;
using OrderFoodOnlineMicroservices.Services.EmailAPI.Data;
using OrderFoodOnlineMicroservices.Services.EmailAPI.Dto;
using OrderFoodOnlineMicroservices.Services.EmailAPI.Models;
using OrderFoodOnlineMicroservices.Services.EmailAPI.Service.IService;
using System.Text;

namespace OrderFoodOnlineMicroservices.Services.EmailAPI.Service
{
    public class EmailService : IEmailService
    {
        private DbContextOptions<AppDbContext> _dbOptions;

        public EmailService(DbContextOptions<AppDbContext> dbOptions)
        {
            _dbOptions = dbOptions;
        }

        public async Task EmailCartAndLog(CartDto cartDto)
        {
            StringBuilder message = new();

            message.AppendLine("<br/>Cart Email Requested ");
            message.AppendLine($"<br/>Total {cartDto.CartHeader.CartTotal}");
            message.Append("<br/>");
            message.Append("<ul>");
            foreach (var item in cartDto.CartDetails)
            {
                message.Append("<li>");
                message.Append(item.Product.Name + " x " + item.Count);
                message.Append("</li>");
            }
            message.Append("</ul>");

            await LogAndEmail(message.ToString(), cartDto.CartHeader.Email);
        }

        private async Task<bool> LogAndEmail(string message, string email)
        {
            try
            {
                EmailLogger emailLogger = new()
                {
                    Email = email,
                    EmailSent = DateTime.Now,
                    Message = message,
                };

                await using var _db = new AppDbContext(_dbOptions);
                await _db.EmailLoggers.AddAsync(emailLogger);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
