using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gramma.Serialization.Testing.MusicModel
{
	[Serializable]
	public class Genre
	{
		#region Private fields

		private static Dictionary<string, Genre> genresByKey;

		#endregion

		#region Construction

		static Genre()
		{
			genresByKey = new Dictionary<string, Genre>();

			AddGenreToDictionary("classical", "Classical");
			AddGenreToDictionary("pop", "Pop");
			AddGenreToDictionary("electronic", "Electronic");
		}

		private Genre(string key, string name)
		{
			if (key == null) throw new ArgumentNullException("key");
			if (name == null) throw new ArgumentNullException("name");

			this.Key = key;
			this.Name = name;
		}

		#endregion

		#region Public properties

		public string Key { get; private set; }

		public string Name { get; private set; }

		#endregion

		#region Public methods

		public static Genre Get(string key)
		{
			if (key == null) throw new ArgumentNullException("key");

			Genre genre = null;

			genresByKey.TryGetValue(key, out genre);

			return genre;
		}

		#endregion

		#region Private methods

		private static void AddGenreToDictionary(string key, string name)
		{
			var genre = new Genre(key, name);
			genresByKey[key] = genre;
		}

		#endregion

	}
}
