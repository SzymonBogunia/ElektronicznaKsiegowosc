using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Ksiegowosc.Model;
using Ksiegowosc.Services;

namespace Ksiegowosc.ViewModel
{
    public partial class ContractorsViewModel : ObservableObject
    {
        private readonly AppDbContext _dbContext;

        [ObservableProperty]
        private ObservableCollection<Kontrahent> kontrahenci = new ObservableCollection<Kontrahent>();

        public ContractorsViewModel(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            LoadKontrahenci();
        }

        private void LoadKontrahenci()
        {
            var kontrahenciList = _dbContext.Kontrahenci.ToList();
            foreach (var kontrahent in kontrahenciList)
            {
                Kontrahenci.Add(kontrahent);
            }
        }
    }
}
