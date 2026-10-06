using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.SupportTicket
{
    

    public sealed class SupportTicket1
    {
        public string Id { get; }
        public string Subject { get; private set; }
        public string Body { get; private set; }
        public DateTimeOffset OpenedAt { get; }
        public string Priority { get; private set; } = "P3";

        private readonly TicketPriorityCalculator _priorityCalculator; // عشان الكلاس التاني 

        public SupportTicket1(
            string id,
            string subject,
            string body,
            DateTimeOffset openedAt,
            TicketPriorityCalculator priorityCalculator)
        {
            Id = id;
            Subject = subject;
            Body = body;
            OpenedAt = openedAt;
            _priorityCalculator = priorityCalculator;

            Priority = _priorityCalculator.Calculate(Subject, Body);
        }

        public void AppendCustomerMessage(string text)
        {
            Body += "\n---\n" + text;
            Priority = _priorityCalculator.Calculate(Subject, Body);
        }
    }
}
