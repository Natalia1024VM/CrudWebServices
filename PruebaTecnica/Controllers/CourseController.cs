using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Conexion;
using PruebaTecnica.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ConexionBaseDatos conection;

        public CourseController(ConexionBaseDatos conection)
        {
            this.conection = conection;
        }

        // GET: api/<CourseController>
        [HttpGet]
        public IEnumerable<Course> Get()
        {
            return conection.Course.Where(x => x.Asset).ToList();
        }

        // POST api/<CourseController>/5
        [HttpPost]
        public Course Get(int id)
        {
            Course model = conection.Course.Where(x => x.IdCourse == id).FirstOrDefault();
            if (model == null)
            {
                model = new Course();
                model.MessageError = "No existe calificacion";
            }
            return model;
        }
        


        // PUT api/<CourseController>/5
        [HttpPut]
        public void Put( [FromBody] Course value)
        {

            Course model = conection.Course.Where(x => x.IdCourse == value.IdCourse).FirstOrDefault();
            if (model == null)
            {
                model = new Course();
                model.MessageError = "No existe calificacion";
            }
            else
            {
                conection.Course.Remove(model);
                conection.Course.Add(value);
                conection.SaveChanges();
            }
        }

        // DELETE api/<CourseController>/5
        [HttpDelete]
        public void Delete(int id)
        {
            Course model = conection.Course.Where(x => x.IdCourse == id ).FirstOrDefault();
            if (model == null)
            {
                model = new Course();
                model.MessageError = "No existe Calificacion";
                BadRequest(model.MessageError);
            }
            else
            {
                conection.Course.Remove(model);
                model.Asset = false;
                model.DateModify = DateTime.Now;
                conection.Course.Add(model);
                conection.SaveChanges();
                Ok();
            }
        }
    }
}
