namespace OrderProcessing.Domain.Enums;

public enum OrderStatus
{
    Received = 1,
    Processing = 2,
    Paid = 3,
    Completed = 4,
    Cancelled = 99
}