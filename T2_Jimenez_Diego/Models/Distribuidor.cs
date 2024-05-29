using System.ComponentModel.DataAnnotations;

namespace T2_Jimenez_Diego.Models
{
    public class Distribuidor
    {
        //Validaciones
        [Key] //Propiedad llave primaria.
        public int ID {  get; set; }
        [Required(ErrorMessage = "El nombre del distribuidor es obligatorio")] //Propiedad obligatorio
        public string NombreDistribuidor {  get; set; }
        [Required(ErrorMessage = "La Razon social es obligatorio")]
        public string RazonSocial { get; set; }
        [Required(ErrorMessage = "El telefono es obligatorio")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El Año de inicio de operacion es obligatorio")]
        [Range(1900, 3000, ErrorMessage = "Año de operacion invalido, debe ser entre 1900 y 3000!!")] //Propiedad rango
        public int AnioInicioOperacion {  get; set; }
        [Required(ErrorMessage = "El contacto es obligatorio")]
        public string Contacto { get; set; }
    }
}
