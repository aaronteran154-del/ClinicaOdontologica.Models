using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("consultorios")]
public class Consultorio
{
    [Key]
    [Column("id_consultorio")]
    public int IdConsultorio { get; set; }

    [Required]
    [MaxLength(10)]
    [Column("numero_sala")]
    public string NumeroSala { get; set; } = null!;

    [Required]
    [Column("piso")]
    public int Piso { get; set; }

    [MaxLength(100)]
    [Column("equipamiento_principal")]
    public string? EquipamientoPrincipal { get; set; }

    public ICollection<Cita> Citas { get; set; } = new List<Cita>();
}