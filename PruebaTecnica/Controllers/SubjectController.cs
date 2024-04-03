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

    public class SubjectController : ControllerBase
    {
        private readonly ConexionBaseDatos conection;

        public SubjectController(ConexionBaseDatos conection)
        {
            this.conection = conection;

        }
        // GET: api/<SubjectController>
        [HttpGet]
        public IEnumerable<Subject> Get()
        {
            return conection.Subject.ToList();
        }

        // GET api/<SubjectController>/5
        [HttpPost]
        public Subject Get(int id)
        {
            Subject model = conection.Subject.Where(x => x.IdSubject == id).FirstOrDefault();
            if (model == null)
            {
                model = new Subject();
                model.MessageError = "No existe materia";

            }
            return model;
        }

      

        // PUT api/<SubjectController>/5
        [HttpPut]
        public void Put( [FromBody] Subject value)
        {
            Subject model = conection.Subject.Where(x => x.IdSubject == value.IdSubject).FirstOrDefault();
            if (model == null)
            {
                model = new Subject();
                model.MessageError = "No existe materia";
                BadRequest(model.MessageError);
            }
            else
            {
                conection.Subject.Remove(model);
                conection.Subject.Add(value);
                conection.SaveChanges();
                Ok();
            }
        }

        // DELETE api/<SubjectController>/5
        [HttpDelete]
        public void Delete(int id)
        {
            Subject model = conection.Subject.Where(x => x.IdSubject == id).FirstOrDefault();
            if (model == null)
            {
                model = new Subject();
                model.MessageError = "No existe materia";
                BadRequest(model.MessageError);
            }
            else
            {
                conection.Subject.Remove(model);
                model.Asset = false;
                model.DateModify = DateTime.Now;
                conection.Subject.Add(model);
                conection.SaveChanges();
                Ok();
            }
        }
    }
}
