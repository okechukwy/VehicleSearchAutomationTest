using LINQtoCSV;
using CsvContext = LINQtoCSV.CsvContext;

namespace VehicleSearchAutomationTest.ExcelReader
{
    [Serializable]
    public class CarValuation
    {
        [CsvColumn(Name = "REGISTRATION", FieldIndex = 1)]
        public string Registration { get=> Registration; set => Registration = value; }

        [CsvColumn(Name = "MAKE", FieldIndex = 2)]
        public string Make { get => Make; set => Make = value; }

        [CsvColumn(Name = "MODEL", FieldIndex = 3)]
        public string Model { get => Model; set => Model = value; }

       
        //Reading csv file
        public string? ReadCsvFile()
        {
            var csvFileDescription = new CsvFileDescription
            {
                FirstLineHasColumnNames = true,
                IgnoreUnknownColumns = true,
                SeparatorChar = ',',  
                UseFieldIndexForReadingData = false,
            };

            var csvContext = new CsvContext();
            var csvReader = csvContext.Read<CarValuation>("car_input_v1.csv", csvFileDescription);
            
            return csvReader.ToString();

        }

        //Write to csv file
        public void WriteCsvToFile(string option)
        {
            var varValuation = new List<CarValuation>()
            {
                new CarValuation()
            };
            var csvFileDescription = new CsvFileDescription
            {
                FirstLineHasColumnNames = true,
                SeparatorChar = ','
            };

            var csvContext = new CsvContext();
            csvContext.Write(option, "output.csv", csvFileDescription);

        }


        
         private static object GetData(Type type, object data)
         {
             switch (type.Name)
             {
                 case "String":
                     return data.ToString();
                 case "Double":
                     return Convert.ToDouble(data);
                 case "DateTime":
                     return Convert.ToDateTime(data);
                 default:
                     return data.ToString();
             }
         }
    }

    public class Cars
    {
        public string Registration { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
    }
}
