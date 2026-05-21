using System;
using System.Collections.Generic;

namespace VidyaSar.Domain.Entities;

public partial class tbl_academic_configuration
{
    public long id { get; set; }

    public int? leavealloweddays { get; set; }

    public bool? allowcampus { get; set; }

    public bool? restrictroomallocation { get; set; }

    public bool? issubjectgroup { get; set; }

    public bool? isremoveperiodheader { get; set; }

    public bool? allowteachertoaddteachingplan { get; set; }

    public bool? allowteachertoeditteachingplan { get; set; }

    public bool? needapprovelfordailydairystaff { get; set; }

    public bool? feedbackbyattendance { get; set; }

    public bool? showstudentleavingoption { get; set; }

    public bool? isdepartmentwiselecture { get; set; }

    public bool? isenggteachingplan { get; set; }

    public long? collegeid { get; set; }

    public bool? allow_campus { get; set; }

    public bool? allow_teacher_to_add_teaching_plan { get; set; }

    public bool? allow_teacher_to_edit_teaching_plan { get; set; }

    public long? attendencesummary_template_id { get; set; }

    public long? campus_invitation_template_id { get; set; }

    public bool? feedback_by_attendance { get; set; }

    public bool? is_department_wise_lecture { get; set; }

    public bool? is_engg_teaching_plan { get; set; }

    public bool? is_remove_period_header { get; set; }

    public bool? is_subject_group { get; set; }

    public int? leave_allowed_days { get; set; }

    public bool? need_approvelfor_daily_dairy_staff { get; set; }

    public bool? restrict_room_allocation { get; set; }

    public long? short_attendence_letter_template_id { get; set; }

    public bool? show_student_leaving_option { get; set; }

    public long? teaching_plan_template_id { get; set; }

    public long? timetable_mail_template_id { get; set; }
}
