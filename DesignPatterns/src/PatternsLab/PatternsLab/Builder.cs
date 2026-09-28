using System;
using System.Collections.Generic;
using System.Text;

namespace PatternsLab
{
    public sealed class CourseRegistration
    {
        public string StudentEmail { get; }
        public string CourseCode { get; }
        public string AccessMode { get; }
        public string? GroupCode { get; }
        public string? DiscountCode { get; }
        public bool SendWhatsApp { get; }
        public bool SendEmailWelcome { get; }
        public string? MentorNote { get; }
        public DateOnly? PreferredStart { get; }

        public CourseRegistration(
            string studentEmail,
            string courseCode,
            string accessMode,
            string? groupCode,
            string? discountCode,
            bool sendWhatsApp,
            bool sendEmailWelcome,
            string? mentorNote,
            DateOnly? preferredStart)
        {
            if (string.IsNullOrWhiteSpace(studentEmail)) throw new ArgumentException("email required");
            if (string.IsNullOrWhiteSpace(courseCode)) throw new ArgumentException("course required");

            if (accessMode == "LiveGroup" && string.IsNullOrWhiteSpace(groupCode))
                throw new InvalidOperationException("LiveGroup requires GroupCode");
            if (accessMode == "VideosOnly" && !string.IsNullOrWhiteSpace(groupCode))
                throw new InvalidOperationException("VideosOnly cannot have GroupCode");

            StudentEmail = studentEmail;
            CourseCode = courseCode;
            AccessMode = accessMode;
            GroupCode = groupCode;
            DiscountCode = discountCode;
            SendWhatsApp = sendWhatsApp;
            SendEmailWelcome = sendEmailWelcome;
            MentorNote = mentorNote;
            PreferredStart = preferredStart;
        }

        public override string ToString()
            => $"{StudentEmail} → {CourseCode} [{AccessMode}] group={GroupCode ?? "-"} discount={DiscountCode ?? "-"} wa={SendWhatsApp} mail={SendEmailWelcome}";
    }

    public static class RegistrationCallSites
    {
        public static CourseRegistration CreateLiveStudentUgly()
        {
            return new CourseRegistration(
                "sara@mail.com",
                "SEF-101",
                "LiveGroup",
                "G1",
                "EARLY10",
                true,
                true,
                "Needs evening slot",
                new DateOnly(2026, 10, 1));
        }

        public static CourseRegistration CreateVideosOnlyUgly()
        {
            return new CourseRegistration(
                "ali@mail.com",
                "SEF-101",
                "VideosOnly",
                null,
                null,
                false,
                true,
                null,
                null);
        }
    }
    public class CourseRegisterationBuilder
    {
        public readonly string StudentEmail;
        public readonly string CourseCode;
        public string AccessMode;
        public string? GroupCode;
        public string? DiscountCode;
        public bool SendWhatsApp;
        public bool SendEmailWelcome;
        public string? MentorNote;
        public DateOnly? PreferredStart;

        public CourseRegisterationBuilder(string studentEmail, string courseCode)
        {
            if (string.IsNullOrWhiteSpace(studentEmail)) throw new ArgumentException("email required");
            if (string.IsNullOrWhiteSpace(courseCode)) throw new ArgumentException("course required");

            StudentEmail = studentEmail;
            CourseCode = courseCode;
        }

        public CourseRegisterationBuilder WithAccessModeandGroubcode(string accessmode, string? groubcode)
        {
            if (accessmode == "LiveGroup" && string.IsNullOrWhiteSpace(groubcode))
                throw new InvalidOperationException("LiveGroup requires GroupCode");
            if (accessmode == "VideosOnly" && !string.IsNullOrWhiteSpace(groubcode))
                throw new InvalidOperationException("VideosOnly cannot have GroupCode");

            AccessMode = accessmode;
            GroupCode = groubcode;

            return this;
        }
        public CourseRegisterationBuilder WithDiscountCode(string? discount)
        {
            DiscountCode = discount;
            return this;
        }
        public CourseRegisterationBuilder WithSendWhatsApp(bool sendwhatsapp)
        {
            SendWhatsApp = sendwhatsapp;

            return this;
        }
        public CourseRegisterationBuilder WithSendEmailWelcome(bool sendemailwelcome)
        {
            SendEmailWelcome = sendemailwelcome;

            return this;
        }
        public CourseRegisterationBuilder WithMentorNote(string? mentornote)
        {
            MentorNote = mentornote;

            return this;
        }
        public CourseRegisterationBuilder WithPreferredStart(DateOnly? m)
        {
            PreferredStart = m;
            return this;
        }
        public CourseRegistration Build()
        {
            return new CourseRegistration(
             StudentEmail,
             CourseCode,
             AccessMode,
             GroupCode,
             DiscountCode,
             SendWhatsApp,
             SendEmailWelcome,
             MentorNote,
             PreferredStart);
        }

    }

}
