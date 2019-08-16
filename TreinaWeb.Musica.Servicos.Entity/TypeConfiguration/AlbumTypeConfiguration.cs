using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinaWeb.Comum;
using TreinaWeb.Musica.Dominio;

namespace TreinaWeb.Musica.Servicos.Entity.TypeConfiguration
{
    class AlbumTypeConfiguration : TreinaWebEntityAbstractConfig<Album>
    {
        protected override void ConfigurarCamposTabela()
        {
            Property(x => x.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("ALB_ID");

            Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("ALB_NOME")
                .HasMaxLength(100);

            Property(x => x.Ano)
                .IsRequired()
                .HasColumnName("ALB_ANO");

            Property(x => x.Obeservacoes)
                .IsOptional()
                .HasColumnName("ALB_OBSERVACOES")
                .HasMaxLength(1000);

            Property(x => x.Email)
                .IsRequired()
                .HasColumnName("ALB_EMAIL")
                .HasMaxLength(50);
        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(pk => pk.Id);
        }

        protected override void ConfigurarChavesEstrangeiras()
        {
            //Ainda não foi implementado
        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("ALB_ALBUNS");
        }
    }
}
