using System;
using System.Collections.Generic;

namespace VidyaSar.Domain.Entities;

public partial class tbl_admission_configuration
{
    public long id { get; set; }

    public bool? studentchangephoto { get; set; }

    public string? percentage { get; set; }

    public bool? isteacherspecific { get; set; }

    public int? nameordering { get; set; }

    public int? classrollnoordering { get; set; }

    public bool? issaveadmissionenquiry { get; set; }

    public bool? onfirstloginenableeditform { get; set; }

    public bool? isbulksms { get; set; }

    public bool? isbulkmail { get; set; }

    public string? ismailid { get; set; }

    public bool? isshowadmissionfromstudentdetails { get; set; }

    public bool? ishodwisebranch { get; set; }

    public long? collegeid { get; set; }

    public long? appointment_letter_template_id { get; set; }

    public int? class_rollno_ordering { get; set; }

    public long? employee_message_template_id { get; set; }

    public long? enquiry_template_id { get; set; }

    public bool? is_teacher_specific { get; set; }

    public int? name_ordering { get; set; }

    public long? offer_letter_template_id { get; set; }

    public long? preadmission_template_id { get; set; }

    public long? profile_request_template_id { get; set; }

    public bool? student_change_photo { get; set; }

    public long? student_message_template_id { get; set; }

    public virtual tbl_mst_collage? college { get; set; }
}
