using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBC.Core.Domain.Entities.General
{
    public class CommonEntity
    {
        public Guid id { get; set; }
        public DateTime createdDate { get; set; } = DateTime.Now;       
        public DateTime updatedDate { get; set; } = DateTime.Now;
        public string? createdBy {  get; set; }
        public string? updatedBy { get; set; }

    }
}
