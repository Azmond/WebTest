using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using zadanie1.Models.Generate;

namespace zadanie1.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("sql") {
            Database.SetInitializer<DataContext>(new DataInit());
        }

        public DbSet<MData> Data { get; set; }

    }

    public class DataInit : CreateDatabaseIfNotExists<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            NameGenerator generator = new NameGenerator();
            Random r = new Random();
            MData data;

            for(int i =0; i < 100; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    data = new MData { Name = generator.GenerateName(), Age = r.Next(15, 85) };
                    context.Data.Add(data);
                    context.SaveChanges();
                }
            }
        }



    }



}
