using Memorize.ViewModel;

namespace Memorize;

public partial class MemorizePage : ContentPage
{
	public MemorizePage(MemorizeViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}

