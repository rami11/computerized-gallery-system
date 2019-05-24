using System;

namespace ComputerizedGallerySystem
{
    internal class Program
    {
        private static int _sponsorCount;
        private static int _artistCount;
        private static int _artworkCount;

        private static readonly Sponsor[] Sponsors = new Sponsor[10];
        private static readonly Artist[] Artists = new Artist[10];
        private static readonly Artwork[] Artworks = new Artwork[10];

        private static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine(
                    "\n1. Add sponsor." +
                    "\n2. Add artist." +
                    "\n3. Add artwork." +
                    "\n4. Display sponsors." +
                    "\n5. Display artists." +
                    "\n6. Display artworks." +
                    "\n7. Exit.");

                Console.WriteLine("\nChoose an option:");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        addSponsor();
                        break;
                    case "2":
                        addArtist();
                        break;
                    case "3":
                        addArtwork();
                        break;
                    case "4":
                        displaySponsors();
                        break;
                    case "5":
                        displayArtists();
                        break;
                    case "6":
                        displayArtworks();
                        break;
                    case "7":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Not an option. Please, try again!");
                        break;
                }
            }
        }

        private static void addSponsor()
        {
            try
            {
                Console.WriteLine("Adding sponsor:");
                Console.WriteLine("---------------");

                Console.WriteLine("Enter sponsor ID:");
                var id = Console.ReadLine();
                validateSponsorId(id);

                Console.WriteLine("Enter name:");
                var name = Console.ReadLine();

                Console.WriteLine("Enter commission:");
                var commission = double.Parse(Console.ReadLine());

                var sponsor = new Sponsor(id, name, commission);

                Sponsors[_sponsorCount++] = sponsor;

                Console.WriteLine("Sponsor added!");
            }
            catch (FormatException e)
            {
                Console.Error.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static string chooseSponsor()
        {
            displaySponsors();

            Console.WriteLine("Choose a sponsor by entering its ID:");
            var sponsorId = Console.ReadLine();

            for (var i = 0; i < _sponsorCount; i++)
                if (Sponsors[i].Id.Equals(sponsorId))
                    return sponsorId;
            return null;
        }

        private static void addArtist()
        {
            try
            {
                Console.WriteLine("Adding artist:");
                Console.WriteLine("--------------");
                var sponsorId = chooseSponsor();

                if (sponsorId != null)
                {
                    Console.WriteLine("Enter artist ID:");
                    var id = Console.ReadLine();

                    Console.WriteLine("Enter name:");
                    var name = Console.ReadLine();

                    var artist = new Artist(id, name, sponsorId);
                    Artists[_artistCount++] = artist;
                }
                else
                {
                    string zero;
                    do
                    {
                        Console.WriteLine("Please, enter 0");
                        zero = Console.ReadLine();
                    } while (!zero.Equals("0"));

                    addSponsor();
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }

        private static string chooseArtist()
        {
            displayArtists();

            Console.WriteLine("Choose an artist by entering its ID:");
            var artistId = Console.ReadLine();

            for (var i = 0; i < _artistCount; i++)
                if (Artists[i].Id.Equals(artistId))
                    return artistId;
            return null;
        }

        private static void addArtwork()
        {
            try
            {
                var artistId = chooseArtist();

                if (artistId != null)
                {
                    Console.WriteLine("Adding artwork:");
                    Console.WriteLine("--------------");

                    Console.WriteLine("Enter ID:");
                    var id = Console.ReadLine();

                    Console.WriteLine("Enter acquisition year:");
                    var acquisitionYear = Console.ReadLine();

                    Console.WriteLine("Enter selling price:");
                    var sellingPrice = double.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Estimated value:");
                    var estimatedValue = double.Parse(Console.ReadLine());

                    Console.WriteLine("Enter title:");
                    var title = Console.ReadLine();

                    Console.WriteLine("Enter status:");
                    var status = (char) Console.Read();

                    var artwork = new Artwork(id, artistId, sellingPrice, acquisitionYear, estimatedValue, title,
                        status);
                    Artworks[_artworkCount++] = artwork;

                    Console.WriteLine("Artwork added!");
                }
                else
                {
                    addArtist();
                }
            }
            catch (FormatException e)
            {
                Console.Error.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }

        private static void displaySponsors()
        {
            Console.WriteLine("Sponsors:");
            Console.WriteLine("ID\tName\tCommission");
            for (var i = 0; i < _sponsorCount; i++) Console.WriteLine(Sponsors[i]);
        }

        private static void displayArtists()
        {
            Console.WriteLine("Artists:");
            Console.WriteLine("ID\tName\t\tSponsor ID");
            for (var i = 0; i < _artistCount; i++) Console.WriteLine(Artists[i]);
        }

        private static void displayArtworks()
        {
            Console.WriteLine("Artworks:");
            Console.WriteLine("ID\tArtist ID\tSelling Price\tAcquisition Year\tEstimated Value\tTitle\tStatus");
            for (var i = 0; i < _artworkCount; i++) Console.WriteLine(Artworks[i]);
        }

        private static void validateId<T>(T[] array, int arrayLength, string id)
        {
            for (var i = 0; i < arrayLength; i++)
                if (array[i].Equals(id))
                    throw new Exception("Invalid ID!");
        }

        private static void validateSponsorId(string id)
        {
            for (var i = 0; i < _sponsorCount; i++)
                if (Sponsors[i].Id.Equals(id))
                    throw new Exception("Invalid ID!");
        }

        private static void validateArtistId(string id)
        {
            for (var i = 0; i < _artistCount; i++)
                if (Artists[i].Id.Equals(id))
                    throw new Exception("Invalid ID!");
        }

        private static void validateArtworkId(string id)
        {
            for (var i = 0; i < _artworkCount; i++)
                if (Artworks[i].Id.Equals(id))
                    throw new Exception("Invalid ID!");
        }
    }
}