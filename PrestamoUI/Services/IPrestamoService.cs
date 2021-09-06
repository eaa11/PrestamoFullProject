using PrestamoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrestamoUI.Services
{
    public interface IPrestamoService
    {
        Task<IEnumerable<Prestamo>> GetPrestamos();
    }
}
