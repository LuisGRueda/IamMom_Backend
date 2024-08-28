using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoSISINFO3.Entidades
{
    public class RegistroClases
    {
        [Key]
        public int Id { get; set; }

        public int ClaseId { get; set; }
        [ForeignKey("ClaseId")]
        public virtual Clase Clase { get; set; }


        public int EmbarazadaId { get; set; }
        [ForeignKey("EmbarazadaId")]
        public virtual Embarazada Embarazada { get; set; }


        public DateTime Fecha { get; set; }


        public string Estado { get; set; }
    }
}
