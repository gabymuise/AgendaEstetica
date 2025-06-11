using AgendaEstetica.Model;
using AgendaEstetica.Model.Dao;
using System.Collections.Generic;

namespace AgendaEstetica.Controller
{
    public class ControladoraEmpleados
    {
        private readonly EmpleadosDao _empleadosDAO;

        public ControladoraEmpleados()
        {
            _empleadosDAO = new EmpleadosDao();
        }

        public List<Empleados> ListarActivos()
        {
            return _empleadosDAO.ListarEmpleadosActivos();
        }

        public List<Empleados> BuscarPorEspecialidad(string especialidad)
        {
            return _empleadosDAO.BuscarPorEspecialidad(especialidad);
        }

        public void Guardar(Empleados empleado)
        {
            _empleadosDAO.Agregar(empleado);
        }

        public void Editar(Empleados empleado)
        {
            _empleadosDAO.Actualizar(empleado);
        }

        public void SoftDelete(int idEmpleado)
        {
            _empleadosDAO.Eliminar(idEmpleado);
        }

        public Empleados BuscarPorId(int id)
        {
            return _empleadosDAO.ObtenerPorId(id);
        }
    }
}