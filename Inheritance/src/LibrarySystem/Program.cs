using LibrarySystem.LibraryItems;
using LibrarySystem.Members;
using LibrarySystem.Staff;

namespace LibrarySystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Person person = new Person(...);         
            //Member member = new Member(...);         
            //Staff staff = new Staff(...);            
            //LibraryItem item = new LibraryItem(...); 

            //person.FullName = "New Name";           
            //student.Loans.Add(loan);                 
            //item.IsOnLoan = true;                    

            Console.WriteLine("----------------------------------------");
            try
            {
                Book book = new Book(1, "Clean Code", 10);

                HeadLibrarian head = new HeadLibrarian(
                    1,
                    "Ahmed",
                    "01000000000",
                    new DateOnly(2025, 1, 1),
                    10000);

                head.WithdrawItem(book);

                StudentMember student = new StudentMember(
                    2,
                    "Abdelrahman",
                    "01111111111");

                Loan f = new Loan(
                    1,
                    new DateOnly(2026, 9, 28),
                    student,
                    book);
            }//عشان نخليها تنفع لازم نخلي ال IsLoan = true
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("-------------------------------------");
            try
            {
                StudentMember student = new StudentMember(
                    4,
                    "Omar",
                    "01333333333");

                Book book1 = new Book(10, "Book 1", 10);
                Book book2 = new Book(11, "Book 2", 10);
                Book book3 = new Book(12, "Book 3", 10);
                Book book4 = new Book(13, "Book 4", 10);

                Loan loan1 = new Loan(10, new DateOnly(2026, 9, 28), student, book1);
                Loan loan2 = new Loan(11, new DateOnly(2026, 9, 28), student, book2);
                Loan loan3 = new Loan(12, new DateOnly(2026, 9, 28), student, book3);
                Loan loan4 = new Loan(13, new DateOnly(2026, 9, 28), student, book4);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

           

            Console.WriteLine("------------------------------------");
            List<LibraryItem> items = new List<LibraryItem>();

            items.Add(new Book(30, "Book", 10));
            items.Add(new DVD(31, "DVD", 10));
            items.Add(new Magazine(32, "Magazine", 10));

            foreach (LibraryItem item in items)
            {
                Console.WriteLine(item.LoanPeriod);
            }

            Console.WriteLine("-----------------------------------------");
            PremiumMember premium = new PremiumMember(
                      100,
                      "Abdelrahman",
                      "01000000000",
                      10);


            DVD dvd = new DVD(
                100,
                "C# Programming",
                20);

            Loan loan = new Loan(
                100,
                new DateOnly(2026, 9, 28),
                premium,
                dvd);

            loan.Return(new DateOnly(2026, 10, 10));

            Console.WriteLine($"Due Date: {loan.DueDate}");
            Console.WriteLine($"Late Fee: {loan.LateFee}");
            Console.WriteLine($"Reading Points: {premium.ReadingPoints}");
            Console.WriteLine("--------------------------------------------");
            try
            {
                loan.Return(new DateOnly(2026, 10, 11));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
