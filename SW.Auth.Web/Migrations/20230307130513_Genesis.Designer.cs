﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SW.Auth.Web;

#nullable disable

namespace SW.Auth.Web.Migrations
{
    [DbContext(typeof(SwDbContext))]
    [Migration("20230307130513_Genesis")]
    partial class Genesis
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("main")
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SW.Auth.Web.Domain.Account.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(32)
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Dictionary<string, string>>("AccountInfo")
                        .HasColumnType("jsonb")
                        .HasColumnName("account_info");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_on");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("FirstName")
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<DateTime>("LastLogin")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("last_login");

                    b.Property<string>("LastName")
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text")
                        .HasColumnName("modified_by");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("modified_on");

                    b.Property<string>("Phone")
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.HasKey("Id")
                        .HasName("pk_accounts");

                    b.HasIndex("CreatedOn")
                        .HasDatabaseName("ix_accounts_created_on");

                    b.HasIndex("Phone")
                        .IsUnique()
                        .HasDatabaseName("ix_accounts_phone");

                    b.ToTable("accounts", "main");
                });

            modelBuilder.Entity("SW.Auth.Web.Domain.Auth.AuthenticationToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid")
                        .HasColumnName("account_id");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_on");

                    b.Property<string>("Password")
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.HasKey("Id")
                        .HasName("pk_authentication_tokens");

                    b.HasIndex("AccountId")
                        .HasDatabaseName("ix_authentication_tokens_account_id");

                    b.HasIndex("CreatedOn")
                        .HasDatabaseName("ix_authentication_tokens_created_on");

                    b.ToTable("authentication_tokens", "main");
                });

            modelBuilder.Entity("SW.Auth.Web.Domain.Auth.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid")
                        .HasColumnName("account_id");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_on");

                    b.HasKey("Id")
                        .HasName("pk_refresh_tokens");

                    b.HasIndex("AccountId")
                        .HasDatabaseName("ix_refresh_tokens_account_id");

                    b.HasIndex("CreatedOn")
                        .HasDatabaseName("ix_refresh_tokens_created_on");

                    b.ToTable("refresh_tokens", "main");
                });

            modelBuilder.Entity("SW.Auth.Web.Domain.Auth.AuthenticationToken", b =>
                {
                    b.HasOne("SW.Auth.Web.Domain.Account.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_authentication_tokens_account_account_id");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("SW.Auth.Web.Domain.Auth.RefreshToken", b =>
                {
                    b.HasOne("SW.Auth.Web.Domain.Account.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_refresh_tokens_accounts_account_id");

                    b.Navigation("Account");
                });
#pragma warning restore 612, 618
        }
    }
}
