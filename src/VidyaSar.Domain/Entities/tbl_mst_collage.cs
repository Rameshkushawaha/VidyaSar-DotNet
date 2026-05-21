using System;
using System.Collections.Generic;

namespace VidyaSar.Domain.Entities;

public partial class tbl_mst_collage
{
    public long cl_col_id { get; set; }

    public string? cl_col_name { get; set; }

    public string? bitisactive { get; set; }

    public string? makercode { get; set; }

    public DateTime? updatedatetime { get; set; }

    public string? approvedby { get; set; }

    public string? course_offered { get; set; }

    public string? address { get; set; }

    public long? city { get; set; }

    public long? state { get; set; }

    public string? country { get; set; }

    public string? phone { get; set; }

    public string? emailid { get; set; }

    public string? clg_name { get; set; }

    public long? institution_id { get; set; }

    public long? university_id { get; set; }

    public decimal? gr_id { get; set; }

    public string? pincode { get; set; }

    public string? website { get; set; }

    public string? facebookurl { get; set; }

    public string? googleurl { get; set; }

    public string? twitterurl { get; set; }

    public string? websitelayout { get; set; }

    public string? masterpage { get; set; }

    public string? isdemoinstitute { get; set; }

    public string? marksheetalias { get; set; }

    public string? admission { get; set; }

    public string? preadmissionpage { get; set; }

    public string? enquirypage { get; set; }

    public string? tallycompanyname { get; set; }

    public bool isfree { get; set; }

    public string? mobilesenderid { get; set; }

    public bool? ismultilingual { get; set; }

    public string? schoolcode { get; set; }

    public string? affiliationno { get; set; }

    public string? university_col_code { get; set; }

    public bool? isuniversitydriven { get; set; }

    public decimal? parent_institute { get; set; }

    public decimal? serviceproviderid { get; set; }

    public string? tcheaderimagepath { get; set; }

    public string? feecertificateheaderpath { get; set; }

    public string? collegelogopath { get; set; }

    public string? backgroundpath { get; set; }

    public string? mobilelogopath { get; set; }

    public virtual tbl_mst_city? cityNavigation { get; set; }

    public virtual ICollection<degree_master> degree_masters { get; set; } = new List<degree_master>();

    public virtual ICollection<depat_master> depat_masters { get; set; } = new List<depat_master>();

    public virtual ICollection<session_master> session_masters { get; set; } = new List<session_master>();

    public virtual tbl_mst_state? stateNavigation { get; set; }

    public virtual ICollection<tbl_admission_configuration> tbl_admission_configurations { get; set; } = new List<tbl_admission_configuration>();

    public virtual ICollection<tbl_admissionconfiguration> tbl_admissionconfigurations { get; set; } = new List<tbl_admissionconfiguration>();

    public virtual ICollection<tbl_feesconfiguration> tbl_feesconfigurations { get; set; } = new List<tbl_feesconfiguration>();

    public virtual ICollection<tbl_mst_col_branch> tbl_mst_col_branches { get; set; } = new List<tbl_mst_col_branch>();

    public virtual ICollection<tbl_subjectgroup> tbl_subjectgroups { get; set; } = new List<tbl_subjectgroup>();

    public virtual ICollection<UserProfile> userprofiles { get; set; } = new List<UserProfile>();
}
