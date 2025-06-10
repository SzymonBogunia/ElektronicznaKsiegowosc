using Ksiegowosc.Model;
using Ksiegowosc.Services;
using Ksiegowosc.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace Ksiegowosc.View;

public partial class AddInvoicePage : ContentPage
{
    private readonly AppDbContext _dbContext;
    private ObservableCollection<Kontrahent> _kontrahenci;

    public AddInvoicePage(AppDbContext dbContext)
    {
        InitializeComponent();
        _dbContext = dbContext;
        LoadKontrahenci();
        DocumentTypePicker.SelectedIndex = 0; // Domy�lnie wybierz "Faktura"
    }

    private void LoadKontrahenci()
    {
        _kontrahenci = new ObservableCollection<Kontrahent>(_dbContext.Kontrahenci.ToList());
        KontrahentPicker.ItemsSource = _kontrahenci;
        KontrahentPicker.ItemDisplayBinding = new Binding("Nazwa");
    }

    private void OnDocumentTypeChanged(object sender, EventArgs e)
    {
        if (DocumentTypePicker.SelectedIndex == -1) return;

        bool isFaktura = DocumentTypePicker.SelectedItem.ToString() == "Faktura";

        // Ukryj/Wy�wietl pola specyficzne dla Faktury
        DataPlatnosciLabel.IsVisible = isFaktura;
        DataPlatnosciDatePicker.IsVisible = isFaktura;
        StatusLabel.IsVisible = isFaktura;
        StatusPicker.IsVisible = isFaktura;

        // Ukryj/Wy�wietl pola specyficzne dla Kosztu
        OpisLabel.IsVisible = !isFaktura;
        OpisEntry.IsVisible = !isFaktura;
        KategoriaLabel.IsVisible = !isFaktura;
        KategoriaEntry.IsVisible = !isFaktura;
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (DocumentTypePicker.SelectedIndex == -1)
        {
            await DisplayAlert("B��d", "Wybierz typ dokumentu", "OK");
            return;
        }

        try
        {
            if (DocumentTypePicker.SelectedItem.ToString() == "Faktura")
            {
                var faktura = new Faktura
                {
                    IdKontrahenta = _kontrahenci[KontrahentPicker.SelectedIndex].IdKontrahenta,
                    NumerDokumentu = NumerDokumentuEntry.Text,
                    DataWystawienia = DataWystawieniaDatePicker.Date,
                    DataPlatnosci = DataPlatnosciDatePicker.Date,
                    KwotaNetto = decimal.Parse(KwotaNettoEntry.Text),
                    StawkaVat = decimal.Parse(StawkaVatEntry.Text),
                    KwotaBrutto = decimal.Parse(KwotaBruttoEntry.Text),
                    Status = (Faktura.StatusFaktury)Enum.Parse(typeof(Faktura.StatusFaktury), StatusPicker.SelectedItem.ToString())
                };
                _dbContext.Faktury.Add(faktura);
            }
            else
            {
                var koszt = new Koszt
                {
                    IdKontrahenta = _kontrahenci[KontrahentPicker.SelectedIndex].IdKontrahenta,
                    NumerDokumentu = NumerDokumentuEntry.Text,
                    DataWystawienia = DataWystawieniaDatePicker.Date,
                    Opis = OpisEntry.Text,
                    KwotaNetto = decimal.Parse(KwotaNettoEntry.Text),
                    StawkaVat = decimal.Parse(StawkaVatEntry.Text),
                    KwotaBrutto = decimal.Parse(KwotaBruttoEntry.Text),
                    Kategoria = KategoriaEntry.Text
                };
                _dbContext.Koszty.Add(koszt);
            }

            await _dbContext.SaveChangesAsync();
            await DisplayAlert("Sukces", "Dokument zosta� zapisany", "OK");
            await Navigation.PopAsync(); // Powr�t do poprzedniej strony
        }
        catch (Exception ex)
        {
            await DisplayAlert("B��d", $"Wyst�pi� b��d: {ex.Message}", "OK");
        }
    }
    private void OnNettoOrVatChanged(object sender, TextChangedEventArgs e)
    {
        // Sprawd�, czy oba pola (netto i VAT) zawieraj� poprawne warto�ci
        if (decimal.TryParse(KwotaNettoEntry.Text, out decimal netto) &&
            decimal.TryParse(StawkaVatEntry.Text, out decimal vatRate))
        {
            // Sprawd�, czy stawka VAT jest w zakresie 0-100
            if (vatRate >= 0 && vatRate <= 100)
            {
                // Oblicz kwot� brutto: brutto = netto * (1 + vat/100)
                decimal brutto = netto * (1 + vatRate / 100);
                KwotaBruttoEntry.Text = Math.Round(brutto, 2).ToString("F2"); // Zaokr�glenie do 2 miejsc po przecinku
                VatErrorLabel.IsVisible = false;
            }
            else
            {
                // Poka� komunikat o b��dzie i wyczy�� pole brutto
                VatErrorLabel.IsVisible = true;
                KwotaBruttoEntry.Text = string.Empty;
            }
        }
        else
        {
            // Je�li dane s� niepoprawne, wyczy�� pole brutto
            KwotaBruttoEntry.Text = string.Empty;
        }
    }
}