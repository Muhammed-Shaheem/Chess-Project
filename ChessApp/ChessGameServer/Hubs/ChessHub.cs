
using Microsoft.AspNetCore.SignalR;

namespace ChessGameServer.Hubs;

public class ChessHub : Hub
{
    string[,] board = new string[8, 8];
    public async Task<bool> PlayGame(string user, string message)
    {
   
        await Clients.All.SendAsync("ReceiveMessage", user, message);

        
    }   

}
