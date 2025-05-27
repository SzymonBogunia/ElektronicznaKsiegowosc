using Ksiegowosc.ViewModel;

namespace Ksiegowosc.View;

public partial class IssuedInvoicesPage : ContentPage
{
    public IssuedInvoicesPage(IssuedInvoicesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}