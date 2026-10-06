using LibrarySystem.LibraryItems;
using LibrarySystem.Members;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem
{
    public class Loan
    {
        public enum LoanStatus
        {
            Borrowed,
            Returned,
            Lost
        }
        public int LoanId { get; }
        public DateOnly BorrowDate { get; }
        public Member Member { get; }
        public LibraryItem LibraryItem { get; }

        public LoanStatus Status { get; private set; }
        public Loan(
                  int loanId,
                  DateOnly borrowDate,
                  Member member,
                  LibraryItem libraryItem)
        {
            if (loanId <= 0)
                throw new ArgumentOutOfRangeException(nameof(loanId), "Loan id must be greater than zero");

            if (member == null)
                throw new ArgumentNullException(nameof(member), "Member must have a value");

            if (libraryItem == null)
                throw new ArgumentNullException(nameof(libraryItem), "Library item must have a value");

            if (libraryItem.IsWithdrawn)
                throw new InvalidOperationException("A withdrawn item cannot be borrowed");

            if (libraryItem.IsOnLoan)
                throw new InvalidOperationException("The item is already on loan");
            //عملنا اخر اتنين دول عشان لازم نعرف ان ال item اللي احنا هنعمله Borrow متاح ولا لا
            LoanId = loanId;
            BorrowDate = borrowDate;
            Member = member;
            LibraryItem = libraryItem;
            Status = LoanStatus.Borrowed;

            member.Borrow(this);//عشان يمنع الاكتر من 3 ل student العادي وال 10 لل premium
        }

        public DateOnly DueDate
        {
            get
            {
                return BorrowDate.AddDays(LibraryItem.LoanPeriod);
            }
        }

        public DateOnly? ReturnDate { get; private set; }

        public double LateFee
        {
            get
            {
                if (ReturnDate.HasValue && ReturnDate.Value > DueDate)
                {
                    int lateDays = ReturnDate.Value.DayNumber - DueDate.DayNumber;

                    double dailyLateFee = 0;

                    if (LibraryItem is Book)
                    {
                        Book book = (Book)LibraryItem;
                        dailyLateFee = book.DailyLateFee;
                    }
                    else if (LibraryItem is DVD)
                    {
                        DVD dvd = (DVD)LibraryItem;
                        dailyLateFee = dvd.DailyLateFee;
                    }
                    else if (LibraryItem is Magazine)
                    {
                        Magazine magazine = (Magazine)LibraryItem;
                        dailyLateFee = magazine.DailyLateFee;
                    }

                    return lateDays * dailyLateFee;
                }

                return 0;
            }
        }
        public void Return(DateOnly returnDate)
        {
            if (Status != LoanStatus.Borrowed)
                throw new InvalidOperationException(
                    "Only borrowed loans can be returned");

            if (returnDate < BorrowDate)
                throw new ArgumentOutOfRangeException(
                    nameof(returnDate),
                    "Return date cannot be earlier than borrow date");

            ReturnDate = returnDate;
            Status = LoanStatus.Returned;

            LibraryItem.MarkAsReturned();

            if (Member is PremiumMember premiumMember)
            {
                premiumMember.AddReadingPoints();
            }

        }
        public void MarkAsLost()
        {
            if (Status != LoanStatus.Borrowed)
                throw new InvalidOperationException(
                    "Only borrowed loans can be marked as lost");

            Status = LoanStatus.Lost;
            LibraryItem.EndLoan();
        }

    }
}
