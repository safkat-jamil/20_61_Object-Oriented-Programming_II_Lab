namespace StudentManagementSystem.Models.Academic
{
    public enum PaymentMethod { OfflineBank, OnlineBank, CreditCard, DebitCard, Bkash, Nagad, Rocket, Other }

    public class Payment
    {
        public int Id { get; set; }
        public int RegistrationId { get; set; }
        public PaymentMethod Method { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaidAt { get; set; }

        public Registration? Registration { get; set; }
    }
}