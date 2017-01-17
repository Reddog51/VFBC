using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONFields
{
    class Program
    {
        const string jsonText =
            "{" +
            " \"FirstValue\": 1.1," +
            " \"SecondValue\": \"some text\"," +
            " \"TrueValue\": true" +
            "}";
        static void Main(string[] args)
        {
            // 1. parse sample

            Console.WriteLine();
            Console.WriteLine("Source data:");
            Console.WriteLine(jsonText);
            Console.WriteLine();

            JsonTextParser parser = new JsonTextParser();
            JsonObject obj = parser.Parse(jsonText);

            Console.WriteLine();
            Console.WriteLine("Parsed data with indentation in JSON data format:");
            Console.WriteLine(obj.ToString());
            Console.WriteLine();


            JsonUtility.GenerateIndentedJsonText = false;

            Console.WriteLine();
            Console.WriteLine("Parsed data without indentation in JSON data format:");
            Console.WriteLine(obj.ToString());
            Console.WriteLine();


            // enumerate values in json object
            Console.WriteLine();
            Console.WriteLine("Parsed object contains these nested fields:");
            foreach (JsonObject field in obj as JsonObjectCollection)
            {
                string name = field.Name;
                string value = string.Empty;
                string type = field.GetValue().GetType().Name;

                // try to get value.
                switch (type)
                {
                    case "String":
                        value = (string)field.GetValue();
                        break;

                    case "Double":
                        value = field.GetValue().ToString();
                        break;

                    case "Boolean":
                        value = field.GetValue().ToString();
                        break;

                    default:
                        // in this sample we'll not parse nested arrays or objects.
                        throw new NotSupportedException();
                }

                Console.WriteLine("{0} {1} {2}",
                    name.PadLeft(15), type.PadLeft(10), value.PadLeft(15));
            }

            Console.WriteLine();


            // 2. generate sample
            Console.WriteLine();

            // root object
            JsonObjectCollection collection = new JsonObjectCollection();

            List<string> JSONFieldNames = new List<string>();
            JSONFieldNames = ConfigurationManager.AppSettings["JsonPostFields"].ToString().Split(new char[] { '|' }).ToList();
            // nested values
            collection.Add(new JsonStringValue(JSONFieldNames[0], "test title"));
            collection.Add(new JsonStringValue(JSONFieldNames[1], "test caption"));
            collection.Add(new JsonStringValue(JSONFieldNames[2], "should be file"));


            Console.WriteLine("Generated object:");
            JsonUtility.GenerateIndentedJsonText = true;
            Console.WriteLine(collection);

            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
