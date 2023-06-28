using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Csv.Infrastructure.Import;

public record ImportResult
{
    /// <summary>
    /// List of error messages encountered during the import operation. If no errors occurred, this will be null or empty.
    /// </summary>
    public List<string>? ErrorsList { get; init; }
}

