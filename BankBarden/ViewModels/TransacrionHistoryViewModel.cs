namespace BankBarden.ViewModels
{
    public class TransacrionHistoryViewModel
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public string? Symbol { get; set; }
    }
}
