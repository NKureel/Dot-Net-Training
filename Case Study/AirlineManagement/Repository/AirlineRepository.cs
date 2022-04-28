﻿using AirlineManagement.DBContext;
using AirlineManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineManagement.Repository
{
    public class AirlineRepository : IAirlineRepository
    {
        private readonly AirlineDbContext _airlineDb;
        public AirlineRepository(AirlineDbContext context)
        {
            _airlineDb = context;
        }
        public void DeleteAirline(string airlineNo)
        {
            var airline = _airlineDb.airlineTbls.Find(airlineNo);
            if (airline != null)
                _airlineDb.airlineTbls.Remove(airline);
            Save();
        }

        public AirlineTbl GetAirlineByNumber(string airlineNo)
        {
            return _airlineDb.airlineTbls.Find(airlineNo);
        }

        public IEnumerable<AirlineTbl> GetAirlines()
        {
            return _airlineDb.airlineTbls.ToList();
        }

        public void InsertAirline(AirlineTbl tbl)
        {
            _airlineDb.airlineTbls.Add(tbl);
            Save();
        }

        public void Save()
        {
            _airlineDb.SaveChanges();
        }

        public void UpdateAirline(AirlineTbl tbl)
        {
            _airlineDb.Entry(tbl).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
