using System.ComponentModel.DataAnnotations;

namespace ProyectoSISINFO3.Entidades
{
    public class Centro
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo nombre es requerido")]
        [StringLength(maximumLength: 100, ErrorMessage = "El campo nombre no debe tener mas de 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Direccion es requerido")]
        [StringLength(maximumLength: 100, ErrorMessage = "El campo direccion no debe tener mas de 100 caracteres")]
        public string Direccion { get; set; }

        [StringLength(20, ErrorMessage = "El valor debe ser almenos {2} y el maximo {1} caracteres", MinimumLength = 6)]
        public int  Telefono { get; set; }


        public string Tipo { get; set; }

        public string Estado { get; set; }
    }
}
