using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.CourseEnrollmentDesk
{
    public sealed  class WelcomePacketFormatter
    {
        public string WelcomePacketMarkdown(string studentEmail, string studentName, string courseCode, CourseEnrollmentDesk1 enrollment)
        {
            // Content design changes with academy marketing — not with seat algorithms.
            var status = enrollment.IsSeated(studentEmail) ? "confirmed seat" : $"waitlist #{enrollment.WaitlistPosition(studentEmail)}";
            return $"# Welcome to {courseCode}\nHi {studentName},\nYour status: **{status}**.\n" +
                   $"Bring a laptop. Discord onboarding link: https://example.invalid/{courseCode.ToLowerInvariant()}\n";
        }
    }
}
