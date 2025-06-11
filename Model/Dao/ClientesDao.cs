using AgendaEstetica.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgendaEstetica.Model.Dao
{
    public class ClientesDao
    {
        private readonly AgendaEsteticaContext _context;

        public ClientesDao()
        {
            _context = new AgendaEsteticaContext();
        }

        public void Agregar(Clientes cliente)
        {
            cliente.CreatedAt = DateTime.Now;
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public Clientes ObtenerPorId(int id)
        {
            return _context.Clientes.FirstOrDefault(c => c.IdCliente == id && c.DeletedAt == null);
        }

        public List<Clientes> ListarClientesActivos()
        {
            return _context.Clientes
                .Where(c => c.DeletedAt == null)
                .OrderBy(c => c.NombreApellido)
                .ToList();
        }

        public void Actualizar(Clientes clienteActualizado)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.IdCliente == clienteActualizado.IdCliente && c.DeletedAt == null);
            if (cliente != null)
            {
                cliente.NombreApellido = clienteActualizado.NombreApellido;
                cliente.Telefono = clienteActualizado.Telefono;
                cliente.UpdatedAt = DateTime.Now;
                _context.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.IdCliente == id && c.DeletedAt == null);
            if (cliente != null)
            {
                cliente.DeletedAt = DateTime.Now;
                _context.SaveChanges();
            }
        }

        public List<Clientes> BuscarPorNombre(string nombre)
        {
            return _context.Clientes
                .Where(c => c.NombreApellido.Contains(nombre) && c.DeletedAt == null)
                .ToList();
        }
    }
}