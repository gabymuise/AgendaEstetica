using AgendaEstetica.Model;
using AgendaEstetica.Model.Dao;
using System.Collections.Generic;

namespace AgendaEstetica.Controller
{
    public class ControladoraAgendaCitas
    {
        private readonly AgendaCitasDao _agendaCitasDAO;

        public ControladoraAgendaCitas()
        {
            _agendaCitasDAO = new AgendaCitasDao();
        }

        public List<AgendaCitas> ListarActivas()
        {
            return _agendaCitasDAO.ListarCitasActivas();
        }

        public List<AgendaCitas> ListarPorCliente(int idCliente)
        {
            return _agendaCitasDAO.ListarCitasPorCliente(idCliente);
        }

        public List<AgendaCitas> ListarPendientesPago()
        {
            return _agendaCitasDAO.ListarCitasPendientesPago();
        }

        public void Guardar(AgendaCitas cita)
        {
            _agendaCitasDAO.Agregar(cita);
        }

        public void Editar(AgendaCitas cita)
        {
            _agendaCitasDAO.Actualizar(cita);
        }

        public void SoftDelete(int idCita)
        {
            _agendaCitasDAO.Eliminar(idCita);
        }

        public AgendaCitas BuscarPorId(int id)
        {
            return _agendaCitasDAO.ObtenerPorId(id);
        }
    }
}