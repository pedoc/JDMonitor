using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDMonitor.Entity
{
    public class Log:EntityBase
    {
        public string Message { get; set; }
        public string Tag { get; set; }
    }
}
