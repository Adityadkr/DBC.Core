using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBC.Core.Domain.Context
{
    public class CoreDBContext : DbContext
    {

        public CoreDBContext(DbContextOptions<CoreDBContext> options):base(options)
        {
            
        }
    }
}
