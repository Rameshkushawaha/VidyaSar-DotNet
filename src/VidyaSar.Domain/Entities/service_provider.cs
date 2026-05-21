using System;
using System.Collections.Generic;

namespace VidyaSar.Domain.Entities;

public partial class service_provider
{
    public long id { get; set; }

    public string? service_provider_name { get; set; }

    public string? poweredby { get; set; }

    public string? productname { get; set; }

    public string? termconditionpath { get; set; }

    public string? mobileno { get; set; }

    public string? email { get; set; }

    public string? whatsappno { get; set; }

    public string? policypath { get; set; }

    public string? developedby { get; set; }

    public string? serviceproviderlogo { get; set; }

    public string? theme { get; set; }

    public bool? isactive { get; set; }

    public string? address { get; set; }

    public string? language { get; set; }

    public string? cookiespolicy { get; set; }

    public string? grievencesredressal { get; set; }

    public string? refundpolicy { get; set; }

    public string? bankname { get; set; }

    public string? bank_logo_path { get; set; }
}
