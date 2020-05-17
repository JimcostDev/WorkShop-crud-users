using System.ComponentModel.DataAnnotations;//se debe importar para poder utilizar data annotations

namespace CrudEntityFramework.Models
{
    public class Usuario
    {
        //data annotations
        [Key]//establecer como PK
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]//dato requerido o necesario
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Teléfono es obligatorio")]//dato requerido o necesario
        [Display(Name ="Teléfono")]//mostrar en pantalla el str con tilde.
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El celular es obligatorio")]//dato requerido o necesario
        public string Celular { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]//dato requerido o necesario
        public string Email { get; set; }

        //Modelo mapeado, implementando Code First


    }
}
