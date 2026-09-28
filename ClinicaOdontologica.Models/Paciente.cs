using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("pacientes")]
public class Paciente
{
    [Key]
    [Column("id_paciente")]
    public int IdPaciente { get; set; }

    [Required]
    [MaxLength(10)]
    [Column("dni")]
    public string Dni { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    [Column("nombres")]
    public string Nombres { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    [Column("apellidos")]
    public string Apellidos { get; set; } = null!;

    [Required]
    [Column("fecha_nacimiento", TypeName = "date")]
    public DateTime FechaNacimiento { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("email")]
    public string Email { get; set; } = null!;

    [MaxLength(15)]
    [Column("telefono")]
    public string? Telefono { get; set; }

    // Relaciones
    public HistorialMedico? HistorialMedico { get; set; }
    public ICollection<Cita> Citas { get; set; } = new List<Cita>();
}
