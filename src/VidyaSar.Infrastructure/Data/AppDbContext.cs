using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using VidyaSar.Domain.Entities;

namespace VidyaSar.Infrastructure.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<category_master> category_masters { get; set; }

    public virtual DbSet<category_table> category_tables { get; set; }

    public virtual DbSet<col_rolemaster> col_rolemasters { get; set; }

    public virtual DbSet<degree_master> degree_masters { get; set; }

    public virtual DbSet<depat_master> depat_masters { get; set; }

    public virtual DbSet<service_provider> service_providers { get; set; }

    public virtual DbSet<session_master> session_masters { get; set; }

    public virtual DbSet<student_detail> student_details { get; set; }

    public virtual DbSet<tbl_academic_configuration> tbl_academic_configurations { get; set; }

    public virtual DbSet<tbl_admission_configuration> tbl_admission_configurations { get; set; }

    public virtual DbSet<tbl_admissionconfiguration> tbl_admissionconfigurations { get; set; }

    public virtual DbSet<tbl_configuration> tbl_configurations { get; set; }

    public virtual DbSet<tbl_designation_master> tbl_designation_masters { get; set; }

    public virtual DbSet<tbl_exam_configuration> tbl_exam_configurations { get; set; }

    public virtual DbSet<tbl_fees_configuration> tbl_fees_configurations { get; set; }

    public virtual DbSet<tbl_feesconfiguration> tbl_feesconfigurations { get; set; }

    public virtual DbSet<tbl_icard_configuration> tbl_icard_configurations { get; set; }

    public virtual DbSet<tbl_leave_configuration> tbl_leave_configurations { get; set; }

    public virtual DbSet<tbl_library_configuration> tbl_library_configurations { get; set; }

    public virtual DbSet<tbl_mobile_menu_new> tbl_mobile_menu_news { get; set; }

    public virtual DbSet<tbl_mst_city> tbl_mst_cities { get; set; }

    public virtual DbSet<tbl_mst_col_branch> tbl_mst_col_branches { get; set; }

    public virtual DbSet<tbl_mst_col_group> tbl_mst_col_groups { get; set; }

    public virtual DbSet<tbl_mst_col_university> tbl_mst_col_universities { get; set; }

    public virtual DbSet<tbl_mst_collage> tbl_mst_collages { get; set; }

    public virtual DbSet<tbl_mst_semister_detail> tbl_mst_semister_details { get; set; }

    public virtual DbSet<tbl_mst_state> tbl_mst_states { get; set; }

    public virtual DbSet<tbl_notification_configuration> tbl_notification_configurations { get; set; }

    public virtual DbSet<tbl_standardlibrary_bookbank_configuration> tbl_standardlibrary_bookbank_configurations { get; set; }

    public virtual DbSet<tbl_standardlibrary_configuration> tbl_standardlibrary_configurations { get; set; }

    public virtual DbSet<tbl_subjectgroup> tbl_subjectgroups { get; set; }

    public virtual DbSet<UserProfile> userprofiles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("auth", "aal_level", new[] { "aal1", "aal2", "aal3" })
            .HasPostgresEnum("auth", "code_challenge_method", new[] { "s256", "plain" })
            .HasPostgresEnum("auth", "factor_status", new[] { "unverified", "verified" })
            .HasPostgresEnum("auth", "factor_type", new[] { "totp", "webauthn", "phone" })
            .HasPostgresEnum("auth", "oauth_authorization_status", new[] { "pending", "approved", "denied", "expired" })
            .HasPostgresEnum("auth", "oauth_client_type", new[] { "public", "confidential" })
            .HasPostgresEnum("auth", "oauth_registration_type", new[] { "dynamic", "manual" })
            .HasPostgresEnum("auth", "oauth_response_type", new[] { "code" })
            .HasPostgresEnum("auth", "one_time_token_type", new[] { "confirmation_token", "reauthentication_token", "recovery_token", "email_change_token_new", "email_change_token_current", "phone_change_token" })
            .HasPostgresEnum("realtime", "action", new[] { "INSERT", "UPDATE", "DELETE", "TRUNCATE", "ERROR" })
            .HasPostgresEnum("realtime", "equality_op", new[] { "eq", "neq", "lt", "lte", "gt", "gte", "in" })
            .HasPostgresEnum("storage", "buckettype", new[] { "STANDARD", "ANALYTICS", "VECTOR" })
            .HasPostgresExtension("extensions", "pg_stat_statements")
            .HasPostgresExtension("extensions", "pgcrypto")
            .HasPostgresExtension("extensions", "uuid-ossp")
            .HasPostgresExtension("vault", "supabase_vault");

        modelBuilder.Entity<category_master>(entity =>
        {
            entity.HasKey(e => e.category_id).HasName("category_master_pkey");

            entity.ToTable("category_master");

            entity.HasIndex(e => e.category_description, "ix_category_description");

            entity.Property(e => e.category_id).HasPrecision(18);
            entity.Property(e => e.abbr).HasMaxLength(50);
            entity.Property(e => e.category_description).HasMaxLength(100);
            entity.Property(e => e.category_name).HasMaxLength(100);
            entity.Property(e => e.categoryid).HasPrecision(18);
            entity.Property(e => e.cl_col_id).HasPrecision(18);
            entity.Property(e => e.makercode).HasMaxLength(100);
            entity.Property(e => e.updatedatetime).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.category).WithMany(p => p.category_masters)
                .HasForeignKey(d => d.categoryid)
                .HasConstraintName("fk_category_master_categorytable");
        });

        modelBuilder.Entity<category_table>(entity =>
        {
            entity.HasKey(e => e.categoryid).HasName("category_table_pkey");

            entity.ToTable("category_table");

            entity.Property(e => e.categoryid).HasPrecision(18);
            entity.Property(e => e.category_name).HasMaxLength(100);
            entity.Property(e => e.cl_col_id).HasPrecision(18);
            entity.Property(e => e.makercode).HasMaxLength(256);
            entity.Property(e => e.updatedatetime).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<col_rolemaster>(entity =>
        {
            entity.HasKey(e => e.role).HasName("col_rolemaster_pkey");

            entity.ToTable("col_rolemaster");

            entity.Property(e => e.role).ValueGeneratedNever();
            entity.Property(e => e.cl_col_id).HasPrecision(18);
            entity.Property(e => e.role_name).HasMaxLength(100);
        });

        modelBuilder.Entity<degree_master>(entity =>
        {
            entity.HasKey(e => e.category_id).HasName("degree_master_pkey");

            entity.ToTable("degree_master");

            entity.Property(e => e.category_description).HasMaxLength(100);
            entity.Property(e => e.col_fulladdress).HasMaxLength(2000);
            entity.Property(e => e.degree_name).HasMaxLength(2000);
            entity.Property(e => e.issuebooklimit).HasMaxLength(10);
            entity.Property(e => e.makercode).HasMaxLength(100);
            entity.Property(e => e.parent_degree).HasDefaultValue(0L);
            entity.Property(e => e.updatedatetime).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.cl_col).WithMany(p => p.degree_masters)
                .HasForeignKey(d => d.cl_col_id)
                .HasConstraintName("degree_master_tbl_mst_collage_fk");

            entity.HasOne(d => d.parent_degreeNavigation).WithMany(p => p.Inverseparent_degreeNavigation)
                .HasForeignKey(d => d.parent_degree)
                .HasConstraintName("degree_master_degree_master_fk");
        });

        modelBuilder.Entity<depat_master>(entity =>
        {
            entity.HasKey(e => e.dept_id).HasName("depat_master_pkey");

            entity.ToTable("depat_master");

            entity.Property(e => e.bitisactive).HasMaxLength(10);
            entity.Property(e => e.dept_head).HasMaxLength(100);
            entity.Property(e => e.dept_name).HasMaxLength(500);
            entity.Property(e => e.isteachingdept).HasDefaultValue(false);

            entity.HasOne(d => d.cl_col).WithMany(p => p.depat_masters)
                .HasForeignKey(d => d.cl_col_id)
                .HasConstraintName("depat_master_tbl_mst_collage_fk");

            entity.HasOne(d => d.dept_headNavigation).WithMany(p => p.depat_masters)
                .HasForeignKey(d => d.dept_head)
                .HasConstraintName("fk_depat_master_head");
        });

        modelBuilder.Entity<service_provider>(entity =>
        {
            entity.HasKey(e => e.id).HasName("service_provider_pkey");

            entity.ToTable("service_provider");

            entity.Property(e => e.address).HasMaxLength(500);
            entity.Property(e => e.bank_logo_path).HasMaxLength(500);
            entity.Property(e => e.bankname).HasMaxLength(100);
            entity.Property(e => e.cookiespolicy).HasMaxLength(100);
            entity.Property(e => e.developedby).HasMaxLength(200);
            entity.Property(e => e.email).HasMaxLength(100);
            entity.Property(e => e.grievencesredressal).HasMaxLength(100);
            entity.Property(e => e.language).HasMaxLength(100);
            entity.Property(e => e.mobileno).HasMaxLength(100);
            entity.Property(e => e.policypath).HasMaxLength(200);
            entity.Property(e => e.poweredby).HasMaxLength(200);
            entity.Property(e => e.productname).HasMaxLength(200);
            entity.Property(e => e.refundpolicy).HasMaxLength(100);
            entity.Property(e => e.service_provider_name).HasMaxLength(200);
            entity.Property(e => e.serviceproviderlogo).HasMaxLength(200);
            entity.Property(e => e.termconditionpath).HasMaxLength(200);
            entity.Property(e => e.whatsappno).HasMaxLength(100);
        });

        modelBuilder.Entity<session_master>(entity =>
        {
            entity.HasKey(e => e.session_id).HasName("session_master_pkey");

            entity.ToTable("session_master");

            entity.Property(e => e.admissiondate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.session_end_date).HasColumnType("timestamp without time zone");
            entity.Property(e => e.session_name).HasMaxLength(255);
            entity.Property(e => e.session_start_date).HasColumnType("timestamp without time zone");
            entity.Property(e => e.sessionyear).HasMaxLength(255);

            entity.HasOne(d => d.cl_col).WithMany(p => p.session_masters)
                .HasForeignKey(d => d.cl_col_id)
                .HasConstraintName("session_master_tbl_mst_collage_fk");
        });

        modelBuilder.Entity<student_detail>(entity =>
        {
            entity.HasKey(e => e.roll_no).HasName("student_details_pkey");

            entity.HasIndex(e => e.cl_col_id, "ix_student_details_cl_col_id");

            entity.HasIndex(e => e.session_id, "ix_student_details_session_id");

            entity.HasIndex(e => e.studentdegree, "ix_student_details_studentdegree");

            entity.Property(e => e.roll_no).HasMaxLength(50);
            entity.Property(e => e.additional_information).HasMaxLength(50);
            entity.Property(e => e.adhar_card_no).HasMaxLength(200);
            entity.Property(e => e.admission_status).HasPrecision(18);
            entity.Property(e => e.admissioncancelled).HasDefaultValue(false);
            entity.Property(e => e.admissioncancelremark).HasMaxLength(500);
            entity.Property(e => e.apaarid)
                .HasPrecision(38)
                .HasDefaultValueSql("0");
            entity.Property(e => e.blood_groups).HasPrecision(18);
            entity.Property(e => e.bus_facility_req).HasMaxLength(50);
            entity.Property(e => e.character_certificate).HasMaxLength(200);
            entity.Property(e => e.date_of_birth).HasColumnType("timestamp without time zone");
            entity.Property(e => e.degreetype).HasMaxLength(10);
            entity.Property(e => e.email_id).HasMaxLength(200);
            entity.Property(e => e.firstname).HasMaxLength(500);
            entity.Property(e => e.gr_no).HasMaxLength(100);
            entity.Property(e => e.hostal_fac_req).HasMaxLength(50);
            entity.Property(e => e.lab_groups)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.landlinenumber).HasMaxLength(250);
            entity.Property(e => e.lastname).HasMaxLength(500);
            entity.Property(e => e.makercode).HasMaxLength(250);
            entity.Property(e => e.middlename).HasMaxLength(500);
            entity.Property(e => e.oldrollno).HasMaxLength(500);
            entity.Property(e => e.orderno).HasPrecision(18);
            entity.Property(e => e.panno).HasMaxLength(100);
            entity.Property(e => e.scholar_no).HasMaxLength(500);
            entity.Property(e => e.section).HasMaxLength(100);
            entity.Property(e => e.service_type).HasMaxLength(50);
            entity.Property(e => e.sessionfees).HasPrecision(38);
            entity.Property(e => e.status_id).HasPrecision(18);
            entity.Property(e => e.stud_bike_n0).HasMaxLength(250);
            entity.Property(e => e.stud_mobile).HasMaxLength(250);
            entity.Property(e => e.student_id).HasPrecision(18);
            entity.Property(e => e.student_image_path).HasMaxLength(100);
            entity.Property(e => e.studentgender).HasPrecision(18);
            entity.Property(e => e.studentleft).HasDefaultValue(false);
            entity.Property(e => e.subjectgroupid).HasPrecision(18);
            entity.Property(e => e.updatedatetime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.xsemester)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.year_diploma).HasMaxLength(250);

            entity.HasOne(d => d.admissionyearNavigation).WithMany(p => p.student_detailadmissionyearNavigations)
                .HasForeignKey(d => d.admissionyear)
                .HasConstraintName("student_details_session_master_fk_1");

            entity.HasOne(d => d.admittedinbranchNavigation).WithMany(p => p.student_detailadmittedinbranchNavigations)
                .HasForeignKey(d => d.admittedinbranch)
                .HasConstraintName("student_details_tbl_mst_col_branch_fk_1");

            entity.HasOne(d => d.admittedsem).WithMany(p => p.student_detailadmittedsems)
                .HasForeignKey(d => d.admittedsemid)
                .HasConstraintName("student_details_tbl_mst_semister_details_fk_1");

            entity.HasOne(d => d.blood_groupsNavigation).WithMany(p => p.student_detailblood_groupsNavigations)
                .HasForeignKey(d => d.blood_groups)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_student_details_blood_groups");

            entity.HasOne(d => d.br_branch).WithMany(p => p.student_detailbr_branches)
                .HasForeignKey(d => d.br_branch_id)
                .HasConstraintName("student_details_tbl_mst_col_branch_fk");

            entity.HasOne(d => d.current_semesterNavigation).WithMany(p => p.student_detailcurrent_semesterNavigations)
                .HasForeignKey(d => d.current_semester)
                .HasConstraintName("student_details_tbl_mst_semister_details_fk");

            entity.HasOne(d => d.leavingyearNavigation).WithMany(p => p.student_detailleavingyearNavigations)
                .HasForeignKey(d => d.leavingyear)
                .HasConstraintName("student_details_session_master_fk_2");

            entity.HasOne(d => d.session).WithMany(p => p.student_detailsessions)
                .HasForeignKey(d => d.session_id)
                .HasConstraintName("student_details_session_master_fk");

            entity.HasOne(d => d.student_castNavigation).WithMany(p => p.student_detailstudent_castNavigations)
                .HasForeignKey(d => d.student_cast)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("student_details_category_master_fk");

            entity.HasOne(d => d.studentdegreeNavigation).WithMany(p => p.student_details)
                .HasForeignKey(d => d.studentdegree)
                .HasConstraintName("student_details_degree_master_fk");

            entity.HasOne(d => d.studentgenderNavigation).WithMany(p => p.student_detailstudentgenderNavigations)
                .HasForeignKey(d => d.studentgender)
                .HasConstraintName("fk_student_details_gender");

            entity.HasOne(d => d.subjectgroup).WithMany(p => p.student_details)
                .HasForeignKey(d => d.subjectgroupid)
                .HasConstraintName("fk_student_details_subjectgroup");
        });

        modelBuilder.Entity<tbl_academic_configuration>(entity =>
        {
            entity.HasKey(e => e.id).HasName("tbl_academic_configuration_pkey");

            entity.ToTable("tbl_academic_configuration");

            entity.Property(e => e.isdepartmentwiselecture).HasDefaultValue(false);
            entity.Property(e => e.isenggteachingplan).HasDefaultValue(false);
            entity.Property(e => e.issubjectgroup).HasDefaultValue(false);
            entity.Property(e => e.restrictroomallocation).HasDefaultValue(false);
            entity.Property(e => e.showstudentleavingoption).HasDefaultValue(false);
        });

        modelBuilder.Entity<tbl_admission_configuration>(entity =>
        {
            entity.HasKey(e => e.id).HasName("tbl_admission_configuration_pkey");

            entity.ToTable("tbl_admission_configuration");

            entity.Property(e => e.ishodwisebranch).HasDefaultValue(false);
            entity.Property(e => e.ismailid).HasMaxLength(200);
            entity.Property(e => e.issaveadmissionenquiry).HasDefaultValue(false);
            entity.Property(e => e.isshowadmissionfromstudentdetails).HasDefaultValue(false);
            entity.Property(e => e.percentage).HasMaxLength(255);

            entity.HasOne(d => d.college).WithMany(p => p.tbl_admission_configurations)
                .HasForeignKey(d => d.collegeid)
                .HasConstraintName("tbl_admission_configuration_tbl_mst_collage_fk");
        });

        modelBuilder.Entity<tbl_admissionconfiguration>(entity =>
        {
            entity.HasKey(e => e.relation_id).HasName("tbl_admissionconfiguration_pkey");

            entity.ToTable("tbl_admissionconfiguration");

            entity.Property(e => e.admissionform).HasPrecision(18);

            entity.HasOne(d => d.college).WithMany(p => p.tbl_admissionconfigurations)
                .HasForeignKey(d => d.collegeid)
                .HasConstraintName("tbl_admissionconfiguration_tbl_mst_collage_fk");
        });

        modelBuilder.Entity<tbl_configuration>(entity =>
        {
            entity.HasKey(e => e.id).HasName("tbl_configuration_pkey");

            entity.ToTable("tbl_configuration");

            entity.Property(e => e.collegeid).HasPrecision(18);
            entity.Property(e => e.contactperson).HasMaxLength(300);
            entity.Property(e => e.language).HasMaxLength(50);
            entity.Property(e => e.showhrms).HasDefaultValue(false);
            entity.Property(e => e.tallypath).HasMaxLength(500);
        });

        modelBuilder.Entity<tbl_designation_master>(entity =>
        {
            entity.HasKey(e => e.relation_id).HasName("tbl_designation_master_pkey");

            entity.ToTable("tbl_designation_master");

            entity.Property(e => e.designation).HasMaxLength(200);
        });

        modelBuilder.Entity<tbl_exam_configuration>(entity =>
        {
            entity.HasKey(e => e.id).HasName("tbl_exam_configuration_pkey");

            entity.ToTable("tbl_exam_configuration");

            entity.Property(e => e.allowedsubjects).HasPrecision(38);
            entity.Property(e => e.allowteachertoentermarks).HasDefaultValue(1);
            entity.Property(e => e.collegeid).HasPrecision(18);
            entity.Property(e => e.examlatefineafterdays).HasPrecision(18);
            entity.Property(e => e.examseatflag).HasDefaultValue(0);
            entity.Property(e => e.examsuperlatefineafterdays).HasPrecision(18);
            entity.Property(e => e.examtype).HasDefaultValue(0);
            entity.Property(e => e.inward_extension).HasMaxLength(255);
            entity.Property(e => e.inwardextension).HasMaxLength(500);
            entity.Property(e => e.istimetablewise).HasDefaultValue(false);
            entity.Property(e => e.marksheet_top_header).HasMaxLength(255);
            entity.Property(e => e.marksheettophader).HasMaxLength(500);
            entity.Property(e => e.maxinwardextension).HasPrecision(18);
            entity.Property(e => e.maxoutwardextension).HasPrecision(18);
            entity.Property(e => e.outward_extension).HasMaxLength(255);
            entity.Property(e => e.outwardextension).HasMaxLength(500);
        });

        modelBuilder.Entity<tbl_fees_configuration>(entity =>
        {
            entity.HasKey(e => e.id).HasName("tbl_fees_configuration_pkey");

            entity.ToTable("tbl_fees_configuration");

            entity.Property(e => e.admission_fee_head_name).HasMaxLength(255);
            entity.Property(e => e.admissionfeeheadname).HasMaxLength(500);
            entity.Property(e => e.bankregisteremail).HasMaxLength(100);
            entity.Property(e => e.bankregistermobile).HasMaxLength(10);
            entity.Property(e => e.bouncecharges).HasPrecision(18);
            entity.Property(e => e.collegeid).HasPrecision(18);
            entity.Property(e => e.email_password).HasMaxLength(255);
            entity.Property(e => e.emailpassword).HasMaxLength(200);
            entity.Property(e => e.encryptionrequestkey).HasMaxLength(50);
            entity.Property(e => e.encryptionresponsekey).HasMaxLength(50);
            entity.Property(e => e.isautoclearcheckdateapplybouncecharges).HasDefaultValue(false);
            entity.Property(e => e.isbusfeesnotcallculated).HasDefaultValue(false);
            entity.Property(e => e.isheadwisefees).HasDefaultValue(false);
            entity.Property(e => e.islatefeesamountper).HasDefaultValue(false);
            entity.Property(e => e.isoldfeescollection).HasDefaultValue(false);
            entity.Property(e => e.isrefund).HasDefaultValue(false);
            entity.Property(e => e.isrefundfeesnotcallculated).HasDefaultValue(false);
            entity.Property(e => e.latefeesamountperday).HasPrecision(18);
            entity.Property(e => e.latefeesamountpermonth).HasPrecision(38);
            entity.Property(e => e.latefeesapplicable).HasDefaultValue(false);
            entity.Property(e => e.latefeesfixamount).HasPrecision(18);
            entity.Property(e => e.ostagatewayhostname).HasMaxLength(150);
            entity.Property(e => e.payment_gateway_checksum_key).HasMaxLength(255);
            entity.Property(e => e.payment_gateway_merchantidkey).HasMaxLength(255);
            entity.Property(e => e.payment_gateway_return_url).HasMaxLength(255);
            entity.Property(e => e.payment_gateway_securityid).HasMaxLength(255);
            entity.Property(e => e.paymentgatewaychecksumkey)
                .HasMaxLength(100)
                .HasDefaultValueSql("''::character varying");
            entity.Property(e => e.paymentgatewayid).HasPrecision(18);
            entity.Property(e => e.paymentgatewaymerchantidkey)
                .HasMaxLength(100)
                .HasDefaultValueSql("''::character varying");
            entity.Property(e => e.paymentgatewayproductid).HasMaxLength(50);
            entity.Property(e => e.paymentgatewayrequestkey).HasMaxLength(50);
            entity.Property(e => e.paymentgatewayrequestsalt).HasMaxLength(50);
            entity.Property(e => e.paymentgatewayresponsekey).HasMaxLength(50);
            entity.Property(e => e.paymentgatewayresponsesalt).HasMaxLength(50);
            entity.Property(e => e.paymentgatewayreturnurl)
                .HasMaxLength(500)
                .HasDefaultValueSql("''::character varying");
            entity.Property(e => e.paymentgatewaysecurityid)
                .HasMaxLength(100)
                .HasDefaultValueSql("''::character varying");
            entity.Property(e => e.paymentgatewaytransactionpassword).HasMaxLength(50);
            entity.Property(e => e.paymentgatewayurl).HasMaxLength(300);
            entity.Property(e => e.paymentgatewayuserid).HasMaxLength(50);
            entity.Property(e => e.performancereportformate).HasPrecision(18);
            entity.Property(e => e.pgname).HasMaxLength(100);
            entity.Property(e => e.pgstartdate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.tokencreateddatetime).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<tbl_feesconfiguration>(entity =>
        {
            entity.HasKey(e => e.relationid).HasName("tbl_feesconfiguration_pkey");

            entity.ToTable("tbl_feesconfiguration");

            entity.Property(e => e.bouncecharges).HasPrecision(18);
            entity.Property(e => e.busfees).HasPrecision(18);
            entity.Property(e => e.canceladmissionhead).HasMaxLength(500);
            entity.Property(e => e.etectronicpaymentcharges).HasPrecision(18);
            entity.Property(e => e.excesshead).HasPrecision(18);
            entity.Property(e => e.fineamount).HasPrecision(18);
            entity.Property(e => e.finedays).HasPrecision(18);
            entity.Property(e => e.finetype).HasMaxLength(100);
            entity.Property(e => e.reevaluationhead).HasPrecision(18);
            entity.Property(e => e.salingfeeshead).HasPrecision(18);
            entity.Property(e => e.tallyintegration).HasDefaultValue(false);

            entity.HasOne(d => d.college).WithMany(p => p.tbl_feesconfigurations)
                .HasForeignKey(d => d.collegeid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbl_feesconfiguration_tbl_mst_collage_fk");
        });

        modelBuilder.Entity<tbl_icard_configuration>(entity =>
        {
            entity.HasKey(e => e.id).HasName("tbl_icard_configuration_pkey");

            entity.ToTable("tbl_icard_configuration");

            entity.Property(e => e.collegeid).HasPrecision(18);
            entity.Property(e => e.empicardbackground).HasMaxLength(200);
            entity.Property(e => e.empicardsign).HasMaxLength(200);
            entity.Property(e => e.employeeicardformat).HasPrecision(18);
            entity.Property(e => e.stuicardbackground).HasMaxLength(200);
            entity.Property(e => e.stuicardformat).HasPrecision(18);
            entity.Property(e => e.stuicardsign).HasMaxLength(200);
        });

        modelBuilder.Entity<tbl_leave_configuration>(entity =>
        {
            entity.HasKey(e => e.id).HasName("tbl_leave_configuration_pkey");

            entity.ToTable("tbl_leave_configuration");

            entity.Property(e => e.collegeid).HasPrecision(18);
            entity.Property(e => e.leaveapprovelautoforwarding).HasPrecision(18);
        });

        modelBuilder.Entity<tbl_library_configuration>(entity =>
        {
            entity.HasKey(e => e.id).HasName("tbl_library_configuration_pkey");

            entity.ToTable("tbl_library_configuration");

            entity.Property(e => e.bookbanklibraryfine).HasPrecision(18);
            entity.Property(e => e.bookissuemailtemplateid).HasPrecision(18);
            entity.Property(e => e.collegeid).HasPrecision(18);
            entity.Property(e => e.libraryfine).HasPrecision(18);
            entity.Property(e => e.maxfine).HasPrecision(18);
            entity.Property(e => e.nobookemp).HasPrecision(18);
            entity.Property(e => e.nobooks).HasPrecision(18);
            entity.Property(e => e.returndays).HasPrecision(18);
            entity.Property(e => e.returnempdays).HasPrecision(18);
        });

        modelBuilder.Entity<tbl_mobile_menu_new>(entity =>
        {
            entity.HasKey(e => e.relation_id).HasName("tbl_mobile_menu_new_pkey");

            entity.ToTable("tbl_mobile_menu_new");

            entity.Property(e => e.college_id).HasPrecision(18);
            entity.Property(e => e.featurename).HasMaxLength(200);
            entity.Property(e => e.featurenameicon).HasMaxLength(100);
            entity.Property(e => e.institutetype).HasPrecision(18);
            entity.Property(e => e.isdefault).HasMaxLength(100);
            entity.Property(e => e.linkdescription).HasMaxLength(100);
            entity.Property(e => e.orderno).HasPrecision(18);
            entity.Property(e => e.role_id).HasMaxLength(4);
        });

        modelBuilder.Entity<tbl_mst_city>(entity =>
        {
            entity.HasKey(e => e.relation_id).HasName("tbl_mst_city_pkey");

            entity.ToTable("tbl_mst_city");

            entity.Property(e => e.city_title).HasMaxLength(50);
            entity.Property(e => e.city_zipcode).HasMaxLength(6);
            entity.Property(e => e.created_by).HasPrecision(8);
            entity.Property(e => e.created_on).HasMaxLength(50);

            entity.HasOne(d => d.state).WithMany(p => p.tbl_mst_cities)
                .HasForeignKey(d => d.state_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbl_mst_city_tbl_mst_state_fk");
        });

        modelBuilder.Entity<tbl_mst_col_branch>(entity =>
        {
            entity.HasKey(e => e.br_branch_id).HasName("tbl_mst_col_branch_pkey");

            entity.ToTable("tbl_mst_col_branch");

            entity.HasIndex(e => e.br_branch_no, "ix_tbl_mst_col_branch_br_branch_no");

            entity.HasIndex(e => e.category_id, "ix_tbl_mst_col_branch_category_id");

            entity.Property(e => e.admissionformfee)
                .HasPrecision(18, 2)
                .HasDefaultValueSql("0.00");
            entity.Property(e => e.br_branch_name).HasMaxLength(500);
            entity.Property(e => e.br_branch_no).HasMaxLength(50);
            entity.Property(e => e.br_full_name).HasMaxLength(200);
            entity.Property(e => e.category_id).HasPrecision(18);
            entity.Property(e => e.course_type).HasMaxLength(200);
            entity.Property(e => e.daycare).HasDefaultValue(false);
            entity.Property(e => e.degree_type).HasMaxLength(50);
            entity.Property(e => e.hodid).HasMaxLength(100);
            entity.Property(e => e.makercode).HasMaxLength(50);
            entity.Property(e => e.parent_branch).HasDefaultValue(0L);
            entity.Property(e => e.remaining_seats).HasMaxLength(50);
            entity.Property(e => e.tallyparentname).HasMaxLength(500);
            entity.Property(e => e.updatedatetime).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.cl_col).WithMany(p => p.tbl_mst_col_branches)
                .HasForeignKey(d => d.cl_col_id)
                .HasConstraintName("tbl_mst_col_branch_tbl_mst_collage_fk");

            entity.HasOne(d => d.makercodeNavigation).WithMany(p => p.tbl_mst_col_branches)
                .HasForeignKey(d => d.makercode)
                .HasConstraintName("tbl_mst_col_branch_userprofile_fk");

            entity.HasOne(d => d.parent_branchNavigation).WithMany(p => p.Inverseparent_branchNavigation)
                .HasForeignKey(d => d.parent_branch)
                .HasConstraintName("tbl_mst_col_branch_tbl_mst_col_branch_fk");
        });

        modelBuilder.Entity<tbl_mst_col_group>(entity =>
        {
            entity.HasKey(e => e.gr_id).HasName("tbl_mst_col_group_pkey");

            entity.ToTable("tbl_mst_col_group");

            entity.Property(e => e.applestoreurl).HasMaxLength(255);
            entity.Property(e => e.entityid).HasDefaultValue(1L);
            entity.Property(e => e.facebookurl).HasMaxLength(255);
            entity.Property(e => e.googleplaystoreurl).HasMaxLength(255);
            entity.Property(e => e.googleurl).HasMaxLength(255);
            entity.Property(e => e.gr_name).HasMaxLength(255);
            entity.Property(e => e.gr_no).HasMaxLength(255);
            entity.Property(e => e.grouplogo).HasMaxLength(200);
            entity.Property(e => e.linkedinurl).HasMaxLength(255);
            entity.Property(e => e.logowidth).HasMaxLength(255);
            entity.Property(e => e.makercode).HasMaxLength(255);
            entity.Property(e => e.pinteresturl).HasMaxLength(255);
            entity.Property(e => e.twitterurl).HasMaxLength(255);
            entity.Property(e => e.updatedatetime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.url).HasMaxLength(255);
        });

        modelBuilder.Entity<tbl_mst_col_university>(entity =>
        {
            entity.HasKey(e => e.university_id).HasName("tbl_mst_col_university_pkey");

            entity.ToTable("tbl_mst_col_university");

            entity.Property(e => e.makercode).HasMaxLength(255);
            entity.Property(e => e.university_code).HasMaxLength(255);
            entity.Property(e => e.university_name).HasMaxLength(255);
            entity.Property(e => e.updatedatetime).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<tbl_mst_collage>(entity =>
        {
            entity.HasKey(e => e.cl_col_id).HasName("tbl_mst_collage_pkey");

            entity.ToTable("tbl_mst_collage");

            entity.Property(e => e.address).HasMaxLength(255);
            entity.Property(e => e.admission).HasMaxLength(300);
            entity.Property(e => e.affiliationno).HasMaxLength(255);
            entity.Property(e => e.approvedby).HasMaxLength(50);
            entity.Property(e => e.backgroundpath).HasMaxLength(300);
            entity.Property(e => e.bitisactive).HasMaxLength(10);
            entity.Property(e => e.cl_col_name).HasMaxLength(255);
            entity.Property(e => e.clg_name).HasMaxLength(400);
            entity.Property(e => e.collegelogopath).HasMaxLength(300);
            entity.Property(e => e.country).HasMaxLength(255);
            entity.Property(e => e.course_offered).HasMaxLength(4000);
            entity.Property(e => e.emailid).HasMaxLength(255);
            entity.Property(e => e.enquirypage).HasMaxLength(300);
            entity.Property(e => e.facebookurl).HasMaxLength(400);
            entity.Property(e => e.feecertificateheaderpath).HasMaxLength(300);
            entity.Property(e => e.googleurl).HasMaxLength(400);
            entity.Property(e => e.gr_id).HasPrecision(18);
            entity.Property(e => e.isdemoinstitute).HasMaxLength(2);
            entity.Property(e => e.isfree).HasDefaultValue(false);
            entity.Property(e => e.ismultilingual).HasDefaultValue(false);
            entity.Property(e => e.makercode).HasMaxLength(255);
            entity.Property(e => e.marksheetalias).HasMaxLength(255);
            entity.Property(e => e.masterpage).HasMaxLength(400);
            entity.Property(e => e.mobilelogopath).HasMaxLength(300);
            entity.Property(e => e.mobilesenderid)
                .HasMaxLength(100)
                .HasDefaultValueSql("''::character varying");
            entity.Property(e => e.parent_institute)
                .HasPrecision(38)
                .HasDefaultValueSql("0");
            entity.Property(e => e.phone).HasMaxLength(255);
            entity.Property(e => e.pincode).HasMaxLength(400);
            entity.Property(e => e.preadmissionpage).HasMaxLength(300);
            entity.Property(e => e.schoolcode).HasMaxLength(255);
            entity.Property(e => e.serviceproviderid).HasPrecision(38);
            entity.Property(e => e.tallycompanyname).HasMaxLength(250);
            entity.Property(e => e.tcheaderimagepath).HasMaxLength(300);
            entity.Property(e => e.twitterurl).HasMaxLength(400);
            entity.Property(e => e.university_col_code).HasMaxLength(200);
            entity.Property(e => e.updatedatetime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.website).HasMaxLength(255);
            entity.Property(e => e.websitelayout).HasMaxLength(400);

            entity.HasOne(d => d.cityNavigation).WithMany(p => p.tbl_mst_collages)
                .HasForeignKey(d => d.city)
                .HasConstraintName("tbl_mst_collage_tbl_mst_city_fk");

            entity.HasOne(d => d.stateNavigation).WithMany(p => p.tbl_mst_collages)
                .HasForeignKey(d => d.state)
                .HasConstraintName("tbl_mst_collage_tbl_mst_state_fk");
        });

        modelBuilder.Entity<tbl_mst_semister_detail>(entity =>
        {
            entity.HasKey(e => e.sm_sem_id).HasName("tbl_mst_semister_details_pkey");

            entity.HasIndex(e => e.sm_sem_id, "ix_tbl_mst_semister_details_sm_sem_id");

            entity.Property(e => e.bitevenodd)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.bitisactive)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.electivesittingarrangement).HasPrecision(18);
            entity.Property(e => e.isteacher).HasMaxLength(100);
            entity.Property(e => e.makercode).HasMaxLength(50);
            entity.Property(e => e.parent_semester)
                .HasPrecision(38)
                .HasDefaultValueSql("0");
            entity.Property(e => e.sm_sem_name).HasMaxLength(50);
            entity.Property(e => e.sm_sem_no).HasMaxLength(50);
            entity.Property(e => e.updatedatetime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.years).HasPrecision(18);

            entity.HasOne(d => d.br_branch).WithMany(p => p.tbl_mst_semister_details)
                .HasForeignKey(d => d.br_branch_id)
                .HasConstraintName("tbl_mst_semister_details_tbl_mst_col_branch_fk");

            entity.HasOne(d => d.isteacherNavigation).WithMany(p => p.tbl_mst_semister_details)
                .HasForeignKey(d => d.isteacher)
                .HasConstraintName("fk_tbl_mst_semister_details_userprofile");

            entity.HasOne(d => d.yearsNavigation).WithMany(p => p.tbl_mst_semister_details)
                .HasForeignKey(d => d.years)
                .HasConstraintName("fk_tbl_mst_semister_details_category_master");
        });

        modelBuilder.Entity<tbl_mst_state>(entity =>
        {
            entity.HasKey(e => e.relation_id).HasName("tbl_mst_state_pkey");

            entity.ToTable("tbl_mst_state");

            entity.Property(e => e.created_by).HasPrecision(8);
            entity.Property(e => e.created_on).HasMaxLength(50);
            entity.Property(e => e.state_title).HasMaxLength(50);
        });

        modelBuilder.Entity<tbl_notification_configuration>(entity =>
        {
            entity.HasKey(e => e.id).HasName("tbl_notification_configuration_pkey");

            entity.ToTable("tbl_notification_configuration");

            entity.Property(e => e.bulkattendanceinmobile).HasDefaultValue(false);
            entity.Property(e => e.collegeid).HasPrecision(18);
            entity.Property(e => e.feesduedayforalerts).HasPrecision(18);
            entity.Property(e => e.hidecalenderbeforday).HasPrecision(18);
            entity.Property(e => e.isstandardalerts).HasDefaultValue(false);
            entity.Property(e => e.isstandarddailydairy).HasDefaultValue(false);
            entity.Property(e => e.sendcopyofalertstoclassteacher).HasDefaultValue(false);
            entity.Property(e => e.sendcopyofalertstoprincipal).HasDefaultValue(false);
            entity.Property(e => e.textlimitnewsfeed).HasPrecision(18);
        });

        modelBuilder.Entity<tbl_standardlibrary_bookbank_configuration>(entity =>
        {
            entity.HasKey(e => e.relation_id).HasName("tbl_standardlibrary_bookbank_configuration_pkey");

            entity.ToTable("tbl_standardlibrary_bookbank_configuration");

            entity.Property(e => e.category_id).HasPrecision(18);
            entity.Property(e => e.library_id).HasPrecision(18);

            entity.HasOne(d => d.category).WithMany(p => p.tbl_standardlibrary_bookbank_configurations)
                .HasForeignKey(d => d.category_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tbl_standardlibrary_bookbank_configuration_category");
        });

        modelBuilder.Entity<tbl_standardlibrary_configuration>(entity =>
        {
            entity.HasKey(e => e.relation_id).HasName("tbl_standardlibrary_configuration_pkey");

            entity.ToTable("tbl_standardlibrary_configuration");

            entity.Property(e => e.checkoutduration_staff).HasPrecision(18);
            entity.Property(e => e.checkoutduration_student).HasPrecision(18);
            entity.Property(e => e.dailyfineamount)
                .HasPrecision(18)
                .HasDefaultValueSql("0");
            entity.Property(e => e.fineamountafter7days).HasPrecision(18);
            entity.Property(e => e.library_id).HasPrecision(18);
            entity.Property(e => e.maxcheckouts_staff).HasPrecision(18);
            entity.Property(e => e.maxcheckouts_student).HasPrecision(18);
            entity.Property(e => e.maxfinelimit)
                .HasPrecision(18)
                .HasDefaultValueSql("0");
            entity.Property(e => e.renewlimit_staff).HasPrecision(18);
            entity.Property(e => e.renewlimit_student).HasPrecision(18);

            entity.HasOne(d => d.degree).WithMany(p => p.tbl_standardlibrary_configurations)
                .HasForeignKey(d => d.degree_id)
                .HasConstraintName("tbl_standardlibrary_configuration_degree_master_fk");
        });

        modelBuilder.Entity<tbl_subjectgroup>(entity =>
        {
            entity.HasKey(e => e.relationid).HasName("tbl_subjectgroup_pkey");

            entity.ToTable("tbl_subjectgroup");

            entity.Property(e => e.relationid).HasDefaultValueSql("nextval('tbl_subjectgroup_relationid_seq'::regclass)");
            entity.Property(e => e.subjectname).HasMaxLength(500);
            entity.Property(e => e.tellyboucher).HasMaxLength(500);

            entity.HasOne(d => d.college).WithMany(p => p.tbl_subjectgroups)
                .HasForeignKey(d => d.collegeid)
                .HasConstraintName("tbl_subjectgroup_tbl_mst_collage_fk");
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.HasKey(e => e.userid).HasName("userprofile_pkey");

            entity.ToTable("userprofile");

            entity.HasIndex(e => e.active, "ix_userprofile_active");

            entity.HasIndex(e => e.branch_id, "ix_userprofile_branch_id");

            entity.HasIndex(e => e.cl_col_id, "ix_userprofile_cl_col_id");

            entity.HasIndex(e => e.name, "ix_userprofile_name");

            entity.Property(e => e.userid).HasMaxLength(255);
            entity.Property(e => e.attendflag).HasMaxLength(255);
            entity.Property(e => e.class_type).HasMaxLength(255);
            entity.Property(e => e.dob).HasColumnType("timestamp without time zone");
            entity.Property(e => e.em_org_code).HasMaxLength(255);
            entity.Property(e => e.emailid).HasMaxLength(255);
            entity.Property(e => e.empatt).HasMaxLength(255);
            entity.Property(e => e.encryptedpassword).HasMaxLength(255);
            entity.Property(e => e.fathername).HasMaxLength(255);
            entity.Property(e => e.firstname).HasMaxLength(255);
            entity.Property(e => e.flag).HasMaxLength(255);
            entity.Property(e => e.gender).HasMaxLength(255);
            entity.Property(e => e.imagepath).HasMaxLength(255);
            entity.Property(e => e.isfirstlogin).HasMaxLength(255);
            entity.Property(e => e.known_as).HasMaxLength(255);
            entity.Property(e => e.lastchangepassworddate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.lastlogin).HasColumnType("timestamp without time zone");
            entity.Property(e => e.lastname).HasMaxLength(255);
            entity.Property(e => e.makercode).HasMaxLength(255);
            entity.Property(e => e.makerdatetime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.middlename).HasMaxLength(255);
            entity.Property(e => e.name).HasMaxLength(255);
            entity.Property(e => e.oldpassword).HasMaxLength(255);
            entity.Property(e => e.password).HasMaxLength(255);
            entity.Property(e => e.punchid).HasMaxLength(255);
            entity.Property(e => e.qualifications).HasMaxLength(255);
            entity.Property(e => e.service_type).HasMaxLength(255);
            entity.Property(e => e.signaturepath).HasMaxLength(255);
            entity.Property(e => e.telno).HasMaxLength(255);
            entity.Property(e => e.title).HasMaxLength(255);
            entity.Property(e => e.tokenexpirydate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.tokenurl).HasMaxLength(255);

            entity.HasOne(d => d.branch).WithMany(p => p.userprofiles)
                .HasForeignKey(d => d.branch_id)
                .HasConstraintName("fk_userprofile_department");

            entity.HasOne(d => d.cl_col).WithMany(p => p.userprofiles)
                .HasForeignKey(d => d.cl_col_id)
                .HasConstraintName("fk_userprofile_collage");

            entity.HasOne(d => d.designation).WithMany(p => p.userprofiles)
                .HasForeignKey(d => d.designation_id)
                .HasConstraintName("fk_userprofile_designation");

            entity.HasOne(d => d.roleNavigation).WithMany(p => p.userprofiles)
                .HasForeignKey(d => d.role)
                .HasConstraintName("fk_userprofile_rolemaster");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
