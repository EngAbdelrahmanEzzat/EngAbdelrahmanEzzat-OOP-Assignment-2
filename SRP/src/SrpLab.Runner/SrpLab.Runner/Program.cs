using SrpLab.AppointmentDesk;
using SrpLab.CheckoutBasket;
using SrpLab.CourseEnrollmentDesk;
using SrpLab.GradeBook;
using SrpLab.KitchenTicket;
using SrpLab.LoanDesk;
using SrpLab.SubscriptionBilling;
using SrpLab.SupportTicket;
using SrpLab.Ward;
using SrpLab.WareHousePickList;

namespace SrpLab.Runner
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("SrpLab — 10 After refactor)");
            Console.WriteLine("=================================================");

            // =====================================================
            // 1. WardBoard
            // =====================================================

            var acuityScorer = new ScoreAcuity();
            var pagerLog = new PagerLog();

            var ward = new WardBoard(acuityScorer, pagerLog);

            ward.AssignBed(1, "p-88", heartRate: 130, spo2: 89);

           
            var patientId = "p-88".Trim().ToUpperInvariant();
            var acuity = acuityScorer.Acuityscorer(130, 89);

            var handoffBuilder = new HandoffNoteBuilder();

            Console.WriteLine(
                handoffBuilder.Build(1, patientId, acuity));

            Console.WriteLine(
                string.Join(" | ", pagerLog.Drain()));


            // =====================================================
            // 2. CheckoutBasket
            // =====================================================

            var basket = new CheckoutBasket1();

            basket.AddLine("SKU-1", 40m, 2);
            basket.ApplyCouponText("SAVE10");
            basket.EnableGiftWrap();

            var pricing = new CheckoutPricing(basket);
            var total = new CheckoutTotal(basket, pricing);
            var payment = new PaymentAuthorizationStub(basket, total);

            Console.WriteLine(
                $"basket total={total.GrandTotal()} auth={payment.AuthorizePaymentStub("4242")}");


            // =====================================================
            // 3. SupportTicket
            // =====================================================

            var priorityCalculator = new TicketPriorityCalculator();

            var ticket = new SupportTicket1(
                "T-1",
                "cannot login",
                "prod is down for me",
                DateTimeOffset.UtcNow,
                priorityCalculator);

            var slaCalculator = new SlaCalculator();

            var slaDeadline = slaCalculator.CalculateDeadline(
                ticket.Priority,
                ticket.OpenedAt);

            var communicationBuilder = new TicketCommunicationBuilder();

            Console.WriteLine(
                communicationBuilder.DraftPublicReply(
                    ticket.Id,
                    ticket.Priority,
                    slaDeadline,
                    "Nora"));


            // =====================================================
            // 4. LoanDesk
            // =====================================================

            var loan = new LoanDesk1(
                60_000m,
                640,
                4,
                hasCollateral: false);

            var riskAndEligible = new RiskandEligible();

            var riskScore = riskAndEligible.RiskScore(loan);
            var isEligible = riskAndEligible.IsEligible(loan);

            var documentRequirement = new DocumentRequirement();

            var documents = documentRequirement.RequiredDocuments(
                loan,
                isEligible);

            var decisionLetter = new LoanDecisionLetter();

            Console.WriteLine(
                decisionLetter.DecisionLetter(
                    "Omar",
                    isEligible,
                    loan.RequestedAmount,
                    riskScore,
                    documents));


            // =====================================================
            // 5. CourseEnrollmentDesk
            // =====================================================

            var course = new CourseEnrollmentDesk1(
                "SEF-101",
                capacity: 1,
                tuition: 3000m);

            Console.WriteLine(
                course.Register("a@mail.com"));

            Console.WriteLine(
                course.Register("b@mail.com"));

            var welcomePacketFormatter = new WelcomePacketFormatter();

            Console.WriteLine(
                welcomePacketFormatter.WelcomePacketMarkdown(
                    "b@mail.com",
                    "Bea",
                    course.CourseCode,
                    course));


            // =====================================================
            // 6. KitchenTicket
            // =====================================================

            var kitchen = new KitchenTicket1();

            kitchen.AddItem(
                "Pasta",
                new[] { "wheat", "milk" },
                12);

            var items = kitchen.GetItems();

            var allergenDetector = new AllergenDetector();

            var allergens = allergenDetector.DetectAllergens(items);

            var estimationReadyMinutes = new EstimationReadyMinutes();

            var estimatedReady = estimationReadyMinutes.Calculate(
                items,
                openStations: 1,
                allergenCount: allergens.Count);

            var expoLane = new ExpoLane();

            expoLane.Decide(
                allergens.Count,
                estimatedReady);

            var thermalTicketBuilder = new ThermalTicketBuilder();

            Console.WriteLine(
                thermalTicketBuilder.Build(
                    42,
                    items,
                    estimatedReady,
                    allergens));


            // =====================================================
            // 7. SubscriptionBilling
            // =====================================================

            var sub = new SubscriptionBilling1(
                "c-9",
                99m,
                new DateOnly(2026, 9, 1),
                new DateOnly(2026, 10, 1));

            sub.RegisterFailedPayment();

            var invoiceNumber = new InvoiceNumber();

            var invoice = invoiceNumber.Generate(sub.PeriodStart);

            var dunningEmail = new DunningEmail();

            Console.WriteLine(
                dunningEmail.Build(
                    "Sara",
                    sub.MonthlyPrice,
                    invoice,
                    sub.FailedPayments,
                    new DateOnly(2026, 9, 20)));


            // =====================================================
            // 8. WarehousePickList
            // =====================================================

            var pick = new WarehousePickList1();

            pick.AddNeed("BOLT", "A", 3, 10, 7);
            pick.AddNeed("NUT", "B", 1, 5, 5);

            var allocations = pick.Allocate();

              var originalLines = new List<(string Sku, string Aisle, int Bin, int Qty)>
              {
                  ("BOLT", "A", 3, 10),
                  ("NUT", "B", 1, 5)
              };

            var warehousePath = new WarehousePath();

            var walkingOrder = warehousePath.GetWalkingOrder(originalLines);

            var warehousePicker = new Warehousepicker();

            Console.WriteLine(
                warehousePicker.Build(
                    walkingOrder,
                    allocations,
                    originalLines));


            // =====================================================
            // 8. AppointmentDesk
            // =====================================================

            
            var appointmentDesk = new AppointmentDesk1(
                 new TimeOnly(9, 0),
                 new TimeOnly(17, 0),
                   30);

            var scheduler = new AppointmentScheduler(appointmentDesk);

            var slot = scheduler.FindNextSlot(
                DateTimeOffset.Parse("2026-09-21T08:00:00Z"),
                48);

            if (slot is null)
                throw new InvalidOperationException("no slot");

            scheduler.TryBook(slot.Value);
            
            var messaging = new AppointmentMessaging();
            Console.WriteLine(messaging.SmsReminder(slot.Value, "0100"));


            // =====================================================
            // 8. GradeClass
            // =====================================================

            var grades = new GradeBook1();

            grades.Record("s1", 92);
            grades.Record("s1", 88);

            var average = grades.Average("s1");

            var gradePolicy = new GradePolicy();
            var letter = gradePolicy.Letter(average);

            var honorRollPolicy = new HonorRollPolicy();
            var honorRoll = honorRollPolicy.MeetsHonorRoll(average, letter);

            var transcriptFormat = new TranscriptFormat();
            Console.WriteLine(
                transcriptFormat.TranscriptPlain(
                    "s1",
                    "Ali",
                    average,
                    letter,
                    honorRoll));
            

        }
    }
}