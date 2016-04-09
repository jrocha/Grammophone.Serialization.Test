using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Grammophone.Serialization.Testing.MusicModel
{
	[Serializable]
	public class GenreSerializationSurrogate : ISerializationSurrogate
	{
		#region ISerializationSurrogate Members

		public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
		{
			if (obj == null) throw new ArgumentNullException("obj");
			if (info == null) throw new ArgumentNullException("info");

			info.AddValue("key", ((Genre)obj).Key);
		}

		public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
		{
			if (info == null) throw new ArgumentNullException("info");

			string key = info.GetString("key");

			var genre = Genre.Get(key);

			if (genre == null) throw new SerializationException(String.Format("No Genre has the specified key '{0}'.", key));

			return genre;
		}

		#endregion
	}
}
