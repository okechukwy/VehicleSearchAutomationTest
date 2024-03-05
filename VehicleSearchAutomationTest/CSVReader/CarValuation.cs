using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelDataReader;
using LINQtoCSV;

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
/*
            foreach(var row in csvReader)
            {
               Console.WriteLine(row.Registration, row.Make, row.Model);
            }*/

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


        /* private static IDictionary<string, IExcelDataReader> _cache;
         private static FileStream stream;
         private static IExcelDataReader reader;

         *//* public static string ExcelReaderHelper()
          {
              _cache = new Dictionary<string, IExcelDataReader>();

          }*//*

         private static IExcelDataReader GetExcelReader(string xlPath, string sheetName)
         {
             if (_cache.ContainsKey(sheetName))
             {
                 reader = _cache[sheetName];
             }
             else
             {
                 stream = new FileStream(xlPath, FileMode.Open, FileAccess.Read);
                 reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                 _cache.Add(sheetName, reader);
             }
             return reader;
         }

         *//* public static int GetTotalRows(string xlPath, string sheetName)
          {
              IExcelDataReader _reader = GetExcelReader(xlPath, sheetName);
              return _reader.AsDataSet().Tables[sheetName].Rows.Count;
          }

          public static object GetCellData(string xlPath, string sheetName, int row, int column)
          {

              IExcelDataReader _reader = GetExcelReader(xlPath, sheetName);
              DataTable table = _reader.AsDataSet().Tables[sheetName];
              return table.Rows[row][column];
          }*//*

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
         }*/
    }
}
