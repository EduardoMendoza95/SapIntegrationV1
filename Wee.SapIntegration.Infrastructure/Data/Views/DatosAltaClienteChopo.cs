namespace Wee.SapIntegration.Infrastructure.Data.Views;
using Microsoft.EntityFrameworkCore;

[Keyless]
public class ChopoRequest
{
    public Guid IdCotizacion { get; set; }
    public string? Marca { get; set; }
    public string? NombreCliente { get; set; }
    public string? NombreCliente2 { get; set; }
    public string? NombreCliente3 { get; set; }
    public string? NombreCliente4 { get; set; }
    public string? RFC { get; set; }
    public string? Calle1 { get; set; }
    public string? Calle2 { get; set; }
    public string? NoExterior { get; set; }
    public string? NoInterior { get; set; }
    public string? d_asenta { get; set; }
    public string? d_codigo { get; set; }
    public string? D_mnpio { get; set; }
    public string? AbrevSAP { get; set; }
    public string? nom2 { get; set; }
    public string? Telefono { get; set; }
    public string? Celular { get; set; }
    public string? email { get; set; }
    public int? codTipoPersona { get; set; }
    public string? NombreContacto { get; set; }
    public string? CargoPuesto { get; set; }
    public string? OrgVtas { get; set; }
    public string? Canal { get; set; }
    public string? Sector { get; set; }
    public string? NombreEjecutivo { get; set; }
    public string? GpoTesoreria { get; set; }
    public string? NomConv { get; set; }
    public string? CondPag { get; set; }
    public string? GrpCliente2 { get; set; }
    public string? GrpCliente3 { get; set; }
    public string? GrpCliente4 { get; set; }
    public string? GrpCliente5 { get; set; }
    public string? UsoCFDI { get; set; }
    public string? codRegimenFiscal { get; set; }
    // public string? IdSAP { get; set; }
}


