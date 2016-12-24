using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Plume.Models.Request;
using Plume.Models.Response;
using Plume.Models.Error;

namespace Plume.Service
{
    public class ServiceExecutor<T, R> : IServiceExecutor<T, R>
    {
        public ObjectResult call(BaseRequest<T> request, Func<BaseRequest<T>, R> callable)
        {
            BaseResponse<R> response = new BaseResponse<R>();
            try
            {
                R payload = callable(request);
                if (payload != null)
                {
                    response.Payload = payload;
                }
            } 
            catch(Exception e)
            {
                PlumeException errorResponseException = e is PlumeException ? (PlumeException) e : PlumeException.UnhandledError;
                BaseResponse<ErrorResponse> errorResponse = new BaseResponse<ErrorResponse>();
                errorResponse.Payload = new ErrorResponse
                {
                    Error = errorResponseException
                };

                return new ObjectResult(errorResponse);
            }


            return new ObjectResult(response);
        }
    }
}
