using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APIWebDB.BaseDados.Models;

public partial class ApidbContext : DbContext
{
    public ApidbContext()
    {
    }

    public ApidbContext(DbContextOptions<ApidbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbCliente> TbClientes { get; set; }

    public virtual DbSet<TbEndereco> TbEnderecos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=apidb;Username=postgres;Password=admin");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbCliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_tb_clientes");

            entity.ToTable("tb_clientes");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Alteradoem)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("alteradoem");
            entity.Property(e => e.Criadoem)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("criadoem");
            entity.Property(e => e.Documento)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("documento");
            entity.Property(e => e.Nascimento)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("nascimento");
            entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("nome");
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .HasColumnName("telefone");
            entity.Property(e => e.Tipodoc)
                .HasComment("0 - CPF\\n1 - CNPJ\\n2 - Passaporte\\n3 - CNH\\n99 - Outros")
                .HasColumnName("tipodoc");
        });

        modelBuilder.Entity<TbEndereco>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_tb_enderecos");

            entity.ToTable("tb_enderecos");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Bairro)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("bairro");
            entity.Property(e => e.Cep).HasColumnName("cep");
            entity.Property(e => e.Cidade)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("cidade");
            entity.Property(e => e.Clienteid).HasColumnName("clienteid");
            entity.Property(e => e.Complemento)
                .HasMaxLength(255)
                .HasColumnName("complemento");
            entity.Property(e => e.Logradouro)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("logradouro");
            entity.Property(e => e.Numero)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("numero");
            entity.Property(e => e.Status)
                .HasDefaultValue(1)
                .HasComment("0 - inativo\\n1 - ativo")
                .HasColumnName("status");
            entity.Property(e => e.Uf)
                .IsRequired()
                .HasMaxLength(2)
                .HasColumnName("uf");

            entity.HasOne(d => d.Cliente).WithMany(p => p.TbEnderecos)
                .HasForeignKey(d => d.Clienteid)
                .HasConstraintName("fk_tb_enderecos_tb_clientes");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
