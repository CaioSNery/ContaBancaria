using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContaBancaria.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContaBancaria.Data.Maps
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(c => c.Id);

            builder.OwnsOne(c => c.Nome, nome =>
            {
                nome.Property(n => n.PrimeiroNome)
                .HasColumnName("PrimeiroNome")
                .HasMaxLength(50)
                .IsRequired();

                nome.Property(n => n.Sobrenome)
                .HasColumnName("Sobrenome")
                .HasMaxLength(50)
                .IsRequired();

                nome.Ignore(c => c.Notifications);
            });

            builder.OwnsOne(c => c.Endereco, endereco =>
            {
                endereco.Property(e => e.Rua)
                .HasColumnName("Logradouro")
                .HasMaxLength(100)
                .IsRequired();

                endereco.Property(e => e.Cidade)
                .HasColumnName("Cidade")
                .HasMaxLength(50)
                .IsRequired();

                endereco.Property(e => e.Estado)
                .HasColumnName("Estado")
                .HasMaxLength(50)
                .IsRequired();

                endereco.Property(e => e.Cep)
                .HasColumnName("CEP")
                .HasMaxLength(20)
                .IsRequired();

                endereco.Ignore(c => c.Notifications);
            });

            builder.OwnsOne(c => c.Cpf, cpf =>
            {
                cpf.Property(c => c.Value)
                .HasColumnName("Cpf")
                .HasMaxLength(11)
                .IsRequired();

                cpf.Ignore(c => c.Notifications);
            });

            builder.OwnsOne(c => c.Senha, senha =>
            {
                senha.Property(s => s.Hash)
                .HasColumnName("Senha")
                .HasMaxLength(100)
                .IsRequired();

                senha.Ignore(c => c.Notifications);
            });

            builder.OwnsOne(c => c.Telefone, telefone =>
            {
                telefone.Property(t => t.Numero)
                .HasColumnName("Telefone")
                .HasMaxLength(15)
                .IsRequired();

                telefone.Ignore(c => c.Notifications);
            });

           


        }
    }
}