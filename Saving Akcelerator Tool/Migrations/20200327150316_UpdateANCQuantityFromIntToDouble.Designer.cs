﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Saving_Accelerator_Tool.Data;

namespace Saving_Accelerator_Tool.Migrations
{
    [DbContext(typeof(DataBaseConnectionContext))]
    [Migration("20200327150316_UpdateANCQuantityFromIntToDouble")]
    partial class UpdateANCQuantityFromIntToDouble
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Saving_Accelerator_Tool.Model.ANCMonthlyDB", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ANC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("ANCMonthly");
                });

            modelBuilder.Entity("Saving_Accelerator_Tool.Model.ANCRevisionDB", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ANC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<string>("Revision")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("ANCRevision");
                });

            modelBuilder.Entity("Saving_Accelerator_Tool.Model.Action.ANCChangeDB", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ANC_Calculation")
                        .HasColumnType("bit");

                    b.Property<int>("ActionID")
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<double>("Calculation")
                        .HasColumnType("float");

                    b.Property<string>("ChangeBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ChangeTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("Delta")
                        .HasColumnType("float");

                    b.Property<double>("Estimation")
                        .HasColumnType("float");

                    b.Property<string>("New_ANC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("New_IDCO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("New_Quant_ANC")
                        .HasColumnType("float");

                    b.Property<double>("New_STK")
                        .HasColumnType("float");

                    b.Property<string>("Next_ANC_1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Next_ANC_2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OLD_IDCO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Old_ANC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Old_Quant_ANC")
                        .HasColumnType("float");

                    b.Property<double>("Old_STK")
                        .HasColumnType("float");

                    b.Property<double>("Percent")
                        .HasColumnType("float");

                    b.Property<int>("Rev")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("ANCChange");
                });

            modelBuilder.Entity("Saving_Accelerator_Tool.Model.Action.BU_Carry_DB", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActionID")
                        .HasColumnType("int");

                    b.Property<string>("Component")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ECCC")
                        .HasColumnType("float");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<double>("Saving")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("BU_Carry");
                });

            modelBuilder.Entity("Saving_Accelerator_Tool.Model.Action.BU_DB", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActionID")
                        .HasColumnType("int");

                    b.Property<string>("Component")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ECCC")
                        .HasColumnType("float");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<double>("Saving")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("BU");
                });

            modelBuilder.Entity("Saving_Accelerator_Tool.Model.Action.CalculationMassDB", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActionID")
                        .HasColumnType("int");

                    b.Property<int>("ActionIDOriginal")
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("ChangeBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ChangeTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("D45_BI")
                        .HasColumnType("bit");

                    b.Property<bool>("D45_FI")
                        .HasColumnType("bit");

                    b.Property<bool>("D45_FS")
                        .HasColumnType("bit");

                    b.Property<bool>("D45_FSBU")
                        .HasColumnType("bit");

                    b.Property<bool>("DMD_BI")
                        .HasColumnType("bit");

                    b.Property<bool>("DMD_FI")
                        .HasColumnType("bit");

                    b.Property<bool>("DMD_FS")
                        .HasColumnType("bit");

                    b.Property<bool>("DMD_FSBU")
                        .HasColumnType("bit");

                    b.Property<int>("Rev")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("CalculationMass");
                });

            modelBuilder.Entity("Saving_Accelerator_Tool.Model.Action.EA1_Carry_DB", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActionID")
                        .HasColumnType("int");

                    b.Property<string>("Component")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ECCC")
                        .HasColumnType("float");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<double>("Saving")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("EA1_Carry");
                });

            modelBuilder.Entity("Saving_Accelerator_Tool.Model.Action.EA1_DB", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActionID")
                        .HasColumnType("int");

                    b.Property<string>("Component")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ECCC")
                        .HasColumnType("float");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<double>("Saving")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("EA1");
                });

            modelBuilder.Entity("Saving_Accelerator_Tool.Model.Action.EA2_Carry_DB", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActionID")
                        .HasColumnType("int");

                    b.Property<string>("Component")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ECCC")
                        .HasColumnType("float");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<double>("Saving")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("EA2_Carry");
                });

            modelBuilder.Entity("Saving_Accelerator_Tool.Model.Action.EA2_DB", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActionID")
                        .HasColumnType("int");

                    b.Property<string>("Component")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ECCC")
                        .HasColumnType("float");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<double>("Saving")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("EA2");
                });

            modelBuilder.Entity("Saving_Accelerator_Tool.Model.Action.EA3_Carry_DB", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActionID")
                        .HasColumnType("int");

                    b.Property<string>("Component")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ECCC")
                        .HasColumnType("float");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<double>("Saving")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("EA3_Carry");
                });

            modelBuilder.Entity("Saving_Accelerator_Tool.Model.Action.EA3_DB", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActionID")
                        .HasColumnType("int");

                    b.Property<string>("Component")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ECCC")
                        .HasColumnType("float");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<double>("Saving")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("EA3");
                });

            modelBuilder.Entity("Saving_Accelerator_Tool.Model.Action.EA4_Carry_DB", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActionID")
                        .HasColumnType("int");

                    b.Property<string>("Component")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ECCC")
                        .HasColumnType("float");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<double>("Saving")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("EA4_Carry");
                });

            modelBuilder.Entity("Saving_Accelerator_Tool.Model.Action.EA4_DB", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActionID")
                        .HasColumnType("int");

                    b.Property<string>("Component")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ECCC")
                        .HasColumnType("float");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<double>("Saving")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("EA4");
                });

            modelBuilder.Entity("Saving_Accelerator_Tool.Model.Action.PNCListDB", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActionID")
                        .HasColumnType("int");

                    b.Property<int>("ActionIDOriginal")
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("ChangeBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ChangeTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("List")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rev")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("PNCList");
                });

            modelBuilder.Entity("Saving_Accelerator_Tool.Model.Action.PNCSpecialDB", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActionID")
                        .HasColumnType("int");

                    b.Property<int>("ActionIDOriginal")
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("ChangeBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ChangeTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("Delta")
                        .HasColumnType("float");

                    b.Property<double>("ECCC")
                        .HasColumnType("float");

                    b.Property<string>("New_ANC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("New_IDCO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("New_Quant_ANC")
                        .HasColumnType("float");

                    b.Property<double>("New_STK")
                        .HasColumnType("float");

                    b.Property<string>("Old_ANC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Old_IDCO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Old_Quant_ANC")
                        .HasColumnType("float");

                    b.Property<double>("Old_STK")
                        .HasColumnType("float");

                    b.Property<string>("PNC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rev")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("PNCSpecial");
                });

            modelBuilder.Entity("Saving_Accelerator_Tool.Model.ActionDB", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ANC")
                        .HasColumnType("bit");

                    b.Property<bool>("ANCSpec")
                        .HasColumnType("bit");

                    b.Property<bool>("ANC_Calc")
                        .HasColumnType("bit");

                    b.Property<int>("ActionIDOriginal")
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("ChangeBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ChangeTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Devision")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ECCC")
                        .HasColumnType("bit");

                    b.Property<bool>("ECCC_PNCSpec")
                        .HasColumnType("bit");

                    b.Property<double>("ECCC_Sec")
                        .HasColumnType("float");

                    b.Property<string>("Factory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Group")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Group_Calc")
                        .HasColumnType("bit");

                    b.Property<bool>("Installation_BI")
                        .HasColumnType("bit");

                    b.Property<bool>("Installation_FI")
                        .HasColumnType("bit");

                    b.Property<bool>("Installation_FS")
                        .HasColumnType("bit");

                    b.Property<bool>("Installation_FSBU")
                        .HasColumnType("bit");

                    b.Property<string>("Leader")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MonthStart")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PNC")
                        .HasColumnType("bit");

                    b.Property<bool>("PNCSpec")
                        .HasColumnType("bit");

                    b.Property<double>("PNCSpec_Estimation")
                        .HasColumnType("float");

                    b.Property<double>("PercentQauntity")
                        .HasColumnType("float");

                    b.Property<bool>("Platform_D45")
                        .HasColumnType("bit");

                    b.Property<bool>("Platform_DMD")
                        .HasColumnType("bit");

                    b.Property<int>("Rev")
                        .HasColumnType("int");

                    b.Property<int>("StartYear")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusYear")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Action");
                });

            modelBuilder.Entity("Saving_Accelerator_Tool.Model.FrozenDB", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("April")
                        .HasColumnType("int");

                    b.Property<int>("August")
                        .HasColumnType("int");

                    b.Property<int>("BU")
                        .HasColumnType("int");

                    b.Property<int>("December")
                        .HasColumnType("int");

                    b.Property<int>("EA1")
                        .HasColumnType("int");

                    b.Property<int>("EA2")
                        .HasColumnType("int");

                    b.Property<int>("EA3")
                        .HasColumnType("int");

                    b.Property<int>("ElectronicApprove")
                        .HasColumnType("int");

                    b.Property<int>("February")
                        .HasColumnType("int");

                    b.Property<int>("January")
                        .HasColumnType("int");

                    b.Property<int>("July")
                        .HasColumnType("int");

                    b.Property<int>("June")
                        .HasColumnType("int");

                    b.Property<int>("March")
                        .HasColumnType("int");

                    b.Property<int>("May")
                        .HasColumnType("int");

                    b.Property<int>("MechanicApprove")
                        .HasColumnType("int");

                    b.Property<int>("NVRApprove")
                        .HasColumnType("int");

                    b.Property<int>("November")
                        .HasColumnType("int");

                    b.Property<int>("October")
                        .HasColumnType("int");

                    b.Property<int>("September")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Frozen");
                });

            modelBuilder.Entity("Saving_Accelerator_Tool.Model.PNCMonthlyDB", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<string>("PNC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("PNCMonthly");
                });

            modelBuilder.Entity("Saving_Accelerator_Tool.Model.PNCRevisionDB", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<string>("PNC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Revision")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("PNCRevision");
                });

            modelBuilder.Entity("Saving_Accelerator_Tool.Model.STKDB", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ANC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IDCO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("STK");
                });

            modelBuilder.Entity("Saving_Accelerator_Tool.Model.SumQuantityDB", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Installation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<string>("Platform")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("SumQuantity");
                });

            modelBuilder.Entity("Saving_Accelerator_Tool.Model.SumRevisionQuantityDB", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Installation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<string>("Platform")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Revision")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("SumRevisionQuantity");
                });

            modelBuilder.Entity("Saving_Accelerator_Tool.Model.Targets_CoinsDB", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("DM_BU")
                        .HasColumnType("float");

                    b.Property<double>("DM_EA1")
                        .HasColumnType("float");

                    b.Property<double>("DM_EA2")
                        .HasColumnType("float");

                    b.Property<double>("DM_EA3")
                        .HasColumnType("float");

                    b.Property<double>("DM_EA4")
                        .HasColumnType("float");

                    b.Property<double>("ECCC")
                        .HasColumnType("float");

                    b.Property<double>("Electronic_BU")
                        .HasColumnType("float");

                    b.Property<double>("Electronic_EA1")
                        .HasColumnType("float");

                    b.Property<double>("Electronic_EA2")
                        .HasColumnType("float");

                    b.Property<double>("Electronic_EA3")
                        .HasColumnType("float");

                    b.Property<double>("Electronic_EA4")
                        .HasColumnType("float");

                    b.Property<double>("Euro")
                        .HasColumnType("float");

                    b.Property<double>("Mechanic_BU")
                        .HasColumnType("float");

                    b.Property<double>("Mechanic_EA1")
                        .HasColumnType("float");

                    b.Property<double>("Mechanic_EA2")
                        .HasColumnType("float");

                    b.Property<double>("Mechanic_EA3")
                        .HasColumnType("float");

                    b.Property<double>("Mechanic_EA4")
                        .HasColumnType("float");

                    b.Property<double>("NVR_BU")
                        .HasColumnType("float");

                    b.Property<double>("NVR_EA1")
                        .HasColumnType("float");

                    b.Property<double>("NVR_EA2")
                        .HasColumnType("float");

                    b.Property<double>("NVR_EA3")
                        .HasColumnType("float");

                    b.Property<double>("NVR_EA4")
                        .HasColumnType("float");

                    b.Property<double>("PC_BU")
                        .HasColumnType("float");

                    b.Property<double>("PC_EA1")
                        .HasColumnType("float");

                    b.Property<double>("PC_EA2")
                        .HasColumnType("float");

                    b.Property<double>("PC_EA3")
                        .HasColumnType("float");

                    b.Property<double>("PC_EA4")
                        .HasColumnType("float");

                    b.Property<double>("SEK")
                        .HasColumnType("float");

                    b.Property<double>("USD")
                        .HasColumnType("float");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Targets_Coins");
                });

            modelBuilder.Entity("Saving_Accelerator_Tool.Model.UserDB", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ActionEle")
                        .HasColumnType("bit");

                    b.Property<bool>("ActionMech")
                        .HasColumnType("bit");

                    b.Property<bool>("ActionNVR")
                        .HasColumnType("bit");

                    b.Property<bool>("ActionTab")
                        .HasColumnType("bit");

                    b.Property<bool>("AdminTab")
                        .HasColumnType("bit");

                    b.Property<bool>("ElectronicApprove")
                        .HasColumnType("bit");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("MechanicApprove")
                        .HasColumnType("bit");

                    b.Property<bool>("NVRApprove")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PCApprove")
                        .HasColumnType("bit");

                    b.Property<bool>("PlatformTab")
                        .HasColumnType("bit");

                    b.Property<bool>("QuantityTab")
                        .HasColumnType("bit");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("STKTab")
                        .HasColumnType("bit");

                    b.Property<bool>("StatisticTab")
                        .HasColumnType("bit");

                    b.Property<bool>("SummaryTab")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
