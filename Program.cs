using EsercizioSuEntityFramework_Linq.Database;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EsercizioSuEntityFramework_Linq
{
    internal class Program
    {
        static  void Main(string[] args)
        {
            List<RootObject> list = new List<RootObject>();

            using (StreamReader r = new StreamReader("C:\\Users\\Vittorio\\source\\repos\\EsercizioSuEntityFramework_Linq\\Car.json"))
            {
                string json = r.ReadToEnd();
                list = JsonConvert.DeserializeObject<List<RootObject>>(json);
            }

            using var dbContext = new CarContext();

            foreach (var item in list)
            {
                dbContext.Add(item);

                dbContext.Database.OpenConnection();
                try
                {
                    dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.RootObject ON");
                    dbContext.SaveChanges();
                    dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.RootObject OFF");
                }
                finally
                {
                    dbContext.Database.CloseConnection();
                }
               
            }
            bool created =dbContext.Database.EnsureCreated();
            Console.WriteLine(created ? "Database Creato" : "Database già esistente");
        

        }
    }
}  

//dbContext.Database.OpenConnection();
            //try
            //{
            //    //.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Car ON");

            //    //dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Car OFF");
            //}
            //finally
            //{
            //    dbContext.Database.CloseConnection();
            //}