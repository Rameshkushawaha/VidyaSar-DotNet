using System;
using System.Collections.Generic;

namespace VidyaSar.Domain.Entities;

public partial class tbl_fees_configuration
{
    public long id { get; set; }

    public bool? onlinefeespayment { get; set; }

    public decimal? performancereportformate { get; set; }

    public bool? latefeesapplicable { get; set; }

    public decimal? latefeesamountperday { get; set; }

    public string? admissionfeeheadname { get; set; }

    public string? emailpassword { get; set; }

    public bool? isrefund { get; set; }

    public bool? isrefundfeesnotcallculated { get; set; }

    public bool? isbusfeesnotcallculated { get; set; }

    public decimal? bouncecharges { get; set; }

    public bool? isheadwisefees { get; set; }

    public string? paymentgatewayuserid { get; set; }

    public string? paymentgatewaytransactionpassword { get; set; }

    public string? paymentgatewayproductid { get; set; }

    public string? paymentgatewayrequestkey { get; set; }

    public string? paymentgatewayresponsekey { get; set; }

    public string? paymentgatewayrequestsalt { get; set; }

    public string? paymentgatewayresponsesalt { get; set; }

    public string? encryptionrequestkey { get; set; }

    public string? encryptionresponsekey { get; set; }

    public string paymentgatewaychecksumkey { get; set; } = null!;

    public string paymentgatewaymerchantidkey { get; set; } = null!;

    public string paymentgatewaysecurityid { get; set; } = null!;

    public string? paymentgatewayurl { get; set; }

    public string paymentgatewayreturnurl { get; set; } = null!;

    public bool? isinstallmentpayment { get; set; }

    public bool? islatefeesamountper { get; set; }

    public decimal? latefeesfixamount { get; set; }

    public bool? isautoclearcheckdateapplybouncecharges { get; set; }

    public decimal? collegeid { get; set; }

    public bool? isoldfeescollection { get; set; }

    public bool? isactivepaymentgateway { get; set; }

    public DateOnly? laststartdate { get; set; }

    public DateOnly? lastenddate { get; set; }

    public decimal? paymentgatewayid { get; set; }

    public string? clientid { get; set; }

    public string? clientsecret { get; set; }

    public string? ostatoken { get; set; }

    public DateTime? tokencreateddatetime { get; set; }

    public string? ostagatewayhostname { get; set; }

    public bool? ispartpaymentallowed { get; set; }

    public bool? isexcessfeesallowed { get; set; }

    public bool? isdiscountallowed { get; set; }

    public bool? isyearwisefees { get; set; }

    public bool? issubjectgroupwisefees { get; set; }

    public bool? isparentwisefees { get; set; }

    public bool? isgenderwisefees { get; set; }

    public decimal? latefeesamountpermonth { get; set; }

    public bool? islatefeesmonthly { get; set; }

    public bool? issubheadwisefees { get; set; }

    public bool? ishostal { get; set; }

    public bool? ismess { get; set; }

    public bool? isbus { get; set; }

    public bool? isexam { get; set; }

    public bool? issequensalyinstallment { get; set; }

    public string? pgname { get; set; }

    public string? bankregistermobile { get; set; }

    public string? bankregisteremail { get; set; }

    public DateTime? pgstartdate { get; set; }

    public string? admission_fee_head_name { get; set; }

    public int? bounce_charges { get; set; }

    public long? college_id { get; set; }

    public string? email_password { get; set; }

    public long? fees_receipt_template_id { get; set; }

    public bool? is_auto_clearcheck_date_apply_bounce_charges { get; set; }

    public bool? is_bus_fees_not_callculated { get; set; }

    public bool? is_head_wise_fees { get; set; }

    public bool? is_installment_payment { get; set; }

    public bool? is_late_fees_amount_per { get; set; }

    public bool? is_refund { get; set; }

    public bool? is_refund_fees_not_callculated { get; set; }

    public int? late_fees_amount_perday { get; set; }

    public bool? late_fees_applicable { get; set; }

    public int? late_fees_fix_amount { get; set; }

    public bool? online_fees_payment { get; set; }

    public string? payment_gateway_checksum_key { get; set; }

    public string? payment_gateway_merchantidkey { get; set; }

    public string? payment_gateway_return_url { get; set; }

    public string? payment_gateway_securityid { get; set; }

    public int? performance_report_formate { get; set; }
}
