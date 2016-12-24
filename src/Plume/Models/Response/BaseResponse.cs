using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plume.Models.Response
{
    public class BaseResponse<T>
    {
        public T Payload { get; set; }
    }
}
