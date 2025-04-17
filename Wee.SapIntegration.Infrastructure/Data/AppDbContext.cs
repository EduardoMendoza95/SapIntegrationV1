namespace Wee.SapIntegration.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Wee.SapIntegration.Infrastructure.Data.Views;
using Wee.SapIntegration.Core.Entities;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<ChopoRequest> ChopoRequest { get; set; }
    // public DbSet<ConvenioSAPView> ConvenioSAPView { get; set; }
    public DbSet<RegistroCliente> RegistroCliente { get; set; }
    // public DbSet<LogAltaConvenioSAP> LogAltaConvenioSAP { get; set; }
    // public DbSet<ConvenioDatosExtra> ConvenioDatosExtra { get; set; }
    // public DbSet<CodCliente> CodCliente { get; set; }
    // public DbSet<ListaPreciosSAPView> ListaPreciosSAPView { get; set; }

    // public DbSet<Region> Regiones { get; set; }
    // public DbSet<CotizacionParent> CotizacionesParent { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChopoRequest>().HasNoKey().ToView("vw_Weetrack_Datos_AltaClientesSAP_Proa"); //Consumo vista cliente
        // modelBuilder.Entity<ConvenioSAPView>().HasNoKey().ToView("vw_Weetrack_Datos_ConveniosSAP_Proa"); //consumo vista convenio
        // modelBuilder.Entity<ListaPreciosSAPView>().HasNoKey().ToView("vw_Weetrack_Datos_ListaPreciosSAP_Proa"); //consumo lista precios
        
        // modelBuilder.Entity<Region>(entity =>
        // {
        //     entity.HasNoKey();
        //     entity.Property(e => e.DesripcionRegion).HasColumnName("DesripcionRegion");
        // }); // Estrae regiones para el convenio

        // modelBuilder.Entity<ConvenioDatosExtra>(entity =>
        // {
        //     entity.HasNoKey();
        //     entity.Property(e => e.CodClienteSAP).HasColumnName("CodClienteSAP");
        //     entity.Property(e => e.CodConvenio).HasColumnName("CodConvenio");
        //     entity.Property(e => e.FechaInicioConvenio).HasColumnName("FechaInicioConvenio");
        // });

        // modelBuilder.Entity<CodCliente>(entity =>
        // {
        //     entity.HasNoKey();
        //     entity.Property(e => e.CodClienteSAP).HasColumnName("CodClienteSAP");
        // });

        // modelBuilder.Entity<CotizacionParent>().HasNoKey();

        modelBuilder.Entity<RegistroCliente>().ToTable("wtRegistroClienteSAP"); //Registro tabla de clientes sql
        // modelBuilder.Entity<LogAltaConvenioSAP>().ToTable("WTRegistroConvenioByCotizacion"); //Registro tabla de convenio sql
        
    }
}

