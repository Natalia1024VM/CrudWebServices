using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using PruebaTecnica.Conexion;
using PruebaTecnica.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class StudentController : ControllerBase
    {
        //public IConfiguration configuration;

        private readonly ConexionBaseDatos conection;
        //private string Issuer = configuration["ApiAuth:Issuer"];
        //private string Audience = configuration["ApiAuth:Audience"];
        //private string Secretkey = configuration["ApiAuth:SecretKey"];

        public StudentController(ConexionBaseDatos conection)
        {
            this.conection = conection;
        }

        // GET: api/<Student>
        [HttpGet]
        public IEnumerable<Student> Get(string? ID)
        {
            if(ID != null)
            {
                Student model = conection.Studient.Where(x => x.ID == ID).FirstOrDefault();
                if (model == null)
                {
                    model = new Student();
                    model.MessageError = "No existe estudiante";

                }
                List<Student> students = new List<Student>();
                students.Add(model);
                return students;
            }
            else
            {
                return conection.Studient.Where(x => x.Asset).ToList();

            }
        }

    

        // POST api/<CourseController>/5
        [HttpPost]
        public Student Post(Student model)
        {
            if (model == null)
            {
                model = new Student();
                model.MessageError = "No tiene datos";
            }
            else
            {
                Student modelExist = conection.Studient.Where(x => x.ID == model.ID).FirstOrDefault();
                bool validacion = true;
                string mensajeError = "";
                if (modelExist == null)
                {

                    if (model.ID == "")
                    {
                        validacion = false;
                        mensajeError = mensajeError + " Identificacion obligatoria";
                    }
                    if (model.Name == "")
                    {
                        validacion = false;
                        mensajeError = mensajeError + " Nombre obligatoria";
                    }

                    if (model.IdCourse == 0)
                    {
                        validacion = false;
                        mensajeError = mensajeError + " Curso obligatoria";
                    }
                    if (model.IdQualification == 0)
                    {
                        validacion = false;
                        mensajeError = mensajeError + " Calificaciones obligatoria";
                    }


                    model.Asset = true;
                    if (validacion)
                    {
                        conection.Studient.Add(model);
                        conection.SaveChanges();
                    }
                    else
                    {
                        model.MessageError = mensajeError;
                    }
                }
                else
                {
                    validacion = false;
                    mensajeError = mensajeError + " El estudiante ya existe";
                    model.MessageError = mensajeError;

                }
            }
            return model;
        }

        // PUT api/<Student>/5
        [HttpPut]
        public void Put([FromBody] Student value)
        {
            Student model = conection.Studient.Where(x => x.ID == value.ID).FirstOrDefault();
            if (model == null)
            {
                model = new Student();
                model.MessageError = "No existe estudiante";
            }
            else
            {
                conection.Studient.Remove(model);
                conection.Studient.Add(value);
                conection.SaveChanges();
            }
        }

        // DELETE api/<Student>/5
        [HttpDelete]
        public void Delete(string identificacion)
        {
            Student model = conection.Studient.Where(x => x.ID == identificacion).FirstOrDefault();
            if (model == null)
            {
                model = new Student();
                model.MessageError = "No existe estudiante";
                BadRequest(model.MessageError);
            }
            else
            {
                conection.Studient.Remove(model);
                conection.SaveChanges();
                model.DateModify = DateTime.Now;
                model.Asset = false;
                conection.Studient.Add(model);
                conection.SaveChanges();
                Ok();
            }
        }
    }
}
