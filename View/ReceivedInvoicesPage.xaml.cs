using Ksiegowosc.ViewModel;

namespace Ksiegowosc.View;

public partial class ReceivedInvoicesPage : ContentPage
{
    public ReceivedInvoicesPage(ReceivedInvoicesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}