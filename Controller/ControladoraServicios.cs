using AgendaEstetica.Model;
using AgendaEstetica.Model.Dao;
using System.Collections.Generic;

namespace AgendaEstetica.Controller
{
    public class ControladoraServicios
    {
        private readonly ServiciosDao _serviciosDAO;

        public ControladoraServicios()
        {
            _serviciosDAO = new ServiciosDao();
        }

        public List<Servicios> ListarActivos()
        {
            return _serviciosDAO.ListarServiciosActivos();
        }

        public List<Servicios> BuscarPorNombre(string nombre)
        {
            return _serviciosDAO.BuscarPorNombre(nombre);
        }

        public void Guardar(Servicios servicio)
        {
            _serviciosDAO.Agregar(servicio);
        }

        public void Editar(Servicios servicio)
        {
            _serviciosDAO.Actualizar(servicio);
        }

        public void SoftDelete(int idServicio)
        {
            _serviciosDAO.Eliminar(idServicio);
        }

        public Servicios BuscarPorId(int id)
        {
            return _serviciosDAO.ObtenerPorId(id);
        }
    }
}