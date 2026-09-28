using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("facturas")]
public class Factura
{
    [Key]
    [Column("id_factura")]
    public int IdFactura { get; set; }

    [Required]
    [Column("fecha_emision", TypeName = "timestamp")]
    public DateTime FechaEmision { get; set; }

    [Required]
    [Column("subtotal", TypeName = "numeric(10,2)")]
    public decimal Subtotal { get; set; }

    [Required]
    [Column("impuestos", TypeName = "numeric(10,2)")]
    public decimal Impuestos { get; set; }

    [Required]
    [Column("total", TypeName = "numeric(10,2)")]
    public decimal Total { get; set; }

    [MaxLength(20)]
    [Column("estado_pago")]
    public string EstadoPago { get; set; } = "Pendiente";

    [Required]
    [Column("id_cita")]
    public int IdCita { get; set; }

    [ForeignKey("IdCita")]
    public Cita Cita { get; set; } = null!;
}