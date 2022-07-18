﻿using System;
using Modsen.App.DataAccess.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Modsen.App.DataAccess.Data;

namespace Modsen.App.DataAccess.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<Booking> _dbSet;

        public BookingRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<Booking>();
        }
    }
}