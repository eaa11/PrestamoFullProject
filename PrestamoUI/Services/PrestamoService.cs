using PrestamoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PrestamoUI.Services
{
    public class PrestamoService : IPrestamoService
    {
        private readonly HttpClient httpClient;

        public PrestamoService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<Prestamo>> GetPrestamos()
        {
            return await httpClient.GetFromJsonAsync<Prestamo[]>("api/Prestamo");
        }
    }
}
