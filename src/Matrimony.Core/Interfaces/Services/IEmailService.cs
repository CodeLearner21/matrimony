using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Core.Interfaces.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync();
    }
}
