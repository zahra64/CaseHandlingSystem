using CaseHandling.Contexts;
using CaseHandling.MVVM.Models;
using CaseHandling.MVVM.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;

namespace CaseHandling.Services
{
    internal class CaseService
    {
        private static DataContext _context = new DataContext();

        public static async Task SaveAsync(Case casee)
        {
            var _caseEntity = new CaseEntity
            {
                Description = casee.Description,
                CreatedOnDate = casee.CreatedOnDate,
                Status = casee.Status,
            };

            var _customerEntity = await _context.Customers.FirstOrDefaultAsync(x => x.FirstName == casee.CustomerFirstName && x.LastName == casee.CustomerLastName && x.Email == casee.CustomerEmail && x.Phone == casee.CustomerPhone);
            if (_customerEntity != null)
                _caseEntity.CustomerId = _customerEntity.Id;
            else
                _caseEntity.Customer = new CustomerEntity
                {
                    FirstName = casee.CustomerFirstName,
                    LastName = casee.CustomerLastName,
                    Email = casee.CustomerEmail,
                    Phone = casee.CustomerPhone,
                };

            _context.Add(_caseEntity);
            await _context.SaveChangesAsync();
        }


        public static async Task<ObservableCollection<Case>> GetAllCasesAsync()
        {
            var _cases = new ObservableCollection<Case>();

            foreach (var _casee in await _context.Cases.Include(x => x.Customer).ToListAsync())
                _cases.Add(new Case
                {
                    Id = _casee.Id,
                    Description = _casee.Description,
                    CreatedOnDate = _casee.CreatedOnDate,
                    Status = _casee.Status,
                    CustomerFirstName = _casee.Customer.FirstName,
                    CustomerLastName = _casee.Customer.LastName,
                    CustomerEmail = _casee.Customer.Email,
                    CustomerPhone = _casee.Customer.Phone,
                });

            return _cases;
        }
    }
}
