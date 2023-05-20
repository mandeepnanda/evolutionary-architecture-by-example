﻿// <auto-generated />

#nullable disable

namespace EvolutionaryArchitecture.Fitnet.Contracts.Data.Database.Migrations;

using EvolutionaryArchitecture.Fitnet.Contracts.Data.Database;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

[DbContext(typeof(ContractsPersistence))]
[Migration("20230322141428_Create_Contracts_Table")]
partial class Create_Contracts_Table
{
    /// <inheritdoc />
    protected override void BuildTargetModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder
            .HasDefaultSchema("Contracts")
            .HasAnnotation("ProductVersion", "7.0.0")
            .HasAnnotation("Relational:MaxIdentifierLength", 63);

        NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

        modelBuilder.Entity("EvolutionaryArchitecture.Fitnet.Contracts.Data.Contract", b =>
        {
            b.Property<Guid>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("uuid");

            b.HasKey("Id");

            b.ToTable("Contracts", "Contracts");
        });
#pragma warning restore 612, 618
    }
}