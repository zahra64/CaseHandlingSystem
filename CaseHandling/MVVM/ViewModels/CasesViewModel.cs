//using CaseHandling.MVVM.Models;
using CaseHandling.MVVM.Models;
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


    }
    

    }
