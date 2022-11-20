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
    public class sancionesController : ControllerBase
    {

        private readonly multasDbContext _context;

        public sancionesController(multasDbContext context)
        {
            _context = context;
        }


        #region Mostrar todos los registros
        /// <summary>
        /// <method>Get</method>
        /// Muestra todos los registros de sanciones.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<sancionesDTO>>> Get()
        {
            var sanciones = await _context.sanciones.Select(x =>
            new sancionesDTO
            {
                id = x.id,
                fecha_actual = x.fecha_actual,
                conductorId = x.conductorId,
                nombreConductor = x.conductor.nombre,
                apellidosConductor = x.conductor.apellidos,
                sancion = x.sancion,
                valor = x.valor
            }
            ).ToListAsync();
            if (sanciones == null)
            {
                return NotFound();
            }
            else
            {
                return sanciones;
            }
        }
        #endregion Mostrar todos los registros

        #region Mostrar registro por id
        /// <summary>
        /// <method>Get</method>
        /// Muestra el registro sanciones según el id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<sancionesDTO>> Get(int id)
        {
            var sanciones = await _context.sanciones.Select(x =>
            new sancionesDTO
            {
                id = x.id,
                fecha_actual = x.fecha_actual,
                conductorId = x.conductorId,
                nombreConductor = x.conductor.nombre,
                apellidosConductor = x.conductor.apellidos,
                sancion = x.sancion,
                valor = x.valor
            }).FirstOrDefaultAsync(x => x.id == id);
            if (sanciones == null)
            {
                return NotFound();
            }
            else
            {
                return sanciones;
            }
        }
        #endregion Mostrar registro por id

        #region Insertar nuevo registro
        /// <summary>
        /// <Method>Post</Method>
        /// Inserta un nuevo registro en sanciones.
        /// </summary>
        /// <param name="sanciones"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<HttpStatusCode> Post(sancionesDTO sanciones)
        {
            var entity = new sanciones()
            {
                fecha_actual = sanciones.fecha_actual,
                conductorId = sanciones.conductorId,
                sancion = sanciones.sancion,
                valor = sanciones.valor
            };
            _context.sanciones.Add(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }
        #endregion Insertar nuevo registro

        #region Actualizar registro
        /// <summary>
        /// <Method>Put</Method>
        /// Actualiza un registro de sanciones según el id.
        /// </summary>
        /// <param name="sanciones"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<HttpStatusCode> Put(sancionesDTO sanciones)
        {
            var entity = await _context.sanciones.FirstOrDefaultAsync(s => s.id == sanciones.id);
            entity.id = sanciones.id;
            entity.conductorId = sanciones.conductorId;
            entity.sancion = sanciones.sancion;
            entity.valor = sanciones.valor;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return HttpStatusCode.Accepted;
        }
        #endregion Actualizar registro

        #region Eliminar registro
        /// <summary>
        /// <Method>Delete</Method>
        /// Eliminar un registro de sanciones según el id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> Delete(int id)
        {
            var entity = new sanciones()
            {
                id = id
            };
            _context.sanciones.Attach(entity);
            _context.sanciones.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
        #endregion Eliminar registro
    }
}
