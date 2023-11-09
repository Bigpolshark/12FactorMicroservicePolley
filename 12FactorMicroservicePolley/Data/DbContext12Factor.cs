using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TwelveFactorMicroservicePolley.Models;

namespace TwelveFactorMicroservicePolley.Data
{
    public class DbContext12Factor : DbContext
    {
        public DbContext12Factor (DbContextOptions<DbContext12Factor> options)
            : base(options)
        {
        }

        public DbSet<TwelveFactorMicroservicePolley.Models.RouteDataObject> RouteDataDB { get; set; } = default!;
    }
}
