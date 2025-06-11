using AgendaEstetica.Model;
using AgendaEstetica.Model.Dao;
using System.Collections.Generic;

namespace AgendaEstetica.Controller
{
    public class ControladoraHorarioCita
    {
        private readonly HorarioCitaDao _horarioCitaDAO;

        public ControladoraHorarioCita()
        {
            _horarioCitaDAO = new HorarioCitaDao();
        }

        public List<HorarioCita> ListarActivos()
        {
            return _horarioCitaDAO.ListarHorariosActivos();
        }

        public List<HorarioCita> ListarDisponibles()
        {
            return _horarioCitaDAO.ListarHorariosDisponibles();
        }

        public List<HorarioCita> ListarPorEmpleado(int idEmpleado)
        {
            return _horarioCitaDAO.ListarHorariosPorEmpleado(idEmpleado);
        }

        public void Guardar(HorarioCita horario)
        {
            _horarioCitaDAO.Agregar(horario);
        }

        public void Editar(HorarioCita horario)
        {
            _horarioCitaDAO.Actualizar(horario);
        }

        public void SoftDelete(int idHorario)
        {
            _horarioCitaDAO.Eliminar(idHorario);
        }

        public HorarioCita BuscarPorId(int id)
        {
            return _horarioCitaDAO.ObtenerPorId(id);
        }
    }
}