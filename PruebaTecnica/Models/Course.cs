using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Models
{
    public class Course
    {
        [Key] public int IdCourse { get; set; }
        public string Name { get; set; }
        public string? MessageError { get; set; }
        public DateTime DateCreate { get; set; }
        public string UsrCreate { get; set; }
        public DateTime? DateModify { get; set; }
        public bool Asset { get; set; }
    }
}
