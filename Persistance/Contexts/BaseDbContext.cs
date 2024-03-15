using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Contexts
{
    public class BaseDbContext:DbContext
    {
        protected IConfiguration MyProperty{ get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}
