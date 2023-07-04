using System;
using System.ComponentModel;
using System.Windows.Input;
using BookStore.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BookStore.ViewModels {
	public class BookDetailsViewModel : INotifyPropertyChanged {
		public Book Book { get; set; }

		public String FavouritesText {
			get {
				if( Book.IsFavourite ) {
					return "Remove from favourites";
				} else {
					return "Add to favourites";
				}
			}
		}

		public ICommand ToggleFavouriteCommand => new Command(ToggleFavourite);
		public ICommand BuyBookCommand => new Command(BuyBook, CanBuyBook);

		public event PropertyChangedEventHandler PropertyChanged;

		private void ToggleFavourite() {
			Book.IsFavourite = !Book.IsFavourite;
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FavouritesText)));

			if(Book.IsFavourite) {

			}
		}

		private Boolean CanBuyBook() {
			Boolean hasPurchaseUrl = !String.IsNullOrWhiteSpace(Book.PurchaseUrl);
			return hasPurchaseUrl;
		}
		private async void BuyBook() {
			await Browser.OpenAsync(Book.PurchaseUrl);
		}

		public BookDetailsViewModel(Book book) {
			Book = book;
		}
	}
}
