using CsvHelper;
using CsvHelper.Configuration;
using Modules.Csv.Abstractions;
using Modules.Csv.Infrastructure;
using System.Text;

namespace Modules.Csv.Infrastructure;

public class CsvService<T> : ICsvService<T>
{
    public async Task<List<T>> GetRecordsFromCsv<THeader>(string path, CsvConfiguration csvConfig)
    {
        string fileContent;
        using (StreamReader reader = new StreamReader(path))
        {
            fileContent = reader.ReadToEnd();
        }

        string expectedHeader = GenerateExpectedHeader<THeader>();

        if (!fileContent.StartsWith(expectedHeader))
        {
            fileContent = expectedHeader + "\n" + fileContent;
        }

        fileContent = fileContent.Replace("\"", string.Empty);

        byte[] byteArray = Encoding.UTF8.GetBytes(fileContent);
        var stream = new MemoryStream(byteArray);

        using var streamReader = new StreamReader(stream);
        using var csv = new CsvReader(streamReader, csvConfig);

        await csv.ReadAsync();
        return csv.GetRecords<T>().ToList();
    }

    /// <summary>
    /// Generates the expected CSV header based on the properties of a given type.
    /// </summary>
    /// <typeparam name="THeader">The type of data that will be used to generate the CSV header.</typeparam>
    /// <returns>A string representing the expected CSV header.</returns>
    private string GenerateExpectedHeader<THeader>()
    {
        string[] headerFields = typeof(T)
            .GetProperties()
            .Select(property => property.Name)
            .ToArray();

        return string.Join(",", headerFields);
    }
}

