using AgendaEstetica.Model;
using AgendaEstetica.Model.Dao;
using System.Collections.Generic;

namespace AgendaEstetica.Controller
{
    public class ControladoraClientes
    {
        private readonly ClientesDao _clientesDAO;

        public ControladoraClientes()
        {
            _clientesDAO = new ClientesDao();
        }

        public List<Clientes> ListarActivos()
        {
            return _clientesDAO.ListarClientesActivos();
        }

        public List<Clientes> BuscarPorNombre(string nombre)
        {
            return _clientesDAO.BuscarPorNombre(nombre);
        }

        public void Guardar(Clientes cliente)
        {
            _clientesDAO.Agregar(cliente);
        }

        public void Editar(Clientes cliente)
        {
            _clientesDAO.Actualizar(cliente);
        }

        public void SoftDelete(int idCliente)
        {
            _clientesDAO.Eliminar(idCliente);
        }

        public Clientes BuscarPorId(int id)
        {
            return _clientesDAO.ObtenerPorId(id);
        }
    }
}