using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.Ward
{
    public sealed class CensusCsvExporter
    {
        public string Export( Dictionary<int, string> patients, Dictionary<int, int> acuityScores)
        {
            var lines = new List<string>
            {
            "bed,patient,acuity"
            };

            foreach (var bed in patients.Keys.OrderBy(x => x))
            {
                lines.Add(
                    $"{bed},{patients[bed]},{acuityScores[bed]}"
                    );
            }

            return string.Join('\n', lines);
        }
    }
}
