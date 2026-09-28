using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("recetas")]
public class Receta
{
    [Key]
    [Column("id_receta")]
    public int IdReceta { get; set; }

    [Required]
    [Column("fecha_emision", TypeName = "timestamp")]
    public DateTime FechaEmision { get; set; }

    [Required]
    [Column("indicaciones")]
    public string Indicaciones { get; set; } = null!;

    [Required]
    [Column("id_cita")]
    public int IdCita { get; set; }

    [ForeignKey("IdCita")]
    public Cita Cita { get; set; } = null!;
}