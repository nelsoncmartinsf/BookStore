using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace BookStore.Models {
	[JsonObject]
	public class Book {
		[JsonProperty("id")]
		public String Id { get; private set; }
		[JsonProperty("title")]
		public String Title { get; private set; }
		[JsonProperty("subitle")]
		public String Subtitle { get; private set; }
		[JsonProperty("description")]
		public String Description { get; private set; }
		[JsonProperty("authors")]
		public String Authors { get; private set; }
		[JsonProperty("purchaseUrl")]
		public String PurchaseUrl { get; private set; }
		[JsonProperty("imageUrl")]
		public String ImageUrl { get; private set; }

		[JsonIgnore]
		public Boolean IsFavourite {
			get {
				return Application.Current.Properties.ContainsKey(Id);
			}
			set {
				if( !value ) {
					Application.Current.Properties.Remove(Id);
				} else {
					String serializedObject = JsonConvert.SerializeObject(this);

					if( !Application.Current.Properties.ContainsKey(Id) ) {
						Application.Current.Properties.Add(Id, serializedObject);
					} else {
						Application.Current.Properties[Id] = serializedObject;
					}
				}

				Application.Current.SavePropertiesAsync();
			}
		}

		private static HttpClient _httpClient = new HttpClient();
		private static Int32 _pageSize = 20;
		public static async Task<IEnumerable<Book>> GetBooks(Int32 page) {
			try {
				HttpResponseMessage response = await _httpClient.GetAsync($"https://www.googleapis.com/books/v1/volumes?q=ios&maxResults={_pageSize}&startIndex={_pageSize * page}");

				if( !response.IsSuccessStatusCode ) {
					return null;
				}

				String responseContent = await response.Content.ReadAsStringAsync();
				BooksResponse booksResponse = JsonConvert.DeserializeObject<BooksResponse>(responseContent);

				if( booksResponse.Items?.Any() != true ) {
					return Enumerable.Empty<Book>();
				}

				IEnumerable<Book> books = booksResponse.Items.Select(item => new Book(item));

				return books;
			} catch( HttpRequestException ) {
				return null;
			}
		}

		public static IEnumerable<Book> GetFavouriteBooks() {
			List<Book> books = new List<Book>();

			foreach( String id in Application.Current.Properties.Keys ) {
				if( JsonConvert.DeserializeObject<Book>((String) Application.Current.Properties[id]) is Book book ) {
					books.Add(book);
				}
			}

			return books;
		}

		public Book() { }
		public Book(BookDto dto) {
			if( dto == null ) {
				throw new ArgumentNullException(nameof(dto));
			}

			Id = dto.Id;

			if( dto.VolumeInfo != null ) {
				Title = dto.VolumeInfo.Title;
				Subtitle = dto.VolumeInfo.Subtitle;
				Description = dto.VolumeInfo.Description;
				PurchaseUrl = dto.SaleInfo.BuyLink;

				if( dto.VolumeInfo.Authors?.Any() == true ) {
					Authors = String.Join(", ", dto.VolumeInfo.Authors);
				}

				ImageUrl = dto.VolumeInfo.ImageLinks?.SmallThumbnail?.Replace("http://", "https://");
			}
		}
	}
}
