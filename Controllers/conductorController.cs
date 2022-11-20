using ActividadSanciones_ASPNET.DAL.Entities;
using ActividadSanciones_ASPNET.DAL.DTOs;
using ActividadSanciones_ASPNET.DAL.Entities.DBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ActividadSanciones_ASPNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class conductorController : ControllerBase
    {
        private readonly multasDbContext _context;

        public conductorController(multasDbContext context)
        {
            _context = context;
        }

        #region Mostrar todos los registros
        /// <summary>
        /// <method>Get</method>
        /// Muestra todos los registros de conductor.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<conductorDTO>>> Get()
        {
            var conductor = await _context.conductor.Select(x =>
            new conductorDTO
            {
                id = x.id,
                identificacion = x.identificacion, 
                nombre = x.nombre,
                apellidos= x.apellidos,
                direccion = x.direccion,
                telefono = x.telefono,
                email = x.email,
                fecha_nacimiento = x.fecha_nacimiento,
                activo = x.activo,
                matriculaId = x.matriculaId,
                numeroMatricula = x.matricula.numero
            }
            ).ToListAsync();
            if (conductor == null)
            {
                return NotFound();
            }
            else
            {
                return conductor;
            }
        }
        #endregion Mostrar todos los registros

        #region Mostrar registro por id
        /// <summary>
        /// <method>Get</method>
        /// Muestra el registro conductor según el id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<conductorDTO>> Get(int id)
        {
            var conductor = await _context.conductor.Select(x =>
            new conductorDTO
            {
                id = x.id,
                identificacion = x.identificacion,
                nombre = x.nombre,
                apellidos = x.apellidos,
                direccion = x.direccion,
                telefono = x.telefono,
                email = x.email,
                fecha_nacimiento = x.fecha_nacimiento,
                activo = x.activo,
                matriculaId = x.matriculaId,
                numeroMatricula = x.matricula.numero
            }).FirstOrDefaultAsync(x => x.id == id);
            if (conductor == null)
            {
                return NotFound();
            }
            else
            {
                return conductor;
            }
        }
        #endregion Mostrar registro por id

        #region Insertar nuevo registro
        /// <summary>
        /// <Method>Post</Method>
        /// Inserta un nuevo registro en conductor.
        /// </summary>
        /// <param name="conductor"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<HttpStatusCode> Post(conductorDTO conductor)
        {
            var entity = new conductor()
            {
                               
                identificacion = conductor.identificacion,
                nombre = conductor.nombre,
                apellidos = conductor.apellidos,
                direccion = conductor.direccion,
                telefono = conductor.telefono,
                email = conductor.email,
                fecha_nacimiento = conductor.fecha_nacimiento,
                activo = conductor.activo,
                matriculaId = conductor.matriculaId
            };
            _context.conductor.Add(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }
        #endregion Insertar nuevo registro

        #region Actualizar registro
        /// <summary>
        /// <Method>Put</Method>
        /// Actualiza un registro de conductor según el id.
        /// </summary>
        /// <param name="conductor"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<HttpStatusCode> Put(conductorDTO conductor)
        {
            var entity = await _context.conductor.FirstOrDefaultAsync(c => c.id == conductor.id);
            entity.id = conductor.id;
            entity.identificacion = conductor.identificacion;
            entity.nombre = conductor.nombre;
            entity.apellidos = conductor.apellidos;
            entity.direccion = conductor.direccion;
            entity.telefono = conductor.telefono;
            entity.email = conductor.email;
            entity.fecha_nacimiento = conductor.fecha_nacimiento;
            entity.activo = conductor.activo;
            entity.matriculaId = conductor.matriculaId;


            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return HttpStatusCode.Accepted;
        }
        #endregion Actualizar registro

        #region Eliminar registro
        /// <summary>
        /// <Method>Delete</Method>
        /// Eliminar un registro de conductor según el id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> Delete(int id)
        {
            var entity = new conductor()
            {
                id = id
            };
            _context.conductor.Attach(entity);
            _context.conductor.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
        #endregion Eliminar registro
    }
}
