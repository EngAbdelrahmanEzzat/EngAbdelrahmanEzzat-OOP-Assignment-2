namespace PatternsLab.Runner
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SINGLETON: After ===\n");
            DatabaseService d = new DatabaseService();
            d.Connect();

            UiService u = new UiService();
            u.Render();

            Console.WriteLine("=== Builder: After ===\n");
            var c1 = new CourseRegisterationBuilder("ali@mail.com", "SEF-101")
           .WithAccessModeandGroubcode("LiveGroup", "G1")
           .WithDiscountCode("EARLY10")
           .WithMentorNote("Needs evening slot")
           .WithPreferredStart(new DateOnly(2026, 10, 1))
           .WithSendEmailWelcome(true)
           .WithSendWhatsApp(true)
           .Build();
            Console.WriteLine(c1);

            var c2 = new CourseRegisterationBuilder("sara@mail.com", "SEF-101")
            .WithAccessModeandGroubcode("VideosOnly", null)
            .WithDiscountCode(null)
            .WithMentorNote(null)
            .WithPreferredStart(null)
            .WithSendEmailWelcome(true)
            .WithSendWhatsApp(true)
            .Build();



            Console.WriteLine("=== Prototype: After ===\n");
            Enemy original = new Orc();

            Console.WriteLine("\n--- Cloning ---");

            Enemy copy = original.Clone();

            Console.WriteLine($"Original ModelId: {original.ModelId}");
            Console.WriteLine($"Copy ModelId:     {copy.ModelId}");

            Console.WriteLine($"Same Model? {original.ModelId == copy.ModelId}");

            Console.WriteLine($"Same Weapon? {ReferenceEquals(original.Weapon, copy.Weapon)}");

            Console.WriteLine($"Same Abilities? {ReferenceEquals(original.Abilities, copy.Abilities)}");
        }

    }
}
