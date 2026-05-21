using System;
using System.Collections.Generic;

namespace VidyaSar.Domain.Entities;

public partial class tbl_standardlibrary_bookbank_configuration
{
    public long relation_id { get; set; }

    public decimal library_id { get; set; }

    public decimal category_id { get; set; }

    public bool status { get; set; }

    public virtual category_master category { get; set; } = null!;
}
