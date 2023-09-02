using Centralizador.DTO;

namespace Centralizador.ComunicacionSync.http.ClienteHttp
{
    public interface ICampusHistorialCliente
    {
        Task ComunicarseConCampus(EstudianteReadDTO est);
    }
}
