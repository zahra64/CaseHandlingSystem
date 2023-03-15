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

        public static async Task SaveCaseAsync(Case casee)
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


        public static async Task SaveCommentAsync(string comment, Case SelectedCase)
        {
            var _commentEntity = new CommentEntity
            {
                CaseId = SelectedCase.Id,
                Comment = comment,

            };

           var _caseEntity = await _context.Cases.FirstOrDefaultAsync(x => x.Description == SelectedCase.Description && x.Status == SelectedCase.Status && x.CreatedOnDate == SelectedCase.CreatedOnDate);
        
            var _technicianEntity = _context.Employees;
            
                if (_caseEntity != null)
            {
                _commentEntity.CaseId = _caseEntity.Id;
             
            }


            _context.Add(_commentEntity);
            await _context.SaveChangesAsync();
        }








    }
}
