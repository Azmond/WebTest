namespace zadanie1.Migrations
{
    using Models;
    using Models.Generate;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<zadanie1.Models.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(zadanie1.Models.DataContext context)
        {
            if (context.Data.Count() < 100)
            {
                NameGenerator generator = new NameGenerator();
                Random r = new Random();
                MData data;

                for (int i = 0; i < 100; i++)
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        data = new MData { Name = generator.GenerateName(), Age = r.Next(15, 85) };
                        context.Data.Add(data);
                        context.SaveChanges();
                    }
                }
            }


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
