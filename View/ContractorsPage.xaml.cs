using Ksiegowosc.ViewModel;

namespace Ksiegowosc.View;

public partial class ContractorsPage : ContentPage
{
	public ContractorsPage(ContractorsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}