//using CaseHandling.MVVM.Models;
using CaseHandling.MVVM.Models;
using CaseHandling.MVVM.Models.Entities;
using CaseHandling.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace CaseHandling.MVVM.ViewModels
{
    public partial class CasesViewModel : ObservableObject
    {
        [ObservableProperty]
        private string title = "List of cases";


        [ObservableProperty]
        private ObservableCollection<Case> cases = null!;

        [ObservableProperty]
        private Case selectedCase = null!;

        public CasesViewModel()
        {
            ListAllCasesAsync().ConfigureAwait(false);
        }

        public async Task ListAllCasesAsync()
        {
            Cases = new ObservableCollection<Case>(await CaseService.GetAllCasesAsync());
        }


        ////////////////////////////////////////////////////////////

        [ObservableProperty]
        private string comment = string.Empty;


        [RelayCommand]
        public async Task CreateNewCommentAsync()
        {
            var commentt = new Case
            {
                CommentForCase = Comment,
                CreatedCommentDate = DateTime.Now,

            };

            await CaseService.SaveCommentAsync(commentt);

            ClearForm();

        }

        private void ClearForm()
        {
            Comment = "";

        }




    }
}
//public async Task CreateNewCaseAsync()
//{
//    var casee = new Case
//    {
//        Description = Description,
//        //CreatedOnDate = DateTime.Now,
//        Status = "Ej Påbörjad",
//        //Status= Status,
//        CustomerFirstName = FirstName,
//        CustomerLastName = LastName,
//        CustomerEmail = Email,
//        CustomerPhone = Phone,
//    };

//    await CaseService.SaveCaseAsync(casee);

//    ClearForm();
//}







