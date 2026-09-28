using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.CourseEnrollmentDesk
{
    
    public sealed class TuitionInvoiceFormatter
    {
        public string Format( string studentEmail,CourseEnrollmentDesk1 enrollment)
        {
            if (!enrollment.IsSeated(studentEmail))
                return $"{enrollment.CourseCode},WAITLIST,0.00";

            var tuition = enrollment.Tuition;
            var vat = Math.Round(tuition * 0.14m, 2);
            var total = tuition + vat;

            return $"{enrollment.CourseCode}," +
                   $"TUITION,{tuition:0.00}," +
                   $"VAT,{vat:0.00}," +
                   $"TOTAL,{total:0.00}";
        }
    }
}
