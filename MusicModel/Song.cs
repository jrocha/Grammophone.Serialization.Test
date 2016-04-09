using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Grammophone.Serialization.Testing.MusicModel
{
	[Serializable]
	public class Song : ISerializable, INamedEntity
	{
		#region Construction

		public Song(string name, Artist artist, Genre genre)
		{
			if (name == null) throw new ArgumentNullException("name");
			if (artist == null) throw new ArgumentNullException("artist");
			if (genre == null) throw new ArgumentNullException("genre");

			this.Name = name;
			this.Artist = artist;
			this.Genre = genre;
		}

		private Song(SerializationInfo info, StreamingContext context)
		{
			if (info == null) throw new ArgumentNullException("info");

			this.Name = info.GetString("name");
			this.Artist = (Artist)info.GetValue("artist", typeof(Artist));
			this.Genre = (Genre)info.GetValue("genre", typeof(Genre));
			this.Album = (Album)info.GetValue("album", typeof(Album));
		}

		#endregion

		#region Public properties

		public string Name { get; private set; }

		public Artist Artist { get; private set; }

		public Genre Genre { get; private set; }

		public Album Album { get; internal set; }

		#endregion

		#region ISerializable Members

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("name", this.Name);
			info.AddValue("artist", this.Artist, typeof(Artist));
			info.AddValue("genre", this.Genre);
			info.AddValue("album", this.Album);
		}

		#endregion
	}
}
