using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventjung.Repository.Test
{
    public class SampleContext : DbContext
    {
        public SampleContext() : base("constring")
        {

        }
        public DbSet<SampleTable> SampleTable { get; set; }
    }
}
