using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.GradeBook
{
    public sealed class TranscriptFormat
    {
        public string TranscriptPlain(string studentId, string fullName,decimal average, string letter,bool honorRoll)
        {
            // Registrar document format ≠ grading policy.
            return $"TRANSCRIPT\nStudent: {fullName} ({studentId})\nAverage: {average}\nLetter: {letter}\nHonor: {honorRoll}\n";
        }

    }
}
