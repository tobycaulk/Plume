using Plume.Models.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plume.Models.Response
{
    public class ErrorResponse
    {
        public PlumeException Error { get; set; }
    }
}
