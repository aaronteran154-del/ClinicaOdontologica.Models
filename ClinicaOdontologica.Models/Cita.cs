using ClinicaOdontologica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("citas")]
public class Cita
{
    [Key]
    [Column("id_cita")]
    public int IdCita { get; set; }

    [Required]
    [Column("fecha_cita", TypeName = "timestamp")]
    public DateTime FechaCita { get; set; }

    [MaxLength(200)]
    [Column("motivo")]
    public string? Motivo { get; set; }

    [MaxLength(20)]
    [Column("estado_cita")]
    public string EstadoCita { get; set; } = "Pendiente";

    [Required]
    [Column("id_paciente")]
    public int IdPaciente { get; set; }

    [Required]
    [Column("id_odontologo")]
    public int IdOdontologo { get; set; }

    [Required]
    [Column("id_consultorio")]
    public int IdConsultorio { get; set; }

    // Relaciones FK
    [ForeignKey("IdPaciente")]
    public Paciente Paciente { get; set; } = null!;

    [ForeignKey("IdOdontologo")]
    public Odontologo Odontologo { get; set; } = null!;

    [ForeignKey("IdConsultorio")]
    public Consultorio Consultorio { get; set; } = null!;

    public ICollection<DetalleCita> DetallesCita { get; set; } = new List<DetalleCita>();
    public ICollection<Receta> Recetas { get; set; } = new List<Receta>();
    public Factura? Factura { get; set; }
}