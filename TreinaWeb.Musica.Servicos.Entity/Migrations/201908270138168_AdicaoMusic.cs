namespace TreinaWeb.Musica.Servicos.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicaoMusic : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MUS_MUSICAS",
                c => new
                    {
                        MUS_ID = c.Long(nullable: false, identity: true),
                        MUS_NOME = c.String(nullable: false, maxLength: 50),
                        ALB_ALBUM = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MUS_ID)
                .ForeignKey("dbo.ALB_ALBUNS", t => t.ALB_ALBUM, cascadeDelete: true)
                .Index(t => t.ALB_ALBUM);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MUS_MUSICAS", "ALB_ALBUM", "dbo.ALB_ALBUNS");
            DropIndex("dbo.MUS_MUSICAS", new[] { "ALB_ALBUM" });
            DropTable("dbo.MUS_MUSICAS");
        }
    }
}
