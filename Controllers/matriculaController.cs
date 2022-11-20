using ActividadSanciones_ASPNET.DAL.Entities;
using ActividadSanciones_ASPNET.DAL.Entities.DBContext;
using ActividadSanciones_ASPNET.DAL.DTOs;
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
    public class matriculaController : ControllerBase
    {
        private readonly multasDbContext _context;

        public matriculaController(multasDbContext context) 
        {
            _context = context;
        }

        #region Mostrar todos los registros
        /// <summary>
        /// <method>Get</method>
        /// Muestra todos los registros de matricula.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<matriculaDTO>>> Get()
        {
            var matricula = await _context.matricula.Select(x =>
            new matriculaDTO
            {
                id = x.id,
                numero = x.numero,
                fecha_expedicion = x.fecha_expedicion,
                fechaValida_hasta = x.fechaValida_hasta,
                activo = x.activo
            }
            ).ToListAsync();
            if (matricula == null)
            {
                return NotFound();
            }
            else {
                return matricula;
            }
        }
        #endregion Mostrar todos los registros

        #region Mostrar registro por id
        /// <summary>
        /// <method>Get</method>
        /// Muestra el registro matricula según el id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<matriculaDTO>> Get(int id)
        {
            var matricula = await _context.matricula.Select(x =>
            new matriculaDTO
            {
                id = x.id,
                numero = x.numero,
                fecha_expedicion = x.fecha_expedicion,
                fechaValida_hasta = x.fechaValida_hasta,
                activo = x.activo
            }).FirstOrDefaultAsync(x => x.id == id);
            if (matricula == null)
            {
                return NotFound();
            }
            else {
                return matricula;
            }
        }
        #endregion Mostrar registro por id

        #region Insertar nuevo registro
        /// <summary>
        /// <Method>Post</Method>
        /// Inserta un nuevo registro en matricula.
        /// </summary>
        /// <param name="matricula"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<HttpStatusCode> Post(matriculaDTO matricula)
        {
            var entity = new matricula()
            {
                numero = matricula.numero,
                fecha_expedicion = matricula.fecha_expedicion,
                fechaValida_hasta = matricula.fechaValida_hasta,
                activo = matricula.activo
            };
            _context.matricula.Add(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }
        #endregion Insertar nuevo registro

        #region Actualizar registro
        /// <summary>
        /// <Method>Put</Method>
        /// Actualiza un registro de matricula según el id.
        /// </summary>
        /// <param name="matricula"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<HttpStatusCode> Put(matriculaDTO matricula)
        {
            var entity = await _context.matricula.FirstOrDefaultAsync(m => m.id == matricula.id);
            entity.id = matricula.id;
            entity.numero = matricula.numero;
            entity.fecha_expedicion = matricula.fecha_expedicion;
            entity.fechaValida_hasta = matricula.fechaValida_hasta;
            entity.activo = matricula.activo;

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return HttpStatusCode.Accepted;

        }
        #endregion Actualizar registro

        #region Eliminar registro
        /// <summary>
        /// <Method>Delete</Method>
        /// Eliminar un registro de matricula según el id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> Delete(int id)
        {
            var entity = new matricula()
            {
                id = id
            };
            _context.matricula.Attach(entity);
            _context.matricula.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
        #endregion Eliminar registro
    }
}
