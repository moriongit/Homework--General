using WebApplication2.Context;
using WebApplication2.Models;
using Microsoft.EntityFrameworkCore;


namespace WebApplication2.Helpers
{
    public class LayoutService
    {
        Pustokdb _context { get; }

        public LayoutService(Pustokdb context)
        {
            _context = context;
        }

        public async Task<Setting> GetSettingsAsync()
            => await _context.Settings.FindAsync(1);
    }
}

