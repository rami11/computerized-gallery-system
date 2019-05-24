using System;

namespace ComputerizedGallerySystem
{
    public struct Artist
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SponsorId { get; set; }

        public Artist(string id, string name, string sponsorId)
        {
            Id = id;
            Name = name;
            SponsorId = sponsorId;
        }

        public override string ToString()
        {
            return String.Format("{0}\t{1}\t\t{2}", Id, Name, SponsorId);
        }
    }
}