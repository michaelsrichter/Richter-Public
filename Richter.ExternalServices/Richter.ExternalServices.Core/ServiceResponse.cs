using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Richter.ExternalServices.Core
{
    public abstract class ServiceResponse
    {
        public string Result { get; set; }
        public string Message { get; set; }
        public string Error { get; set; }
        public bool Success { get; set; }
        public DateTime Created { get; set; }

        protected ServiceResponse()
        {
            Created = DateTime.Now;
        }
    }
}
