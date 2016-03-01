using System;

namespace Task3
{
<<<<<<< HEAD
	public static class StringExtensions
	{
		/// <summary>
		/// Returns the first maxLength characters of the string,
		/// or the string itself if it is shorter. 
		/// </summary>
		public static string Truncate(this string s, int maxLength) => (s == null || s.Length <= maxLength) ? s : s.Substring(0, maxLength);
=======
	public class StringExtensions
	{
		public StringExtensions ()
		{
		}
>>>>>>> 7a60a5987a33313d1d3d14dae8bacc4e6351fc81
	}
}

