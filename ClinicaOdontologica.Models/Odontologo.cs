using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("odontologos")]
public class Odontologo
{
    [Key]
    [Column("id_odontologo")]
    public int IdOdontologo { get; set; }

    [Required]
    [MaxLength(50)]
    [Column("nombres")]
    public string Nombres { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    [Column("apellidos")]
    public string Apellidos { get; set; } = null!;

    [Required]
    [MaxLength(20)]
    [Column("registro_medico")]
    public string RegistroMedico { get; set; } = null!;

    [Required]
    [Column("id_especialidad")]
    public int IdEspecialidad { get; set; }

    // Relaciones y Restricciones
    [ForeignKey("IdEspecialidad")]
    public Especialidad Especialidad { get; set; } = null!;

    public ICollection<Cita> Citas { get; set; } = new List<Cita>();
}