using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("especialidades")]
public class Especialidad
{
    [Key]
    [Column("id_especialidad")]
    public int IdEspecialidad { get; set; }

    [Required]
    [MaxLength(50)]
    [Column("nombre_especialidad")]
    public string NombreEspecilidad { get; set; } = null!;

    [MaxLength(200)]
    [Column("descripcion")]
    public string? Descripcion { get; set; }

    // Propiedad de navegación
    public ICollection<Odontologo> Odontologos { get; set; } = new List<Odontologo>();
}
