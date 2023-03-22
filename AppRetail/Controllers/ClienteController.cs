using DbRetail.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppRetail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly SISTEMA_RETAILContext _context;
        public ClienteController(SISTEMA_RETAILContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("ObtenerCliente")]
        public IActionResult ObtenerCliente()
        {
            List<Cliente> lista = _context.Clientes.ToList();
            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpGet]
        [Route("ObtenerClientePorDni")]
        public IActionResult ObtenerClientePorDni(int dni)
        {
            var cliente = _context.Clientes.Where(c => c.Dni == dni).ToList();
            if (cliente.Count == 0)
                return StatusCode(StatusCodes.Status400BadRequest, "no existe un cliente con ese dni");
            return StatusCode(StatusCodes.Status200OK, cliente);
        }

        [HttpPost]
        [Route("AgregarCliente")]
        public IActionResult AgregarCliente([FromBody] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                // agregar el nuevo cliente a la base de datos
                _context.Clientes.Add(new Cliente
                {
                    Dni = cliente.Dni,
                    Nombre = cliente.Nombre,
                    Direccion = cliente.Direccion,
                    CorreoElectronico= cliente.CorreoElectronico,
                    NumeroTelefono = cliente.NumeroTelefono
                });
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status201Created);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [HttpPut("{dni}")]
        [Route("ActualizarCliente")]
        public IActionResult ActualizarCliente(int dni,[FromBody] Cliente clienteActualizado)
        {
            var clienteExistente = _context.Clientes.Find(dni);

            if (clienteExistente == null)
            {
                return NotFound();
            }

            clienteExistente.Nombre = clienteActualizado.Nombre;
            clienteExistente.Direccion = clienteActualizado.Direccion;
            clienteExistente.CorreoElectronico = clienteActualizado.CorreoElectronico;
            clienteExistente.NumeroTelefono = clienteActualizado.NumeroTelefono;

            _context.SaveChanges();

            return Ok(clienteExistente);
        }
    }
}
