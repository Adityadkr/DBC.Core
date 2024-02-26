using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBC.Core.Shared.models
{
    public class ResponseModel<T>
    {
        public int code { get; set; }
        public string message { get; set; }

        public string status { get; set; }
        public T data { get; set; }
    }
}
