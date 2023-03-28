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


        [ObservableProperty]
        private string status;

        [ObservableProperty]
        private string selectedStatus = "ny status:";



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


            await CaseService.SaveCommentAsync(Comment, SelectedCase);

            ClearForm();

        }

        private void ClearForm()
        {
            Comment = "";

        }


        ///////////////////////////////////////////



        [RelayCommand]
        public async Task ChangeStatusAsync()
        {

            if (SelectedStatus == "NotStarted")
                SelectedCase.Status = CaseStatus.NotStarted;
            else if (SelectedStatus == "InProgress")
                SelectedCase.Status = CaseStatus.InProgress;
            else if (SelectedStatus == "Completed")
                SelectedCase.Status = CaseStatus.Completed;


            if (SelectedStatus != "NotStarted")
            {
                await CaseService.ChangeStatusAsync(selectedCase);

                Status = SelectedStatus;
            }
            else
                SelectedStatus = "NotStarted";
        }



    }
}








