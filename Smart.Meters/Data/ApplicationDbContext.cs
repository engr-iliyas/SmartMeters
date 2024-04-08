using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Smart.Meters.Model;

namespace Smart.Meters.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Smart.Meters.Model.Meter> Meter { get; set; } = default!;
        public DbSet<Smart.Meters.Model.Customer> Customer { get; set; } = default!;
        public DbSet<Smart.Meters.Model.F11KV> F11KV { get; set; } = default!;
        public DbSet<Smart.Meters.Model.Transformer> Transformer { get; set; } = default!;
        public DbSet<Smart.Meters.Model.F33KV> F33KV { get; set; } = default!;
    }
}
