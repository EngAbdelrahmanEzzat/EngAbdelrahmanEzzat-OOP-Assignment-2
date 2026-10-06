using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.AppointmentDesk
{
   
    public sealed class AppointmentScheduler
    {
        private readonly HashSet<DateTimeOffset> _booked = new();
        private readonly AppointmentDesk1 _appointmentDesk;

        public AppointmentScheduler(AppointmentDesk1 appointmentDesk)
        {
            _appointmentDesk = appointmentDesk;
        }

        public DateTimeOffset? FindNextSlot(DateTimeOffset from, int searchHours)
        {
            var cursor = Align(from);
            var end = from.AddHours(searchHours);
            while (cursor < end)
            {
                if (_appointmentDesk.IsWithinBusinessHours(cursor) && !_booked.Contains(cursor))
                    return cursor;
                cursor = cursor.AddMinutes(_appointmentDesk.SlotMinutes);
            }
            return null;
        }

        public bool TryBook(DateTimeOffset slot)
        {
            if (!_appointmentDesk.IsWithinBusinessHours(slot) || _booked.Contains(slot)) return false;
            _booked.Add(slot);
            return true;
        }

        private DateTimeOffset Align(DateTimeOffset from)
        {
            var minutes = from.Minute - (from.Minute % _appointmentDesk. SlotMinutes);
            return new DateTimeOffset(
                from.Year,
                from.Month,
                from.Day,
                from.Hour,
                minutes,
                0,
                from.Offset);
        }
    }
}
