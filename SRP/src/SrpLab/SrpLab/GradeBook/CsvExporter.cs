using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.GradeBook
{


    public sealed class CsvExporter
    {
        public string Export(IReadOnlyDictionary<string, List<decimal>> scores, GradePolicy gradepolicy, HonorRollPolicy honorrollpolicy)
        {
            var rows = new List<string> { "studentId,average,letter,honor" };
            foreach (var id in scores.Keys.OrderBy(x => x))
            {
                decimal avg = Math.Round(scores[id].Average(), 2);
                rows.Add($"{id},{Math.Round(scores[id].Average(), 2)},{gradepolicy.Letter(avg)},{(honorrollpolicy.MeetsHonorRoll(avg,id) ? 1 : 0)}");
            }
            return string.Join('\n', rows);
        }
    }
}
