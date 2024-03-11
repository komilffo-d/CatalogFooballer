using CatalogFooball.Database;
using CatalogFooball.Models;
using CatalogFooball.Models.DTO;
using CatalogFooball.Services.SignalR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace CatalogFooball.Controllers
{
    public class PlayerController : Controller
    {
        private readonly FootballDbContext _context;

        private readonly IHubContext<PlayerHub> _hub;
        public PlayerController(FootballDbContext context, IHubContext<PlayerHub> hub)
        {
            _context = context;
            _hub = hub;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.FootballPlayers.Include(f => f.Command).Include(f => f.Country).ToListAsync());
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Countries = new SelectList(_context.Countries, "Id", "Name");
            ViewBag.Commands = await _context.FootballCommands.ToListAsync();


            return View();
        }
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Countries = new SelectList(_context.Countries, "Id", "Name");
            ViewBag.Commands = await _context.FootballCommands.ToListAsync();
            return View(await _context.FootballPlayers.FirstOrDefaultAsync(f => f.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FootballPlayer player)
        {
            FootballCommand command = _context.FootballCommands.AsNoTracking().FirstOrDefault(fc => fc.Name == player.Command.Name)!;
            if (command is not null)
            {
                player.Command = null;
                player.CommandId = command.Id;
            }
            _context.FootballPlayers.Update(player);

            await _context.SaveChangesAsync();

            _context.Entry(player).Reference(p => p.Country).Load();
            _context.Entry(player).Reference(p => p.Command).Load();
            FootballPlayerDTO playerDTO = new FootballPlayerDTO()
            {
                Name = player.Name,
                Sex = player.Sex,
                DateBirthday = player.DateBirthday,
                Command = player.Command.Name,
                Country = player.Country.Name
            };
            await _hub.Clients.All.SendAsync("PlayerModify", player.Id, playerDTO);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Create(FootballPlayer player)
        {
            FootballCommand command = _context.FootballCommands.AsNoTracking().FirstOrDefault(fc => fc.Name == player.Command.Name)!;
            if (command is not null)
            {
                player.Command = null;
                player.CommandId = command.Id;
            }

            await _context.FootballPlayers.AddAsync(player);
            
            await _context.SaveChangesAsync();

            _context.Entry(player).Reference(p => p.Country).Load();
            _context.Entry(player).Reference(p => p.Command).Load();
            FootballPlayerDTO playerDTO = new FootballPlayerDTO()
            {
                Name = player.Name,
                Sex = player.Sex,
                DateBirthday= player.DateBirthday,
                Command= player.Command.Name,
                Country= player.Country.Name
            };
            await _hub.Clients.All.SendAsync("PlayerAdd", player.Id,playerDTO);
            return RedirectToAction("Index");
        }
    }
}

