using System.ComponentModel.DataAnnotations;

namespace ProyectoSISINFO3.Entidades
{
    public class Matrona
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo nombre es requerido")]
        [StringLength(maximumLength: 100, ErrorMessage = "El campo nombre no debe tener mas de 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo apellido es requerido")]
        [StringLength(maximumLength: 100, ErrorMessage = "El campo apellidos no debe tener mas de 100 caracteres")]
        public string Apellidos { get; set; }

        [StringLength(15, ErrorMessage = "El valor debe ser almenos {2} y el maximo {1} caracteres", MinimumLength = 7)]
        public int Ci { get; set; }

        [StringLength(50, ErrorMessage = "El valor debe ser almenos {2} y el maximo {1} caracteres", MinimumLength = 3)]
        public string Usuario { get; set; }

        public string Contrasenia { get; set; }

        public string Rol { get; set; }

        [EmailAddress]
        public string Correo { get; set; }


        [StringLength(20, ErrorMessage = "El valor debe ser almenos {2} y el maximo {1} caracteres", MinimumLength = 6)]
        public int Telefono { get; set; }

        public DateTime Horario { get; set; }

        public string Estado { get; set; }
    }
}
