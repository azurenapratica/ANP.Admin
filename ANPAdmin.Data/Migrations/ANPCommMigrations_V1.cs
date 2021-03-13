using FluentMigrator;

namespace ANPAdmin.UI.Migrations
{
    [Migration(1)]
    public class ANPCommMigrations_V1 : Migration
    {
        public override void Up()
        {
            Create.Table("Usuario")
            .WithColumn("Id").AsInt32().Identity().NotNullable().PrimaryKey()
            .WithColumn("Nome").AsAnsiString(255).NotNullable()
            .WithColumn("Email").AsAnsiString(255).NotNullable()
            .WithColumn("Senha").AsAnsiString(255).NotNullable()
            .WithColumn("Ativo").AsBoolean().NotNullable();

            InserirUsuariosCargaInicial();
        }
        public override void Down()
        {
        }

        public void InserirUsuariosCargaInicial()
        {
            Insert.IntoTable("Usuario").Row(new
            {
                Nome = "Milton Camara",
                Email = "suporte@azurenapratica.com",
                Senha = "teste@123",
                Ativo = true
            });
        }
    }
}
