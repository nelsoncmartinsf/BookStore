using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore.Views {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BookDetailsPage : ContentPage {
		private BookDetailsViewModel _viewModel;

		public BookDetailsPage(Book book) {
			InitializeComponent();

			_viewModel = new BookDetailsViewModel(book);
			this.BindingContext = _viewModel;
		}
	}
}