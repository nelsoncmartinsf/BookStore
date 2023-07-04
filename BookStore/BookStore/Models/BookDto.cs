using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Models {

	public class BooksResponse {
		public String Kind { get; set; }
		public Int32 TotalItems { get; set; }
		public BookDto[] Items { get; set; }
	}

	public class BookDto {
		public String Kind { get; set; }
		public String Id { get; set; }
		public String Etag { get; set; }
		public String SelfLink { get; set; }
		public VolumeInfoDto VolumeInfo { get; set; }
		public SaleInfoDto SaleInfo { get; set; }
		public AccessInfoDto AccessInfo { get; set; }
		public SearchInfoDto SearchInfo { get; set; }
	}

	public class VolumeInfoDto {
		public String Title { get; set; }
		public String Subtitle { get; set; }
		public String[] Authors { get; set; }
		public String Publisher { get; set; }
		public String PublishedDate { get; set; }
		public String Description { get; set; }
		public IndustryIdentifierDto[] IndustryIdentifiers { get; set; }
		public ReadingModesDto ReadingModes { get; set; }
		public Int32 PageCount { get; set; }
		public String PrintType { get; set; }
		public String[] Categories { get; set; }
		public String MaturityRating { get; set; }
		public Boolean AllowAnonLogging { get; set; }
		public String ContentVersion { get; set; }
		public PanelizationSummaryDto PanelizationSummary { get; set; }
		public ImageLinksDto ImageLinks { get; set; }
		public String Language { get; set; }
		public String PreviewLink { get; set; }
		public String InfoLink { get; set; }
		public String CanonicalVolumeLink { get; set; }
	}

	public class ReadingModesDto {
		public Boolean Text { get; set; }
		public Boolean Image { get; set; }
	}

	public class PanelizationSummaryDto {
		public Boolean ContainsEpubBubbles { get; set; }
		public Boolean ContainsImageBubbles { get; set; }
	}

	public class ImageLinksDto {
		public String SmallThumbnail { get; set; }
		public String Thumbnail { get; set; }
	}

	public class IndustryIdentifierDto {
		public String Type { get; set; }
		public String Identifier { get; set; }
	}

	public class SaleInfoDto {
		public String Country { get; set; }
		public String Saleability { get; set; }
		public Boolean IsEbook { get; set; }
		public ListPriceDto ListPrice { get; set; }
		public RetailPriceDto RetailPrice { get; set; }
		public String BuyLink { get; set; }
		public OfferDto[] Offers { get; set; }
	}

	public class ListPriceDto {
		public Single Amount { get; set; }
		public String CurrencyCode { get; set; }
	}

	public class RetailPriceDto {
		public Single Amount { get; set; }
		public String CurrencyCode { get; set; }
	}

	public class OfferDto {
		public Int32 FinskyOfferType { get; set; }
		public ListPriceDto ListPrice { get; set; }
		public RetailPriceDto RetailPrice { get; set; }
	}

	public class AccessInfoDto {
		public String Country { get; set; }
		public String Viewability { get; set; }
		public Boolean Embeddable { get; set; }
		public Boolean PublicDomain { get; set; }
		public String TextToSpeechPermission { get; set; }
		public EpubDto Epub { get; set; }
		public PdfDto Pdf { get; set; }
		public String WebReaderLink { get; set; }
		public String AccessViewStatus { get; set; }
		public Boolean QuoteSharingAllowed { get; set; }
	}

	public class EpubDto {
		public Boolean IsAvailable { get; set; }
		public String AcsTokenLink { get; set; }
	}

	public class PdfDto {
		public Boolean IsAvailable { get; set; }
		public String AcsTokenLink { get; set; }
	}

	public class SearchInfoDto {
		public String TextSnippet { get; set; }
	}
























}
