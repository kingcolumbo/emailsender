using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailSender.Models
{
    public class EmailMessage
    {
        public string to { get; set; }
        public string cc { get; set; }
        public string bcc { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
    }
}
