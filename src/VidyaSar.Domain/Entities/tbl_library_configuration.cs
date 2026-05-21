using System;
using System.Collections.Generic;

namespace VidyaSar.Domain.Entities;

public partial class tbl_library_configuration
{
    public long id { get; set; }

    public decimal? returndays { get; set; }

    public decimal? returnempdays { get; set; }

    public decimal? nobooks { get; set; }

    public decimal? nobookemp { get; set; }

    public decimal? maxfine { get; set; }

    public decimal? libraryfine { get; set; }

    public decimal? bookbanklibraryfine { get; set; }

    public decimal? bookissuemailtemplateid { get; set; }

    public decimal? collegeid { get; set; }

    public int? book_bank_library_fine { get; set; }

    public long? book_issue_mail_template_id { get; set; }

    public long? college_id { get; set; }

    public int? library_fine { get; set; }

    public int? max_fine { get; set; }

    public int? no_book_emp { get; set; }

    public int? no_books { get; set; }

    public int? return_days { get; set; }

    public int? return_emp_days { get; set; }
}
