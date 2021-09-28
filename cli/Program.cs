using System;
using classlib;
namespace cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var cliControl = true;
            while(cliControl)
            {
                Console.WriteLine(@"
                Press 0 to display the artists in the system
                Press 1 to display the albums in the system
                Press 2 to display the songs in the system
                Press 3 to display songs longer than 3 minutes
                Press 4 to display albums by a particular artist
                Press 5 to display songs by a particular artist
                Press 6 to display find the total songs by artist
                Press 7 to display songs by a certain genre
                Press 8 to display find the number of songs by album
                or Press Enter with no input to exit
                ");
                var option = Console.ReadLine();
                switch (option)
                {
                    
                    case "0":
                    {
                        Finder.showAllArtist();
                        break;
                    }
                    case "1":
                    {
                        Finder.showAllAlbums();
                        break;
                    }
                    case "2":
                    {
                        Finder.showAllSongs();
                        break;
                    }
                    case "3":
                    {
                        Finder.showSongsLongerThanThreeMinutes();
                        break;
                    }
                    case "4":
                    {

                        Console.WriteLine("Please Input Artist:");
                        var input = Console.ReadLine();
                        Finder.showAlbumsByArtist(input);
                        break;
                    }
                    case "5":
                    {
                        Console.WriteLine("Please Input Artist:");
                        var input = Console.ReadLine();
                        Finder.showSongsByArtist(input);
                        break;
                    }
                    case "6":
                    {
                        //TODO
                        Console.WriteLine("Please Input Artist:");
                        var input = Console.ReadLine();
                        Finder.showSongsCountbyArtist(input);
                        break;
                       
                    }
                    case "7":
                    {
                        Console.WriteLine("Please Input Genre:");
                        var input = Console.ReadLine();
                        Finder.showByGenre(input);
                        break;
                    }
                    case "8":
                    {
                        Console.WriteLine("Please Input Album:");
                        var input = Console.ReadLine();
                        Finder.showSongsCountByAlbum(input);
                        break;
                    }
                    case "":
                    {
                        cliControl = false;
                        break;
                    }
                }
               
            }
        }
    }
}
