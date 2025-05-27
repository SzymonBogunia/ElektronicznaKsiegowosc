using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Ksiegowosc.Model;
using Ksiegowosc.Services;
using Microsoft.EntityFrameworkCore;

namespace Ksiegowosc.ViewModel;

public partial class IssuedInvoicesViewModel : ObservableObject
{
    private readonly AppDbContext _dbContext;

    [ObservableProperty]
    private ObservableCollection<Faktura> faktury = new ObservableCollection<Faktura>();

    public IssuedInvoicesViewModel(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        LoadFaktury();
    }

    private void LoadFaktury()
    {
        var fakturyList = _dbContext.Faktury
            .Include(f => f.Kontrahent)
            .ToList();
        Faktury.Clear();
        foreach (var faktura in fakturyList)
        {
            Faktury.Add(faktura);
        }
    }
}