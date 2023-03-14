using CaseHandling.MVVM.Models;
using CaseHandling.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CaseHandling.MVVM.ViewModels
{
    public partial class AddCaseViewModel : ObservableObject
    {

        [ObservableProperty]
        private string title = "Create a new Case if you need the tech support";

        [ObservableProperty]
        private string firstName = string.Empty;

        [ObservableProperty]
        private string lastName = string.Empty;

        [ObservableProperty]
        private string email = string.Empty;

        [ObservableProperty]
        private string phone = string.Empty;

        [ObservableProperty]
        private string description = string.Empty;

        [ObservableProperty]
        private string status = string.Empty;


        [RelayCommand]
        public async Task CreateNewCaseAsync()
        {
            var casee = new Case
            {
                Description = Description,
                //CreatedOnDate = DateTime.Now,
                Status = "Ej Påbörjad",
                //Status= Status,
                CustomerFirstName = FirstName,
                CustomerLastName = LastName,
                CustomerEmail = Email,
                CustomerPhone= Phone,
            };

            await CaseService.SaveAsync(casee);

            ClearForm();
        }


        private void ClearForm()
        {
            FirstName = "";
            LastName = "";
            Email = "";
            Phone = "";
            Description = "";
        }



    
    }
}
