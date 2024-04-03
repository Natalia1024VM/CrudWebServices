using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnica.Models
{
    public class Qualification
    {
        [Key] public int IdQualification { get; set; }
        public decimal Nota { get; set; }
        [ForeignKey("IdSubject")]
        public int IdSubject { get; set; }
        public string? MessageError { get; set; }
        public DateTime DateCreate { get; set; }
        public string UsrCreate { get; set; }
        public DateTime? DateModify { get; set; }
        public bool Asset { get; set; }

    }
}
