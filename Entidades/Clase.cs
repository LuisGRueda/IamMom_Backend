using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoSISINFO3.Entidades
{
    public class Clase
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo nombre es requerido")]
        [StringLength(maximumLength: 100, ErrorMessage = "El campo nombre no debe tener mas de 100 caracteres")]
        public string Nombre { get; set; }


        public string Descripcion { get; set; }


        public DateTime FechaHora { get; set; }


        public string MatronaId { get; set; }
        [ForeignKey("MatronaId")]
        public virtual Matrona Matrona { get; set; }


        public int CentroId { get; set; }
        [ForeignKey("CentroId")]
        public virtual Centro Centro { get; set; }



        public string Estado { get; set; }
    }
}
