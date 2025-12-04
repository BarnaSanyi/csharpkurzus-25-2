using System;
using System.Collections.Generic;
using System.Text;
using RoadMaintenanceApp.Data;
using RoadMaintenanceApp.Models;
using System.Text.Json;

namespace RoadMaintenanceApp.Services
{
    public class RoadService
    {
        private readonly AppDbContext _context;

        public RoadService(AppDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }
    }
}
