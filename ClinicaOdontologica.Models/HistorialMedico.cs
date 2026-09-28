using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("historiales_medicos")]
public class HistorialMedico
{
    [Key]
    [Column("id_historial")]
    public int IdHistorial { get; set; }

    [MaxLength(200)]
    [Column("alergias")]
    public string Alergias { get; set; } = "Ninguna";

    [MaxLength(200)]
    [Column("enfermedades_previas")]
    public string EnfermedadesPrevias { get; set; } = "Ninguna";

    [MaxLength(5)]
    [Column("tipo_sangre")]
    public string? TipoSangre { get; set; }

    [Required]
    [Column("id_paciente")]
    public int IdPaciente { get; set; }

    [ForeignKey("IdPaciente")]
    public Paciente Paciente { get; set; } = null!;
}
