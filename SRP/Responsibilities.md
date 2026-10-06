1. WardBoard

(1 إدارة الأسرّة والمرضى
2 حساب Acuity Score
3  الـPager والتنبيهات
4 إنشاء Handoff Note
5 تصدير CSV)
كدا الResponsibilities حوالي 5 وده ب violate مبدا ال single Responsibility 
وبكدا هنعمل حولي 5 كلاسات جديده تحت كلاس اسمه Ward.


2. Warehouse

ماشي كده تاني class اللي هو warehouse checklist. أول حاجة عندك اللي هو allocate والadd need، دول responsibility واحدة، الاتنين بيستخدموا نفس الحاجة. working order ده responsibility تانية، picker script ده responsibility تالتة، WNS XML batch ده، ده responsibility . بقى كده، كده عندنا four اللي هو نعمل r

3. SupportTicket

إدارة بيانات الـ Ticket 
حساب الـ Priority من محتوى الـ Ticket
حساب الـ SLA
بناء الـ Public Reply
Internal Escalation
different 5 Responsibilites

4. SubscriptionBilling

ادارة البيانات بتاعة subscription
حساب الـ Proration
توليد أرقام الـ Invoices
بناء Dunning Email
بناء Ledger Journal Line
different 5 Responsibilites


5. LoanDisk

 Loan for Data
 Risk and Iseligibile
 Required Documents
 Decision Letter Formatting
 Underwriter CSV Export
 different 5 Responsibilites 


 6. KitchenTicket
 إدارة/إضافة الـitems والـingredients والـquantity
 حساب/تجهيز بيانات التذكرة
 Rendering التذكرة بصيغة الـthermal
 حساب ال estimatedReadyMinutes
 حساب ال AllergenDetector


7. GradeBook
تصدير ال Csv
ال policy لحساب ال Grade
حساب ال transcriptformat
حساب ال honorrollpolicy
والكلاس الاب لل constructor , properties

8. CourseEnrollmentDesk
اول حاجه هي ال CourseEnrollmentDesk , Rister ,waitlistposition
Promotefromwaitlist, is seated
TuitionInvoiceFormatter for Format
WelcomePacketMarkdown 

9. CheckoutBacket
CheckoutBasket for ApplyCouponText,EnableGiftwrap...
CheckoutPricing for subtotal,dicountamount
وكلاس لحساب الجراند توتال
وكلاس لحساب ال Giftmessagetotal
وكلاس لعمل AuthorizePaymentStub

10. AppointmentDesk
لاس لحساب ال ics
كلاس لحساب ال IsWithinBusinessHours
كلاس لل   SmsReminder

 