using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_WebSiteMVC_Pipeline.Domain.Utils
{
    public class CsvBaseService<T>
    {
        private readonly CsvConfiguration _csvConfiguration;
        public CsvBaseService()
        {
            _csvConfiguration = GetConfiguration();
        }

        public byte[] UploadFile(IEnumerable data)
        {
            using (var stream = new MemoryStream())
                using(var writer = new StreamWriter(stream)) 
                using(var csvWriter = new CsvWriter(writer, _csvConfiguration))
            {
                csvWriter.WriteRecords(data);
                writer.Flush();
                return stream.ToArray();
            }
        }

        private CsvConfiguration GetConfiguration()
        {
            return new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                Encoding= Encoding.UTF8,
                NewLine= "\r\n"
            };
        }
    }
}
