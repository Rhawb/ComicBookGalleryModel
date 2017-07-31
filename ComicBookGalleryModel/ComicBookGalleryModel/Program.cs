using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ComicBookGalleryModel
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var context = new Context())
			{


				var comicBooks = context.ComicBooks
					.Include(cb => cb.Series)
					.Include(cb => cb.Artists.Select(a => a.Artist))
					.Include(cb => cb.Artists.Select(a => a.Role))
					.ToList();

				foreach(var comicbook in comicBooks)
				{
					var artistRoleNames = comicbook.Artists
						.Select(a => $"{a.Artist.Name} - {a.Role.Name}").ToList();
					var artistRolesDisplayText = string.Join(", ", artistRoleNames);

					Console.WriteLine(comicbook.DisplayText);
					Console.WriteLine(artistRolesDisplayText);
				}
				Console.ReadLine();
			}
		}
	}
}
