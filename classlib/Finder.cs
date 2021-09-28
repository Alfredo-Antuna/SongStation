using System;
using Microsoft.Data.Sqlite;

namespace classlib
{
    public static class Finder
    {

         public static void showAllArtist()
        {   
            using var connection = new SqliteConnection("Data Source=./classlib/Data/songstation.db");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
            @"
                SELECT *
                FROM artists;
            ";
            using var reader = command.ExecuteReader();
            Console.WriteLine(@"Artists:ID - Name");
                Console.WriteLine("___________________________");
            while(reader.Read())
            {
                {
                var id = reader.GetInt32(0);
                var name = reader.GetString(1);

                
                Console.WriteLine($"Row: {id} - {name}");
                }
            }
        }
        public static void showAllAlbums()
        {   
            using var connection = new SqliteConnection("Data Source=./classlib/Data/songstation.db");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
            @"
                SELECT *
                FROM albums;
            ";
            using var reader = command.ExecuteReader();
            Console.WriteLine(@"Albums:ID - Name - artist_id");
                Console.WriteLine("___________________________");
            while(reader.Read())
            {
                {
                var id = reader.GetInt32(0);
                var name = reader.GetString(1);
                var artist_id = reader.GetInt32(2);

                
                Console.WriteLine($"Row: {id} - {name} - {artist_id}");
                }
            }
        }
        public static void showAllSongs()
        {   
            using var connection = new SqliteConnection("Data Source=./classlib/Data/songstation.db");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
            @"
                SELECT *
                FROM songs;
            ";
            using var reader = command.ExecuteReader();
            Console.WriteLine(@"Songs:ID - Name - Genre - Length in Seconds");
                Console.WriteLine("___________________________");
            while(reader.Read())
            {
                {
                var id = reader.GetInt32(0);
                var name = reader.GetString(1);
                var genre = reader.GetString(2);
                var length = reader.GetInt32(3);

                
                Console.WriteLine($"Row: {id} - {name} - {genre} - {length}");
                }
            }
        }
        public static void showSongsLongerThanThreeMinutes()
        {  
            using var connection = new SqliteConnection("Data Source=./classlib/Data/songstation.db");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
            @"
                SELECT *
                FROM songs
                WHERE songs.length > 180;
            ";
            using var reader = command.ExecuteReader();
            Console.WriteLine(@"Songs:ID - Name - Genre - Length in Seconds");
                Console.WriteLine("___________________________");
            while(reader.Read())
            {
                {
                var id = reader.GetInt32(0);
                var name = reader.GetString(1);
                var genre = reader.GetString(2);
                var length = reader.GetInt32(3);

                
                Console.WriteLine($"Row: {id} - {name} - {genre} - {length}");
                }
            }
        }

        public static void showAlbumsByArtist(string name)
        {   
            using var connection = new SqliteConnection("Data Source=./classlib/Data/songstation.db");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
            @"
               SELECT albums.name
                From artists
                JOIN albums on albums.artists_id = artists.id
                WHERE artists.name = $name
            ";
            command.Parameters.AddWithValue("$name",name);
            using var reader = command.ExecuteReader();
            Console.WriteLine($"Albums by {name}");
            Console.WriteLine("___________________________");
            if(!reader.HasRows){Console.WriteLine($"NONE FOUND BY ARTIST: {name}");}
            while(reader.Read())
            {
                {
                var albumName = reader.GetString(0);
                Console.WriteLine($"{albumName}");
                }
            }
        }
        public static void showSongsByArtist(string name)
        {   
            using var connection = new SqliteConnection("Data Source=./classlib/Data/songstation.db");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
            @"
                SELECT songs.name, songs.genre, songs.length
                From tracklist
                JOIN albums on tracklist.albums_id = albums.id
                Join songs on tracklist.songs_id = songs.id
                join artists on albums.artists_id = artists.id
                WHERE artists.name = $name;
            ";
            command.Parameters.AddWithValue("$name",name);
            using var reader = command.ExecuteReader();
            Console.WriteLine($"Songs by {name}");
            Console.WriteLine("___________________________");
            if(!reader.HasRows){Console.WriteLine($"NONE FOUND BY ARTIST: {name}");}
            while(reader.Read())
            {
                {
                var songsName = reader.GetString(0);
                var genre = reader.GetString(1);
                var length = reader.GetInt32(2);
                Console.WriteLine($"{songsName} - {genre} - {length}");
                }
            }
        }
         public static void showByGenre(string genre)
        {  
            using var connection = new SqliteConnection("Data Source=./classlib/Data/songstation.db");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
            @"
                SELECT *
                FROM songs
                WHERE songs.genre = $genre;
            ";
            command.Parameters.AddWithValue("$genre", genre);
            using var reader = command.ExecuteReader();
            Console.WriteLine(@"Songs:ID - Name - Genre - Length in Seconds");
                Console.WriteLine("___________________________");
            if(!reader.HasRows){Console.WriteLine($"NONE FOUND WITH GENRE: {genre}");}
            while(reader.Read())
            {
                
                var id = reader.GetInt32(0);
                var name = reader.GetString(1);
                var outputgenre = reader.GetString(2);
                var length = reader.GetInt32(3);

                
                Console.WriteLine($"Row: {id} - {name} - {outputgenre} - {length}");
                
            }
        }
        public static void showSongsCountByAlbum(string name)
        {   
            using var connection = new SqliteConnection("Data Source=./classlib/Data/songstation.db");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
            @"
                SELECT COUNT(songs.name)
                From tracklist
                JOIN albums on tracklist.albums_id = albums.id
                Join songs on tracklist.songs_id = songs.id
                WHERE albums.name = $name;
                ";
            command.Parameters.AddWithValue("$name",name);
            using var reader = command.ExecuteReader();
            while(reader.Read())
            {
                if(reader.GetInt32(0) == 0)
                {
                    Console.WriteLine($"NONE FOUND FROM ALBUM: {name}");
                }else
                {
                    Console.WriteLine($"Songs from {name} : {reader.GetInt32(0)}");
                }
            }
        }
        public static void showSongsCountbyArtist(string name)
        {
            using var connection = new SqliteConnection("Data Source=./classlib/Data/songstation.db");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
            @"
                SELECT COUNT(songs.name)
                From tracklist
                JOIN albums on tracklist.albums_id = albums.id
                Join songs on tracklist.songs_id = songs.id
                join artists on albums.artists_id = artists.id
                WHERE artists.name = $name;
                ";
            command.Parameters.AddWithValue("$name",name);
            using var reader = command.ExecuteReader();

            while(reader.Read())
            {
            if(reader.GetInt32(0) == 0)
                {
                    Console.WriteLine($"NONE FOUND FROM ALBUM: {name}");
                }else
                {
                    Console.WriteLine($"Songs from {name} : {reader.GetInt32(0)}");
                }
            }
        }


    }
}
