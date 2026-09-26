using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.Ward
{
    //هنا عملته كدا عشان يبقى نقس الشكل بس كدا احنا فصلنا ال logic عنه فكدا هو مش مسؤول عن اكثر من responsibility
    public sealed class WardBoard
    {
        private readonly Dictionary<int, string> _bedPatient = new();
        private readonly Dictionary<int, int> _vitalsScore = new();

        private readonly ScoreAcuity _acuityScorer;
        private readonly PagerLog _pagerLog;

        public WardBoard(
            ScoreAcuity acuityScorer,
            PagerLog pagerLog)
        {
            _acuityScorer = acuityScorer;
            _pagerLog = pagerLog;
        }

        public void AssignBed(
            int bed,
            string patientId,
            int heartRate,
            int spo2)
        {
            if (bed <= 0)
                throw new ArgumentOutOfRangeException(nameof(bed));

            if (string.IsNullOrWhiteSpace(patientId))
                throw new ArgumentException("patient required");

            patientId = patientId.Trim().ToUpperInvariant();

            _bedPatient[bed] = patientId;

            var acuity = _acuityScorer.Acuityscorer(heartRate, spo2);

            _vitalsScore[bed] = acuity;

            if (acuity >= 8)
                _pagerLog.Add(bed);
        }
    }
}
