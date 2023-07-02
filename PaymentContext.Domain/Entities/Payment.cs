using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
  public abstract class Payment
  {
    protected Payment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, Document document, Address address, Email email)
    {
      Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
      PaidDate = paidDate;
      ExpireDate = expireDate;
      Total = total;
      TotalPaid = totalPaid;
      Payer = payer;
      Document = document;
      Address = address;
      Email = email;
    }

    public string Number { get; set; }
    public DateTime PaidDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public decimal Total { get; set; }
    public decimal TotalPaid { get; set; }
    public string Payer { get; set; }
    public Document Document { get; set; }
    public Address Address { get; set; }
    public Email Email { get; set; }
  }
}