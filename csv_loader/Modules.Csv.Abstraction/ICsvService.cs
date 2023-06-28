using CsvHelper.Configuration;

namespace Modules.Csv.Abstractions;

public interface ICsvService<T>
{
    /// <summary>
    /// Reads a list of data records from a CSV file using the provided path and CsvConfiguration.
    /// If the CSV file does not start with the expected header, the header is added.
    /// </summary>
    /// <typeparam name="THeader">The type used for generating the expected CSV file header.
    /// This should have properties corresponding to headers in the CSV file.</typeparam>
    /// <param name="path">The path to file containing the CSV data.</param>
    /// <param name="csvConfig">The CsvConfiguration for parsing the CSV file.</param>
    /// <returns>A list of data records of type T.</returns>
    public Task<List<T>> GetRecordsFromCsv<THeader>(string path, CsvConfiguration csvConfig);
}