using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.Ward
{
    

    public sealed class PagerLog
    {
        private readonly List<string> _logs = new();

        public void Add(int bed) //فصلناها عن الفانكشن بتاع Assign bed
        {
            _logs.Add($"CODE-YELLOW bed={bed} at {DateTime.UtcNow:HH:mm}");
        }

        public IReadOnlyList<string> Drain()
        {
            var copy = _logs.ToList();
            _logs.Clear();
            return copy;
        }
    }
}
