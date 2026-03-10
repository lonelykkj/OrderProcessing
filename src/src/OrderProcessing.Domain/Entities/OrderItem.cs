namespace OrderProcessing.Domain.Entities;

public class OrderItem
{
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; } 
    public decimal Price { get; private set; }
    
    public decimal Total => Quantity * Price;
    
    public OrderItem(Guid productId, int quantity, decimal price)
    {
        ProductId = productId;
        Quantity = quantity >= 0 ? quantity : throw new ArgumentOutOfRangeException(nameof(quantity), "Quantidade não pode ser negativa.");
        Price = price >= 0 ? price : throw new ArgumentOutOfRangeException(nameof(price), "Preço não pode ser negativo.");
    }
}