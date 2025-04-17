namespace Wee.SapIntegration.Core.Entities;

using MongoDB.Bson;


public class AltaClienteLog
{
    public ObjectId Id { get; set; }
    public string IdCotizacion { get; set; }
    public string Paso { get; set; }
    public string Endpoint { get; set; }
    public object Payload { get; set; }
    public object Response { get; set; }
    public string Status { get; set; }
    public DateTime FechaHora { get; set; } = DateTime.UtcNow;
    public bool EsError { get; set; }
    public string? MensajeError { get; set; }
}