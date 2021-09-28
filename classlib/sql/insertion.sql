-- INSERT INTO artists (name) VALUES ("lil whileLoop");
-- INSERT INTO artists (name) VALUES ("Rapper");
-- INSERT INTO artists (name) VALUES ("rockband");
-- INSERT INTO artists (name) VALUES ("earth wind and fire");

-- INSERT INTO albums (name, artists_id) VALUES ("theAlbum",1);
-- INSERT INTO albums (name, artists_id) VALUES ("views",2);
-- INSERT INTO albums (name, artists_id) VALUES ("Albumone",1);
-- INSERT INTO albums (name, artists_id) VALUES ("myalbum",3);
-- INSERT INTO albums (name, artists_id) VALUES ("albumname",4);


-- INSERT INTO songs (name,genre,length) VALUES ("mysong","classical",300);
-- INSERT INTO songs (name,genre,length) VALUES ("songe0n3","rap",222);
-- INSERT INTO songs (name,genre,length) VALUES ("thesong","classical",300);
-- INSERT INTO songs (name,genre,length) VALUES ("september","rock",111);
-- INSERT INTO songs (name,genre,length) VALUES ("thatsong","classical",200);
-- INSERT INTO songs (name,genre,length) VALUES ("song","rap",1000);

-- INSERT INTO tracklist (albums_id, songs_id) VALUES (1,1);
-- INSERT INTO tracklist (albums_id, songs_id) VALUES (2,1);
-- INSERT INTO tracklist (albums_id, songs_id) VALUES (1,3);
-- INSERT INTO tracklist (albums_id, songs_id) VALUES (3,3);
-- INSERT INTO tracklist (albums_id, songs_id) VALUES (5,4);
-- INSERT INTO tracklist (albums_id, songs_id) VALUES (5,6);
-- INSERT INTO tracklist (albums_id, songs_id) VALUES (1,6);
-- INSERT INTO tracklist (albums_id, songs_id) VALUES (2,5);


-- SELECT * from tracklist;
-- select * from albums;
-- select * from artists;
SELECT albums.name
From artists
JOIN albums on albums.artists_id = artists.id
WHERE artists.name = "lil whileLoop"





