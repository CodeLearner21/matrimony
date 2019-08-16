using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Infrastructure.Email
{
    public class EmailConfig
    {
        public string ServerName { get; set; }
        public int ServerPort { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string NoReplyAddress { get; set; }
    }
}
