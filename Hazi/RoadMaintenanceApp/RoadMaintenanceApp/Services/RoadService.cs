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

        public void AddStreet(string id, RoadCondition condition, int length, int traffic)
        {
            if (!condition.IsValid())
                throw new ArgumentException("A kondíciók összegének pontosan 100-nak kell lennie! ");

            if (traffic > 10) throw new ArgumentException("A forgalom szintje max 10 lehet!");

            var street = new Street
            {
                Id = id,
                GoodConditionPercent = condition.GoodPercent,
                MidConditionPercent = condition.MidPercent,
                BadConditionPercent = condition.BadPercent,
                LengthKm = length,
                TraficLevel = traffic
            };

            _context.Streets.Add(street);
            _context.SaveChanges();
        }

        public void UpdateStreet(string id, RoadCondition condition, int? length, int? traffic)
        {
            var street = _context.Streets.FirstOrDefault(s => s.Id == id);
            if (street == null) throw new KeyNotFoundException("Nincs ilyen azonosítójú út.");

            if (!condition.IsValid())
                throw new ArgumentException("A kondíciók összegének pontosan 100-nak kell lennie! ");

            street.GoodConditionPercent = condition.GoodPercent;
            street.MidConditionPercent = condition.MidPercent;
            street.BadConditionPercent = condition.BadPercent;

            if (length.HasValue) street.LengthKm = length.Value;
            if (traffic.HasValue)
            {
                if (traffic.Value > 10) throw new ArgumentException("Max traffic level: 10");
                street.TraficLevel = traffic.Value;
            }

            _context.SaveChanges();
        }
    }
}
