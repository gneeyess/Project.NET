﻿using Modsen.App.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Modsen.App.Core.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Modsen.App.API.Services
{
    public class BookingService : IBookingService//если оставить класс пустым, то пишет 'BookingService' does not implement
                                                 //interface member 'IBookingService.(Название метода)()'
    {
        public Task<BookingDto> GetAsync(int id)
        {
            return default; //что сюда писать я не знаю, поэтому return default. Аналогично ниже
        }

        public Task AddAsync(BookingDto bookingtDto)
        {
            return default;
        }

        public Task UpdateAsync(BookingDto bookingtDto)
        {
            return default;
        }

        public Task DeleteAsync(int id)
        {
            return default;
        }

        Task<IEnumerable<BookingDto>> IBookingService.GetQueueAsync(int pageNumber, int pageSize)
        {
            return default;
        }
    }
}