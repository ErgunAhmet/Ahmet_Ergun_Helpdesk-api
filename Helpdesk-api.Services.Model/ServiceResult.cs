using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk_api.Services.Model
{
    public class ServiceResult
    {
        public IList<ServiceMessage> Messages { get; set; } = new List<ServiceMessage>();

        public bool IsSuccess => Messages.All(m => m.Type != ServiceMessageType.Error);
    }
}
