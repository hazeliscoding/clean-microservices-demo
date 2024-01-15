namespace Basket.Application.Responses;

public class ShoppingCartResponse
{
    public string UserName { get; set; }
    public List<ShoppingCartItemResponse> Items { get; set; }

    public ShoppingCartResponse()
    {
    }

    public ShoppingCartResponse(string userName)
    {
        UserName = userName;
    }

    public decimal TotalPrice
    {
        get
        {
            return Items.Sum(item => item.Price * item.Quantity);
        }
    }
}