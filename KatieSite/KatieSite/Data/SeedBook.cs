using System.Linq;
using System;
using KatieSite.Models;

namespace KatieSite.Data
{
	public class SeedBook
	{
		public static async void Seed(RpgDbContext context, IServiceProvider provider)
		{
			if (!context.Publishers.Any() || !context.RpgBooks.Any())
			{
				Publisher p1 = new Publisher
				{
					Name = "Wizards of the Coast"
				};
				Publisher p2 = new Publisher
				{
					Name = "Paizo"
				};
				Publisher p3 = new Publisher
				{
					Name = "Sine Nomine Publishing"
				};
				context.Publishers.Add(p1);
				context.Publishers.Add(p2);
				context.Publishers.Add(p3);
				await context.SaveChangesAsync();

				RpgBook b1 = new RpgBook
				{
					Name = "Dungeons and Dragons",
					Description = "The most popular RPG currently. 5 current editions, with a new one D&D edition on the way.",
					Published = DateTime.Now,
					PublishedBy = p1
				};

				RpgBook b2 = new RpgBook
				{
					Name = "Pathfinder",
					Description = "Originating from D&D 3.5, Pathfinder now has two editions and is rapidly gaining a fan base.",
					Published = DateTime.Now,
					PublishedBy = p2
				};

				RpgBook b3 = new RpgBook
				{
					Name = "Stars without Number",
					Description = "A sci-fi RPG made with a modular design. You can customize it however you wish. Part of the OSR.",
					Published = DateTime.Now,
					PublishedBy = p3
				};

				context.RpgBooks.Add(b1);
				context.RpgBooks.Add(b2);
				context.RpgBooks.Add(b3);
				await context.SaveChangesAsync();
			}
		}
	}
}
