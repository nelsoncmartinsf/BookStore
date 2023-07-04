using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BooksPage : ContentPage {
		private BooksViewModel _viewModel = new BooksViewModel();

		private async Task LoadViewModel() {
			await _viewModel.LoadBooks();
		}

		public BooksPage() {
			InitializeComponent();
			this.BindingContext = _viewModel;
		}

		protected override async void OnAppearing() {
			base.OnAppearing();

			await LoadViewModel();
		}

		private async void BooksCollectionView_RemainingItemsThresholdReached(Object sender, EventArgs e) {
			await LoadViewModel();
		}

		private void BooksCollectionView_SelectionChanged(Object sender, SelectionChangedEventArgs e) {
			if( BooksCollectionView.SelectedItem is Book book ) {
				Navigation.PushAsync(new BookDetailsPage(book));
			}

			BooksCollectionView.SelectedItem = null;
		}
	}
}