using PrestamoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestamoData.Interfaces
{
    public interface IPrestamoRepository
    {
        Task<IEnumerable<Prestamo>> GetPrestamos();
        Task<Prestamo> GetPrestamo(int id);
        Task<Prestamo> Create(Prestamo prestamo);
        Task Update(Prestamo prestamo);
        Task Delete(int id);
    }
}
