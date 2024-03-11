using CatalogFooball.Database;
using CatalogFooball.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace CatalogFooball.Services.SignalR
{
    public class PlayerHub: Hub
    {
        private readonly FootballDbContext _context;
        public PlayerHub(FootballDbContext context)
        {
            _context = context;
        }
    }
}
