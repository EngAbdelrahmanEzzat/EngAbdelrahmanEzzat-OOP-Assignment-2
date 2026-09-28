using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.AppointmentDesk
{
  
    public sealed class AppointmentDesk1
    {
        public TimeOnly Open { get; }
        public TimeOnly Close { get; }
        public int SlotMinutes { get; }

        public AppointmentDesk1(TimeOnly open, TimeOnly close, int slotMinutes)
        {
            Open = open;
            Close = close;
            SlotMinutes = slotMinutes;
        }

        public bool IsWithinBusinessHours(DateTimeOffset when)
        {
            // Clinic calendar policy — HR/ops — not the same as ICS serialization.
            if (when.DayOfWeek is DayOfWeek.Friday or DayOfWeek.Saturday) return false;
            var t = TimeOnly.FromDateTime(when.DateTime);
            return t >= Open && t.AddMinutes(SlotMinutes) <= Close;
        }
    }
}
