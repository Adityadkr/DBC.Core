using DBC.Core.Domain.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBC.Core.Domain.Entities.Workflow
{
    public  class PageEntity:CommonEntity
    {
        public string? pageName { get; set; }
        public int? moduelRid { get; set;}
        public string? pageRoute { get; set; }
    }
}
