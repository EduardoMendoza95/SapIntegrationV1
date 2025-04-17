namespace Wee.SapIntegration.Core.Entities;
using System.ComponentModel.DataAnnotations;

public class RegistroCliente

{
    [Key]
    public Guid idRegistro { get; set; }

    public Guid IdCotizacion { get; set; }
    public string Payload { get; set; }
    public string ResponseJSON { get; set; }
    public DateTime xDateInsert { get; set; }
}