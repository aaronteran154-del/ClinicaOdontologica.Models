using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("detalles_cita")]
public class DetalleCita
{
    [Key]
    [Column("id_detalle_cita")]
    public int IdDetalleCita { get; set; }

    [Required]
    [Column("id_cita")]
    public int IdCita { get; set; }

    [Required]
    [Column("id_tratamiento")]
    public int IdTratamiento { get; set; }

    [Required]
    [Column("costo_aplicado", TypeName = "numeric(10,2)")]
    public decimal CostoAplicado { get; set; }

    [MaxLength(200)]
    [Column("observaciones")]
    public string? Observaciones { get; set; }

    [ForeignKey("IdCita")]
    public Cita Cita { get; set; } = null!;

    [ForeignKey("IdTratamiento")]
    public Tratamiento Tratamiento { get; set; } = null!;
}
