using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk_api.Services.Model
{
    public class ServiceMessage
    {
        public required string Code { get; set; }
        public ServiceMessageType Type { get; set; }
        public string? PropertyName { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
    }
}
