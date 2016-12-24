using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plume.Models.Request
{
    public class BaseRequest<T>
    {
        public T Payload { get; set; }
    }
}
