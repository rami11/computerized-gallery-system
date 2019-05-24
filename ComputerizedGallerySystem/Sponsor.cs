using System;

namespace ComputerizedGallerySystem
{
    public struct Sponsor
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Commission { get; set; }

        public Sponsor(string id, string name, double commission)
        {
            Id = id;
            Name = name;
            Commission = commission;
        }

        public override string ToString()
        {
            return String.Format("{0}\t{1}\t{2}", Id, Name, Commission);
        }
    }
}