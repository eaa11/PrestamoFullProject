using Microsoft.EntityFrameworkCore;
using PrestamoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestamoData.Models
{
    public class PrestamoDbContext:DbContext
    {
        public PrestamoDbContext(DbContextOptions<PrestamoDbContext> options)
            :base(options)
        {

        }
        public DbSet<Prestamo> Prestamos { get; set; }
    }
}
