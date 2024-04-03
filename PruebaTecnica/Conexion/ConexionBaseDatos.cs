using System.Data;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Controllers;
using PruebaTecnica.Models;

namespace PruebaTecnica.Conexion
{
    public class ConexionBaseDatos : DbContext
    {

        public ConexionBaseDatos(DbContextOptions<ConexionBaseDatos> options) : base(options){


        }
        public DbSet<Course> Course { get; set; }
        public DbSet<Student> Studient { get; set; }
        public DbSet<Qualification> Qualification { get; set; }
        public DbSet<Subject> Subject { get; set; }
    }
}
