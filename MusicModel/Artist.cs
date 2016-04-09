using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grammophone.Serialization.Testing.MusicModel
{
	[Serializable]
	public class Artist : INamedEntity
	{
		public Artist(string name, Genre mainGenre)
		{
			if (name == null) throw new ArgumentNullException("name");
			if (mainGenre == null) throw new ArgumentNullException("mainGenre");

			this.Name = name;
			this.MainGenre = mainGenre;
		}

		public string Name { get; private set; }

		public Genre MainGenre { get; private set; }
	}
}
