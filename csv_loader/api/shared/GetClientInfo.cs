using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.User.Application.shared;
public record GetClientInfo
{
    [Name("id")]
    public string Id { get; set; }
    [Name("name")]
    public string Name { get; set; }
    [Name("surname")]
    public string Surname { get; set; }
    [Name("email")]
    public string Email { get; set; }
    [Name("phone")]
    public string PhoneNumber { get; set; }
}

