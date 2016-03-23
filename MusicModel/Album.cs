using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Gramma.Serialization.Testing.MusicModel
{
	[Serializable]
	public class Album : INamedEntity
	{
		#region Private fields

    private string name;

		private Artist artist;

		private Packaging packaging;

		private ReadOnlyCollection<Song> songs;

		private Genre genre;

		private Edition edition;

		#endregion

		#region Construction

		public Album(
      string name, 
      Artist artist, 
      Genre genre, 
      IEnumerable<Song> songs, 
      Packaging packaging, 
      Edition edition)
		{
      if (name == null) throw new ArgumentNullException("name");
      if (artist == null) throw new ArgumentNullException("artist");
			if (songs == null) throw new ArgumentNullException("songs");

      this.name = name;
			this.artist = artist;
			this.genre = genre;
			this.packaging = packaging;
			this.edition = edition;

			this.songs = new ReadOnlyCollection<Song>(songs.ToList());

			foreach (var song in songs)
			{
				song.Album = this;
			}
		}

		#endregion

		#region Public properties

    public string Name
    {
      get
      {
        return name;
      }
    }

		public Artist Artist
		{
			get
			{
				return artist;
			}
		}

		public Packaging Packaging
		{
			get
			{
				return packaging;
			}
		}

		public IList<Song> Songs
		{
			get
			{
				return songs;
			}
		}

		public Genre Genre
		{
			get
			{
				return genre;
			}
		}

		public Edition Edition
		{
			get
			{
				return edition;
			}
		}

		#endregion
	}
}
