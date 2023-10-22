using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk_api.Services.Model.Extensions
{
    public static class ServiceResultExtensions
    {
        public static ServiceResult<T> NotFound<T>(this ServiceResult<T> result, string entity)
        {
            result.AddNotFound(entity);
            return result;
        }

        public static ServiceResult NotFound(this ServiceResult result, string entity)
        {
            result.AddNotFound(entity);
            return result;
        }

        private static void AddNotFound(this ServiceResult result, string entity)
        {
            result.Messages.Add(new ServiceMessage
            {
                Code = "NotFound",
                Type = ServiceMessageType.Error,
                Title = $"Could not find {entity}.",
                Description = $"We were unable to find the requested {entity}."
            });
        }
    }
}
