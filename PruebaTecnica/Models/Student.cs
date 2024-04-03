using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnica.Models
{
    public class Student
    {
        [Key] public string ID { get; set; }
        public string Name { get; set; }

        [ForeignKey("IdCourse")]
        public int IdCourse { get; set; }

        [ForeignKey("IdQualification")]
        public int IdQualification { get; set; }
        public string ?MessageError { get; set; }
        public DateTime DateCreate { get; set; }
        public string UsrCreate { get; set; }
        public DateTime? DateModify { get; set; }
        public bool Asset { get; set; }

    }
}
