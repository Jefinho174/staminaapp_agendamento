using System;
using FluentMigrator;

namespace StaminaAppAgendamento.Infra.Migrations
{
    [Migration(001)]
    public class Inicial : Migration
    {
        public override void Up()
        {
            Create.Table("Cliente")
                .WithColumn("Id").AsString(50).PrimaryKey().NotNullable()
                .WithColumn("PrimeiroNome").AsString()
                .WithColumn("SegundoNome").AsString()
                .WithColumn("TipoPessoa").AsInt16()
                .WithColumn("Documento").AsString()
                .WithColumn("Rg").AsString()
                .WithColumn("DataAtualizacao").AsDateTime().WithDefaultValue(DateTime.Now)
                .WithColumn("DataFinalizacao").AsDateTime().Nullable();

            Create.Index("idx_tipo_pessoa").OnTable("Cliente").OnColumn("TipoPessoa");

            Create.Table("ClienteEndereco")
                .WithColumn("Id").AsString(50).PrimaryKey().NotNullable()
                .WithColumn("ClienteId").AsString(20).NotNullable()
                .WithColumn("Cep").AsString()
                .WithColumn("Estado").AsString()
                .WithColumn("Cidade").AsString()
                .WithColumn("Bairro").AsString()
                .WithColumn("Rua").AsString()
                .WithColumn("Numero").AsString()
                .WithColumn("Complemento").AsString()
                .WithColumn("Observacao").AsString()
                .WithColumn("DataAtualizacao").AsDateTime().WithDefaultValue(DateTime.Now)
                .WithColumn("DataFinalizacao").AsDateTime().Nullable();
            
            Create.ForeignKey("fk_cliente_endereco_id_cliente_cliente_id")
			    .FromTable("ClienteEndereco").ForeignColumn("ClienteId")
			    .ToTable("Cliente").PrimaryColumn("Id")
                .OnDeleteOrUpdate(System.Data.Rule.Cascade);

            Create.Table("ClienteTelefone")
                .WithColumn("Id").AsString(50).PrimaryKey().NotNullable()
                .WithColumn("ClienteId").AsString(20).NotNullable()
                .WithColumn("Ddd").AsString()
                .WithColumn("Numero").AsString()
                .WithColumn("Observacao").AsString()
                .WithColumn("DataAtualizacao").AsDateTime().WithDefaultValue(DateTime.Now)
                .WithColumn("DataFinalizacao").AsDateTime().Nullable();

            Create.ForeignKey("fk_cliente_telefone_id_cliente_cliente_id")
			    .FromTable("ClienteTelefone").ForeignColumn("ClienteId")
			    .ToTable("Cliente").PrimaryColumn("Id")
                .OnDeleteOrUpdate(System.Data.Rule.Cascade);

            Create.Table("ClienteEmail")
                .WithColumn("Id").AsString(50).PrimaryKey().NotNullable()
                .WithColumn("ClienteId").AsString(20).NotNullable()
                .WithColumn("Descricao").AsString()
                .WithColumn("DataAtualizacao").AsDateTime().WithDefaultValue(DateTime.Now)
                .WithColumn("DataFinalizacao").AsDateTime().Nullable();

            Create.ForeignKey("fk_cliente_email_id_cliente_cliente_id")
			    .FromTable("ClienteEmail").ForeignColumn("ClienteId")
			    .ToTable("Cliente").PrimaryColumn("Id")
                .OnDeleteOrUpdate(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table("Cliente");
            Delete.Table("ClienteEndereco");
            Delete.Table("ClienteTelefone");
            Delete.Table("ClienteEmail");
        }
    }
}