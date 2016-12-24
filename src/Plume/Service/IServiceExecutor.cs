using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Plume.Models.Request;

namespace Plume.Service
{
    public interface IServiceExecutor<T, R>
    {
        ObjectResult call(BaseRequest<T> request, Func<BaseRequest<T>, R> callable);
    }
}
