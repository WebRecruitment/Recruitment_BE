﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebRecruitment.Infrastructure;

#nullable disable

namespace WebRecruitment.Infrastructure.Migrations
{
    [DbContext(typeof(TuyendungContext))]
    partial class TuyendungContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebRecruitment.Domain.Entity.Account", b =>
                {
                    b.Property<Guid>("Accountid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("accountid");

                    b.Property<string>("Address")
                        .HasMaxLength(2147483646)
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("address");

                    b.Property<string>("Bio")
                        .HasMaxLength(2147483646)
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("bio");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("date")
                        .HasColumnName("birthday");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(2147483646)
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("firstName");

                    b.Property<string>("Gender")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("gender");

                    b.Property<string>("HashPassword")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("hashPassword");

                    b.Property<string>("Image")
                        .HasMaxLength(2147483646)
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("image");

                    b.Property<string>("Language")
                        .HasMaxLength(2147483646)
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("language");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(2147483646)
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("lastName");

                    b.Property<string>("Nationality")
                        .HasMaxLength(2147483646)
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nationality");

                    b.Property<int>("Phone")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("phone");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("role");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("status");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("username");

                    b.HasKey("Accountid");

                    b.HasIndex(new[] { "Email" }, "UQ__Account__AB6E6164F3C8BD9A")
                        .IsUnique();

                    b.HasIndex(new[] { "Username" }, "UQ__Account__F3DBC57293F3B493")
                        .IsUnique();

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("WebRecruitment.Domain.Entity.Admin", b =>
                {
                    b.Property<Guid>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("adminId");

                    b.Property<Guid>("Accountid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("accountid");

                    b.HasKey("AdminId");

                    b.HasIndex("Accountid");

                    b.ToTable("Admin", (string)null);
                });

            modelBuilder.Entity("WebRecruitment.Domain.Entity.Candidate", b =>
                {
                    b.Property<Guid>("CandidateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("candidateId");

                    b.Property<Guid>("Accountid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("accountid");

                    b.HasKey("CandidateId");

                    b.HasIndex("Accountid");

                    b.ToTable("Candidate", (string)null);
                });

            modelBuilder.Entity("WebRecruitment.Domain.Entity.Company", b =>
                {
                    b.Property<Guid>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("companyId");

                    b.Property<Guid?>("Accountid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("accountid");

                    b.Property<string>("Benefits")
                        .HasMaxLength(2147483646)
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("benefits");

                    b.Property<int>("ContactNumber")
                        .HasColumnType("int")
                        .HasColumnName("contactNumber");

                    b.Property<string>("Description")
                        .HasMaxLength(2147483646)
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<DateTime?>("FoundingYear")
                        .HasColumnType("date")
                        .HasColumnName("foundingYear");

                    b.Property<string>("Industry")
                        .HasMaxLength(2147483646)
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("industry");

                    b.Property<string>("Logo")
                        .HasMaxLength(2147483646)
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("logo");

                    b.Property<string>("NameCompany")
                        .IsRequired()
                        .HasMaxLength(2147483646)
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("nameCompany");

                    b.Property<int?>("Size")
                        .HasColumnType("int")
                        .HasColumnName("size");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(2147483646)
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("status");

                    b.Property<string>("Website")
                        .HasMaxLength(2147483646)
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("website");

                    b.HasKey("CompanyId");

                    b.HasIndex("Accountid");

                    b.ToTable("Company", (string)null);
                });

            modelBuilder.Entity("WebRecruitment.Domain.Entity.Cv", b =>
                {
                    b.Property<Guid>("CvId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("cvID");

                    b.Property<Guid?>("CandidateId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("candidateId");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("date")
                        .HasColumnName("creationDate");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2147483646)
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(2147483646)
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("status");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(2147483646)
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("title");

                    b.Property<string>("UrlFile")
                        .IsRequired()
                        .HasMaxLength(2147483646)
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("urlFile");

                    b.HasKey("CvId");

                    b.HasIndex("CandidateId");

                    b.ToTable("CV", (string)null);
                });

            modelBuilder.Entity("WebRecruitment.Domain.Entity.Event", b =>
                {
                    b.Property<Guid>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("eventId");

                    b.Property<Guid>("CandidateId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("candidateId");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("companyId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2147483646)
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("description");

                    b.Property<DateTime>("EndEvent")
                        .HasColumnType("date")
                        .HasColumnName("endEvent");

                    b.Property<string>("Img")
                        .IsRequired()
                        .HasMaxLength(2147483646)
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("img");

                    b.Property<DateTime>("StartEvent")
                        .HasColumnType("date")
                        .HasColumnName("startEvent");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(2147483646)
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("status");

                    b.HasKey("EventId");

                    b.HasIndex("CandidateId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Event", (string)null);
                });

            modelBuilder.Entity("WebRecruitment.Domain.Entity.Hr", b =>
                {
                    b.Property<Guid>("HrId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("hrId");

                    b.Property<Guid>("Accountid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("accountid");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("companyId");

                    b.Property<string>("NameHr")
                        .IsRequired()
                        .HasMaxLength(2147483646)
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("nameHr");

                    b.Property<Guid?>("PositionId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("positionId");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("status");

                    b.HasKey("HrId");

                    b.HasIndex("Accountid");

                    b.HasIndex("CompanyId");

                    b.HasIndex("PositionId");

                    b.ToTable("HR", (string)null);
                });

            modelBuilder.Entity("WebRecruitment.Domain.Entity.Interviewer", b =>
                {
                    b.Property<Guid>("InterviewerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("interviewerId");

                    b.Property<Guid>("Accountid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("accountid");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("companyId");

                    b.Property<string>("NameInterviewer")
                        .IsRequired()
                        .HasMaxLength(2147483646)
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("nameInterviewer");

                    b.Property<Guid?>("PositionId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("positionId");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("status");

                    b.HasKey("InterviewerId");

                    b.HasIndex("Accountid");

                    b.HasIndex("CompanyId");

                    b.HasIndex("PositionId");

                    b.ToTable("Interviewer", (string)null);
                });

            modelBuilder.Entity("WebRecruitment.Domain.Entity.Job", b =>
                {
                    b.Property<Guid>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("jobId");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("companyId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2147483646)
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("NameSkill")
                        .IsRequired()
                        .HasMaxLength(2147483646)
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("nameSkill");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("status");

                    b.HasKey("JobId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Job", (string)null);
                });

            modelBuilder.Entity("WebRecruitment.Domain.Entity.Meeting", b =>
                {
                    b.Property<Guid>("MeetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("meetID");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("date")
                        .HasColumnName("endTime");

                    b.Property<Guid>("HrId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("hrId");

                    b.Property<Guid>("InterviewerId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("interviewerId");

                    b.Property<string>("LinkMeet")
                        .IsRequired()
                        .HasMaxLength(2147483646)
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("linkMeet");

                    b.Property<Guid>("OperationId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("operationId");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("date")
                        .HasColumnName("startTime");

                    b.HasKey("MeetId")
                        .HasName("PK__Meeting__0ED7DF1BCFB2BFA1");

                    b.HasIndex("HrId");

                    b.HasIndex("InterviewerId");

                    b.HasIndex("OperationId");

                    b.ToTable("Meeting", (string)null);
                });

            modelBuilder.Entity("WebRecruitment.Domain.Entity.Operation", b =>
                {
                    b.Property<Guid>("OperationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("operationId");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("companyId");

                    b.Property<Guid?>("CvId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("cvID");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date")
                        .HasColumnName("date");

                    b.Property<Guid>("HrId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("hrId");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("postId");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("status");

                    b.HasKey("OperationId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CvId");

                    b.HasIndex("HrId");

                    b.HasIndex("PostId");

                    b.ToTable("Operation", (string)null);
                });

            modelBuilder.Entity("WebRecruitment.Domain.Entity.Position", b =>
                {
                    b.Property<Guid>("PositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("positionId");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("companyId");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("date")
                        .HasColumnName("createDate");

                    b.Property<string>("NamePosition")
                        .IsRequired()
                        .HasMaxLength(2147483646)
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("namePosition");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("status");

                    b.HasKey("PositionId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Position", (string)null);
                });

            modelBuilder.Entity("WebRecruitment.Domain.Entity.Post", b =>
                {
                    b.Property<Guid>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("postId");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("companyId");

                    b.Property<string>("EmploymentType")
                        .IsRequired()
                        .HasMaxLength(2147483646)
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("employmentType");

                    b.Property<DateTime>("ExpiredDate")
                        .HasColumnType("date")
                        .HasColumnName("expiredDate");

                    b.Property<Guid>("HrId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("hrId");

                    b.Property<Guid>("JobId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("jobId");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(2147483646)
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("location");

                    b.Property<DateTime>("PeriodDate")
                        .HasColumnType("date")
                        .HasColumnName("periodDate");

                    b.Property<string>("Requirements")
                        .IsRequired()
                        .HasMaxLength(2147483646)
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("requirements");

                    b.Property<double>("Salary")
                        .HasColumnType("float")
                        .HasColumnName("salary");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("status");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(2147483646)
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("title");

                    b.HasKey("PostId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("HrId");

                    b.HasIndex("JobId");

                    b.ToTable("Post", (string)null);
                });

            modelBuilder.Entity("WebRecruitment.Domain.Entity.PostVersion", b =>
                {
                    b.Property<Guid>("Version")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("version");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("postId");

                    b.Property<float>("numberVersion")
                        .HasColumnType("real");

                    b.HasKey("Version", "PostId")
                        .HasName("PK__Post_ver__C4650E75752995FF");

                    b.HasIndex("PostId");

                    b.ToTable("Post_version", (string)null);
                });

            modelBuilder.Entity("WebRecruitment.Domain.Entity.Admin", b =>
                {
                    b.HasOne("WebRecruitment.Domain.Entity.Account", "Account")
                        .WithMany("Admins")
                        .HasForeignKey("Accountid")
                        .IsRequired()
                        .HasConstraintName("FK__Admin__accountid__3E52440B");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("WebRecruitment.Domain.Entity.Candidate", b =>
                {
                    b.HasOne("WebRecruitment.Domain.Entity.Account", "Account")
                        .WithMany("Candidates")
                        .HasForeignKey("Accountid")
                        .IsRequired()
                        .HasConstraintName("FK__Candidate__accou__412EB0B6");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("WebRecruitment.Domain.Entity.Company", b =>
                {
                    b.HasOne("WebRecruitment.Domain.Entity.Account", "Account")
                        .WithMany("Companies")
                        .HasForeignKey("Accountid")
                        .HasConstraintName("FK__Company__account__3B75D760");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("WebRecruitment.Domain.Entity.Cv", b =>
                {
                    b.HasOne("WebRecruitment.Domain.Entity.Candidate", "Candidate")
                        .WithMany("Cvs")
                        .HasForeignKey("CandidateId")
                        .HasConstraintName("FK__CV__candidateId__52593CB8");

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("WebRecruitment.Domain.Entity.Event", b =>
                {
                    b.HasOne("WebRecruitment.Domain.Entity.Candidate", "Candidate")
                        .WithMany("Events")
                        .HasForeignKey("CandidateId")
                        .IsRequired()
                        .HasConstraintName("FK__Event__candidate__4F7CD00D");

                    b.HasOne("WebRecruitment.Domain.Entity.Company", "Company")
                        .WithMany("Events")
                        .HasForeignKey("CompanyId")
                        .IsRequired()
                        .HasConstraintName("FK__Event__companyId__4E88ABD4");

                    b.Navigation("Candidate");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("WebRecruitment.Domain.Entity.Hr", b =>
                {
                    b.HasOne("WebRecruitment.Domain.Entity.Account", "Account")
                        .WithMany("Hrs")
                        .HasForeignKey("Accountid")
                        .IsRequired()
                        .HasConstraintName("FK__HR__accountid__5629CD9C");

                    b.HasOne("WebRecruitment.Domain.Entity.Company", "Company")
                        .WithMany("Hrs")
                        .HasForeignKey("CompanyId")
                        .IsRequired()
                        .HasConstraintName("FK__HR__companyId__571DF1D5");

                    b.HasOne("WebRecruitment.Domain.Entity.Position", "Position")
                        .WithMany("Hrs")
                        .HasForeignKey("PositionId")
                        .HasConstraintName("FK__HR__positionId__5535A963");

                    b.Navigation("Account");

                    b.Navigation("Company");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("WebRecruitment.Domain.Entity.Interviewer", b =>
                {
                    b.HasOne("WebRecruitment.Domain.Entity.Account", "Account")
                        .WithMany("Interviewers")
                        .HasForeignKey("Accountid")
                        .IsRequired()
                        .HasConstraintName("FK__Interview__accou__47DBAE45");

                    b.HasOne("WebRecruitment.Domain.Entity.Company", "Company")
                        .WithMany("Interviewers")
                        .HasForeignKey("CompanyId")
                        .IsRequired()
                        .HasConstraintName("FK__Interview__compa__48CFD27E");

                    b.HasOne("WebRecruitment.Domain.Entity.Position", "Position")
                        .WithMany("Interviewers")
                        .HasForeignKey("PositionId")
                        .HasConstraintName("FK__Interview__posit__46E78A0C");

                    b.Navigation("Account");

                    b.Navigation("Company");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("WebRecruitment.Domain.Entity.Job", b =>
                {
                    b.HasOne("WebRecruitment.Domain.Entity.Company", "Company")
                        .WithMany("Jobs")
                        .HasForeignKey("CompanyId")
                        .HasConstraintName("FK__Job__companyId__4BAC3F29");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("WebRecruitment.Domain.Entity.Meeting", b =>
                {
                    b.HasOne("WebRecruitment.Domain.Entity.Hr", "Hr")
                        .WithMany("Meetings")
                        .HasForeignKey("HrId")
                        .IsRequired()
                        .HasConstraintName("FK__Meeting__hrId__693CA210");

                    b.HasOne("WebRecruitment.Domain.Entity.Interviewer", "Interviewer")
                        .WithMany("Meetings")
                        .HasForeignKey("InterviewerId")
                        .IsRequired()
                        .HasConstraintName("FK__Meeting__intervi__68487DD7");

                    b.HasOne("WebRecruitment.Domain.Entity.Operation", "Operation")
                        .WithMany("Meetings")
                        .HasForeignKey("OperationId")
                        .IsRequired()
                        .HasConstraintName("FK__Meeting__operati__6754599E");

                    b.Navigation("Hr");

                    b.Navigation("Interviewer");

                    b.Navigation("Operation");
                });

            modelBuilder.Entity("WebRecruitment.Domain.Entity.Operation", b =>
                {
                    b.HasOne("WebRecruitment.Domain.Entity.Company", "Company")
                        .WithMany("Operations")
                        .HasForeignKey("CompanyId")
                        .IsRequired()
                        .HasConstraintName("FK__Operation__compa__6383C8BA");

                    b.HasOne("WebRecruitment.Domain.Entity.Cv", "Cv")
                        .WithMany("Operations")
                        .HasForeignKey("CvId")
                        .HasConstraintName("FK__Operation__cvID__619B8048");

                    b.HasOne("WebRecruitment.Domain.Entity.Hr", "Hr")
                        .WithMany("Operations")
                        .HasForeignKey("HrId")
                        .IsRequired()
                        .HasConstraintName("FK__Operation__hrId__6477ECF3");

                    b.HasOne("WebRecruitment.Domain.Entity.Post", "Post")
                        .WithMany("Operations")
                        .HasForeignKey("PostId")
                        .IsRequired()
                        .HasConstraintName("FK__Operation__postI__628FA481");

                    b.Navigation("Company");

                    b.Navigation("Cv");

                    b.Navigation("Hr");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("WebRecruitment.Domain.Entity.Position", b =>
                {
                    b.HasOne("WebRecruitment.Domain.Entity.Company", "Company")
                        .WithMany("Positions")
                        .HasForeignKey("CompanyId")
                        .IsRequired()
                        .HasConstraintName("FK__Position__compan__440B1D61");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("WebRecruitment.Domain.Entity.Post", b =>
                {
                    b.HasOne("WebRecruitment.Domain.Entity.Company", "Company")
                        .WithMany("Posts")
                        .HasForeignKey("CompanyId")
                        .IsRequired()
                        .HasConstraintName("FK__Post__companyId__59FA5E80");

                    b.HasOne("WebRecruitment.Domain.Entity.Hr", "Hr")
                        .WithMany("Posts")
                        .HasForeignKey("HrId")
                        .IsRequired()
                        .HasConstraintName("FK__Post__hrId__5BE2A6F2");

                    b.HasOne("WebRecruitment.Domain.Entity.Job", "Job")
                        .WithMany("Posts")
                        .HasForeignKey("JobId")
                        .IsRequired()
                        .HasConstraintName("FK__Post__jobId__5AEE82B9");

                    b.Navigation("Company");

                    b.Navigation("Hr");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("WebRecruitment.Domain.Entity.PostVersion", b =>
                {
                    b.HasOne("WebRecruitment.Domain.Entity.Post", "Post")
                        .WithMany("PostVersions")
                        .HasForeignKey("PostId")
                        .IsRequired()
                        .HasConstraintName("FK__Post_vers__postI__5EBF139D");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("WebRecruitment.Domain.Entity.Account", b =>
                {
                    b.Navigation("Admins");

                    b.Navigation("Candidates");

                    b.Navigation("Companies");

                    b.Navigation("Hrs");

                    b.Navigation("Interviewers");
                });

            modelBuilder.Entity("WebRecruitment.Domain.Entity.Candidate", b =>
                {
                    b.Navigation("Cvs");

                    b.Navigation("Events");
                });

            modelBuilder.Entity("WebRecruitment.Domain.Entity.Company", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("Hrs");

                    b.Navigation("Interviewers");

                    b.Navigation("Jobs");

                    b.Navigation("Operations");

                    b.Navigation("Positions");

                    b.Navigation("Posts");
                });

            modelBuilder.Entity("WebRecruitment.Domain.Entity.Cv", b =>
                {
                    b.Navigation("Operations");
                });

            modelBuilder.Entity("WebRecruitment.Domain.Entity.Hr", b =>
                {
                    b.Navigation("Meetings");

                    b.Navigation("Operations");

                    b.Navigation("Posts");
                });

            modelBuilder.Entity("WebRecruitment.Domain.Entity.Interviewer", b =>
                {
                    b.Navigation("Meetings");
                });

            modelBuilder.Entity("WebRecruitment.Domain.Entity.Job", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("WebRecruitment.Domain.Entity.Operation", b =>
                {
                    b.Navigation("Meetings");
                });

            modelBuilder.Entity("WebRecruitment.Domain.Entity.Position", b =>
                {
                    b.Navigation("Hrs");

                    b.Navigation("Interviewers");
                });

            modelBuilder.Entity("WebRecruitment.Domain.Entity.Post", b =>
                {
                    b.Navigation("Operations");

                    b.Navigation("PostVersions");
                });
#pragma warning restore 612, 618
        }
    }
}
