using System;

namespace ComputerizedGallerySystem
{
    public struct Artwork
    {
        public string Id { get; set; }
        public string ArtistId { get; set; }
        public double SellingPrice { get; set; }
        public string AcquisitionYear { get; set; }
        public double EstimatedValue { get; set; }
        public string Title { get; set; }
        public char Status { get; set; }

        public Artwork(string id, string artistId, double sellingPrice,
            string acquisitionYear, double estimatedValue, string title, char status)
        {
            Id = id;
            ArtistId = artistId;
            SellingPrice = sellingPrice;
            AcquisitionYear = acquisitionYear;
            EstimatedValue = estimatedValue;
            Title = title;
            Status = status;
        }

        public override string ToString()
        {
            return String.Format("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}\t\t{6}",
                Id, ArtistId, SellingPrice, AcquisitionYear, EstimatedValue, Title, Status);
        }
    }
}