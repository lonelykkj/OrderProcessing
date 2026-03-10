using OrderProcessing.Domain.Enums;

namespace OrderProcessing.Domain.Entities;

public class Order
{
    public Guid Id { get; private set; }
    
    private readonly List<OrderItem> _items = new(); // Lista privada para controle interno
    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly(); // Expondo apenas para leitura - ninguém de fora pode dar .Add() ou .Clear()
    public OrderStatus Status { get; private set; } = OrderStatus.Received;
    
    public Order(Guid id)
    {
        Id = id;
    }
    
    public void AddItem(OrderItem item)
    {
        if (item == null) throw new ArgumentNullException(nameof(item));
        
        if (Status != OrderStatus.Received && Status != OrderStatus.Processing)
        {
            throw new InvalidOperationException("Não é possível adicionar itens a um pedido que não está em status 'Received' ou 'Processing'.");
        }
        
        _items.Add(item);
    }

    public void CancelOrderStatus()
    {
        if (Status == OrderStatus.Completed)
        {
            throw new InvalidOperationException("O pedido não pode ser cancelado porque já foi concluído.");
        }

        Status = OrderStatus.Cancelled;
    }
    
    public decimal TotalAmount => Items.Sum(i => i.Total);
}