using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Ksiegowosc.Model;
using Ksiegowosc.Services;
using Microsoft.EntityFrameworkCore;

namespace Ksiegowosc.ViewModel;

public partial class ReceivedInvoicesViewModel : ObservableObject
{
    private readonly AppDbContext _dbContext;

    [ObservableProperty]
    private ObservableCollection<Koszt> koszty = new ObservableCollection<Koszt>();

    public ReceivedInvoicesViewModel(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        LoadKoszty();
    }

    private void LoadKoszty()
    {
        var kosztyList = _dbContext.Koszty
            .Include(k => k.Kontrahent)
            .ToList();
        Koszty.Clear();
        foreach (var koszt in kosztyList)
        {
            Koszty.Add(koszt);
        }
    }
}