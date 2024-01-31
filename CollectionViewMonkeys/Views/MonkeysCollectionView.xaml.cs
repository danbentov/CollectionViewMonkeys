using CollectionViewMonkeys.ViewModels;

namespace CollectionViewMonkeys.Views;

public partial class MonkeysCollectionView : ContentPage
{
	public MonkeysCollectionView()
	{
		InitializeComponent();
		this.BindingContext = new MonkeysCollectionViewModels();
	}
}