using Microsoft.AspNetCore.SignalR;
public class ProductHub : Hub
{
    public async Task NotifyChange() => await Clients.All.SendAsync("ProductChanged");
}
