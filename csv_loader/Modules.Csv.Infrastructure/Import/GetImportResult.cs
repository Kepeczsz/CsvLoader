namespace Modules.Csv.Infrastructure.Import;

public record GetImportResult<T> (T EntityList, ImportResult ImportResult);