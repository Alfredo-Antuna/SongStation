using System;
using classlib;
namespace cli
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // Finder.showAllArtist();
             Finder.showAllAlbums();
            // Finder.showAllSongs();
            // Finder.showSongsLongerThanThreeMinutes();
            Finder.showAlbumsByArtist("lil whileLoop");
        }
    }
}
