using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Conexion;
using PruebaTecnica.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class QualificationController : ControllerBase
    {
        private readonly ConexionBaseDatos conection;

        public QualificationController(ConexionBaseDatos conection)
        {
            this.conection = conection;
        }
        // GET: api/<QualificationController>
        [HttpGet]
        public IEnumerable<Qualification> Get()
        {
            return conection.Qualification.Where(x => x.Asset).ToList();
        }

        // Post api/<QualificationController>/5
        [HttpPost]
        public Qualification Get(int id, int IdSubject)
        {
            Qualification model = conection.Qualification.Where(x => x.IdQualification == id && x.IdSubject == IdSubject).FirstOrDefault();
            if (model == null)
            {
                model = new Qualification();
                model.MessageError = "No existe calificacion";
            }
            return model;
        }
    

        // PUT api/<QualificationController>/5
        [HttpPut]
        public void Put(int id, [FromBody] Qualification value)
        {
            Qualification model = conection.Qualification.Where(x => x.IdQualification == value.IdQualification && x.IdSubject == value.IdSubject).FirstOrDefault();
            if (model == null)
            {
                model = new Qualification();
                model.MessageError = "No existe calificacion";
            }
            else
            {
                conection.Qualification.Remove(model);
                conection.Qualification.Add(value);
                conection.SaveChanges();
            }
        }

        // DELETE api/<QualificationController>/5
        [HttpDelete]
        public void Delete(int id, int idSubject)
        {
            Qualification model = conection.Qualification.Where(x => x.IdQualification == id && x.IdSubject == idSubject).FirstOrDefault();
            if (model == null)
            {
                model = new Qualification();
                model.MessageError = "No existe Calificacion";
                BadRequest(model.MessageError);
            }
            else
            {
                conection.Qualification.Remove(model);
                model.Asset = false;
                model.DateModify = DateTime.Now;
                conection.Qualification.Add(model);
                conection.SaveChanges();
                Ok();
            }
        }
    }
}
