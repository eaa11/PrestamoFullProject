using Microsoft.EntityFrameworkCore;
using PrestamoData.Interfaces;
using PrestamoData.Models;
using PrestamoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestamoData.Repositories
{
    public class PrestamoRepository : IPrestamoRepository
    {
        private readonly PrestamoDbContext prestamoDbContext;

        public PrestamoRepository(PrestamoDbContext prestamoDbContext )
        {
            this.prestamoDbContext = prestamoDbContext;
        }
        public async Task<Prestamo> Create(Prestamo prestamo)
        {
            prestamoDbContext.Add(prestamo);
            await prestamoDbContext.SaveChangesAsync();
            return prestamo;
        }

        public async Task Delete(int id)
        {
            var prestamoToDelete = await prestamoDbContext.Prestamos.FindAsync(id);
            if(prestamoToDelete != null)
            {
                prestamoDbContext.Prestamos.Remove(prestamoToDelete);
                await prestamoDbContext.SaveChangesAsync();
            }
        }

        public async Task<Prestamo> GetPrestamo(int id)
        {
            return await prestamoDbContext.Prestamos.FindAsync(id);
        }

        public async Task<IEnumerable<Prestamo>> GetPrestamos()
        {
            return await prestamoDbContext.Prestamos.ToListAsync();
        }

        public async Task Update(Prestamo prestamo)
        {
            prestamoDbContext.Entry(prestamo).State = EntityState.Modified;
            await prestamoDbContext.SaveChangesAsync();
        }
    }
}
