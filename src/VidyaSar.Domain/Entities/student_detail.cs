using System;
using System.Collections.Generic;

namespace VidyaSar.Domain.Entities;

public partial class student_detail
{
    public string roll_no { get; set; } = null!;

    public decimal? student_id { get; set; }

    public string? scholar_no { get; set; }

    public long? br_branch_id { get; set; }

    public string? full_name { get; set; }

    public DateTime? date_of_birth { get; set; }

    public string? father_name { get; set; }

    public string? mother_name { get; set; }

    public string? perm_address { get; set; }

    public string? email_id { get; set; }

    public decimal blood_groups { get; set; }

    public string? bus_facility_req { get; set; }

    public string? hostal_fac_req { get; set; }

    public string? additional_information { get; set; }

    public long? cl_col_id { get; set; }

    public string? student_image_path { get; set; }

    public string? graduation { get; set; }

    public string? degreetype { get; set; }

    public string? stud_mobile { get; set; }

    public string? stud_bike_n0 { get; set; }

    public string? year_diploma { get; set; }

    public DateTime? updatedatetime { get; set; }

    public string? makercode { get; set; }

    public long? current_semester { get; set; }

    public string? xsemester { get; set; }

    public string? lab_groups { get; set; }

    public long? session_id { get; set; }

    public decimal? status_id { get; set; }

    public string? landlinenumber { get; set; }

    public decimal? studentgender { get; set; }

    public long? studentdegree { get; set; }

    public decimal? orderno { get; set; }

    public string? oldrollno { get; set; }

    public string? section { get; set; }

    public string? service_type { get; set; }

    public string? adhar_card_no { get; set; }

    public string? character_certificate { get; set; }

    public bool? provisionadmission { get; set; }

    public long? admissionyear { get; set; }

    public long? leavingyear { get; set; }

    public long? admittedinbranch { get; set; }

    public DateOnly? dateofadmission { get; set; }

    public long? admittedsemid { get; set; }

    public string? firstname { get; set; }

    public string? middlename { get; set; }

    public string? lastname { get; set; }

    public bool? admissioncancelled { get; set; }

    public string? admissioncancelremark { get; set; }

    public decimal? subjectgroupid { get; set; }

    public bool? studentleft { get; set; }

    public string? panno { get; set; }

    public string? gr_no { get; set; }

    public decimal? admission_status { get; set; }

    public decimal? apaarid { get; set; }

    public decimal? sessionfees { get; set; }

    public decimal student_cast { get; set; }

    public virtual session_master? admissionyearNavigation { get; set; }

    public virtual tbl_mst_col_branch? admittedinbranchNavigation { get; set; }

    public virtual tbl_mst_semister_detail? admittedsem { get; set; }

    public virtual category_master blood_groupsNavigation { get; set; } = null!;

    public virtual tbl_mst_col_branch? br_branch { get; set; }

    public virtual tbl_mst_semister_detail? current_semesterNavigation { get; set; }

    public virtual session_master? leavingyearNavigation { get; set; }

    public virtual session_master? session { get; set; }

    public virtual category_master student_castNavigation { get; set; } = null!;

    public virtual degree_master? studentdegreeNavigation { get; set; }

    public virtual category_master? studentgenderNavigation { get; set; }

    public virtual tbl_subjectgroup? subjectgroup { get; set; }
}
