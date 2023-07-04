using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BookStore.Models;
using Xamarin.Forms;

namespace BookStore.ViewModels {
	public class BooksViewModel : INotifyPropertyChanged {
		public ObservableCollection<Book> Books { get; set; } = new ObservableCollection<Book>();

		private Int32 _currentPage = 0;

		private Boolean _showingFavourites;

		public event PropertyChangedEventHandler PropertyChanged;

		public String TitleText {
			get {
				if( _showingFavourites ) {
					return "Favourite books";
				} else {
					return "Books";
				}
			}
		}

		public String ShowBooksText {
			get {
				if( _showingFavourites ) {
					return "Show all books";
				} else {
					return "Show favourites books";
				}
			}
		}

		public ICommand ToggleFavouritesCommand => new Command(ToggleFavourites);

		private void ToggleFavourites() {
			_showingFavourites = !_showingFavourites;

			Books.Clear();

			if( _showingFavourites ) {
				LoadFavouriteBooks();
			} else {
				_currentPage = 0;
				LoadBooks();
			}

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TitleText)));
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ShowBooksText)));
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Books)));
		}

		public async Task LoadBooks() {
			if( _showingFavourites ) {
				return;
			}

			IEnumerable<Book> books = await Book.GetBooks(_currentPage++);

			foreach( Book book in books ) {
				Books.Add(book);
			}
		}
		private void LoadFavouriteBooks() {
			IEnumerable<Book> books = Book.GetFavouriteBooks();

			foreach( Book book in books ) {
				Books.Add(book);
			}
		}
	}
}
