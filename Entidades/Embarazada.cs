using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoSISINFO3.Entidades
{
    public class Embarazada
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo nombre es requerido")]
        [StringLength(maximumLength: 100, ErrorMessage = "El campo nombre no debe tener mas de 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo apellido es requerido")]
        [StringLength(maximumLength: 100, ErrorMessage = "El campo apellidos no debe tener mas de 100 caracteres")]
        public string Apellidos { get; set; }

        public int Ci { get; set; }

        public int NroSeguro { get; set; }



        public string Direccion { get; set; }

        public int Edad { get; set; }

        public int SemanaGestacion { get; set; }

        public int NroHijos { get; set; }

        [StringLength(20, ErrorMessage = "El valor debe ser almenos {2} y el maximo {1} caracteres", MinimumLength = 6)]
        public int Telefono { get; set; }

        public string  Registro{ get; set; }

        //Llave foreana
        public int MatronaId { get; set; }
        [ForeignKey("MatronaId")]
        public virtual Matrona Matrona { get; set; }

        public string Estado { get; set; }
    }
}
