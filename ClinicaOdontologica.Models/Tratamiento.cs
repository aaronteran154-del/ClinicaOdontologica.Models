using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("tratamientos")]
public class Tratamiento
{
    [Key]
    [Column("id_tratamiento")]
    public int IdTratamiento { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("nombre_tratamiento")]
    public string NombreTratamiento { get; set; } = null!;

    [Required]
    [Column("costo_base", TypeName = "numeric(10,2)")]
    public decimal CostoBase { get; set; }

    [Required]
    [Column("duracion_estimada_minutos")]
    public int DuracionEstimadaMinutos { get; set; }

    public ICollection<DetalleCita> DetallesCita { get; set; } = new List<DetalleCita>();
}