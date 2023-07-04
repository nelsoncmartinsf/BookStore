using System;
using System.Collections.Generic;
using BookStore.Models;
using BookStore.Views;
using Xamarin.Forms;

namespace BookStore {
	public partial class App : Application {
		public App() {
			InitializeComponent();

			MainPage = new NavigationPage(new BooksPage());
		}

		protected override void OnStart() {
			//if( !Application.Current.Properties.ContainsKey(nameof(Book)) ) {
			//	Application.Current.Properties.Add(nameof(Book), new Dictionary<String, String>());
			//	Application.Current.SavePropertiesAsync();
			//}
		}

		protected override void OnSleep() {
			Application.Current.SavePropertiesAsync();
		}

		protected override void OnResume() {
		}
	}
}
