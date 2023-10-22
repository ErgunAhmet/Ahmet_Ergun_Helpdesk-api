using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk_api.Services.Model
{
    public class ServiceResult<T> : ServiceResult
    {
        public ServiceResult()
        {

        }
        public ServiceResult(T result)
        {
            Result = result;
        }
        public T? Result { get; set; }
    }
}
