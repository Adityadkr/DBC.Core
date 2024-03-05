using DBC.Core.Domain.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBC.Core.Domain.Entities.Workflow
{
    public class ModuleEntity: CommonEntity
    {
        public string? moduleName { get; set; }
        public string? moduleRoute { get; set; }
        public ICollection<PageEntity> lstPages { get; } = new List<PageEntity>();
    }
}
