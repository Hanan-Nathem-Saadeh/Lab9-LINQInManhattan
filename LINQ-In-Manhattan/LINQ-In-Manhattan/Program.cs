using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;


namespace LINQ_In_Manhattan
{
    public class Program
    {
        static void Main(string[] args)
        {

            string JsonPath = "../../../data.json";
            string JsonContant = File.ReadAllText(JsonPath);
            // Console.WriteLine(JsonContant);
            FeatureCollection objectFromJson = JsonConvert.DeserializeObject<FeatureCollection>(JsonContant);
            Console.WriteLine("******************************************************");
            Console.WriteLine("*************** Welcome To My System *****************");
            Console.WriteLine("**************** HANAN NATHEM SAADEH *****************");
            Console.WriteLine("******************************************************");
            Console.WriteLine();


            AllNeighborhoods(objectFromJson);
            NeighborhoodsNotHaveNames(objectFromJson);
            RemoveDuplicates(objectFromJson);
            ConsolidateAllQueries(objectFromJson);
            LINQQuery(objectFromJson);
        }
       public static void AllNeighborhoods(FeatureCollection objectFromJson )
        {
            Console.WriteLine("Question Number One:  Output all of the neighborhoods in this data list (Final Total: 147 neighborhoods)");
            var query = from Feature in objectFromJson.features
                        select Feature.Properties.neighborhood;
            int count = 1;
            foreach(string neighborhood in query)
            {
                Console.WriteLine(count+"- "+ neighborhood);
                count++;

            }
        }
        public static void NeighborhoodsNotHaveNames(FeatureCollection objectFromJson)
        {
            Console.WriteLine("Question Number Two: Filter out all the neighborhoods that do not have any names (Final Total: 143)");
            var query = from Feature in objectFromJson.features
                        where Feature.Properties.neighborhood !=""
                        select Feature.Properties.neighborhood;
            int count = 1;
            foreach (string neighborhood in query)
            {
                Console.WriteLine(count + "- " + neighborhood);
                count++;
            }
        }
       public static void RemoveDuplicates(FeatureCollection objectFromJson)
        {
            Console.WriteLine("Question Number Three: Remove the duplicates (Final Total: 39 neighborhoods)");
            var query = from Feature in objectFromJson.features
                        where Feature.Properties.neighborhood != ""
                        select Feature.Properties.neighborhood;
            int count = 1;
            foreach (string neighborhood in query.Distinct())
            {
                Console.WriteLine(count + "- " + neighborhood);
                count++;

            }
        }
        public static void ConsolidateAllQueries(FeatureCollection objectFromJson)
        {
            Console.WriteLine("Question Number Four: Rewrite the queries from above and consolidate all into one single query.");
            var query = objectFromJson.features
                .Select(x => new { x.Properties.neighborhood })
               // .GroupBy(x => x.Properties.neighborhood)
                .Where(x => x.neighborhood != "").Distinct();
            int count = 1;
            foreach (var item in query)
            {
                Console.WriteLine(count + "- " + item.neighborhood);
                count++;
            }
        }
        public static void LINQQuery(FeatureCollection objectFromJson)
        {
            Console.WriteLine("Question Number Five: Rewrite at least one of these questions only using the opposing method ");
            // rewrite the secont method
            var query = objectFromJson.features
              .Select(x => new { x.Properties.neighborhood })
              .Where(x => x.neighborhood != "");
            int count = 1;

            foreach (var neighborhood in query)
            {
                Console.WriteLine(count + "- " + neighborhood.neighborhood);
                count++;
            }

        }
    }
}
