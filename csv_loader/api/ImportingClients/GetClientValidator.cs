using FluentValidation;
using Modules.User.Application.shared;
using Modules.User.Domain;

namespace Modules.User.Application.ImportingClients;

public class GetClientValidator : AbstractValidator<Client>
{
    public GetClientValidator()
    {
        this.RuleFor(client => client.Name)
            .NotEmpty()
            .WithMessage("Client name is missing.")
            .Length(1, 50)
            .WithMessage("Client name has to be one character or less than 50");

        this.RuleFor(client => client.Surname)
            .NotEmpty()
            .WithMessage("Client surname is missing.")
            .Length(1, 50)
            .WithMessage("Client surname has to be one character or less than 50");

        this.RuleFor(client => client.PhoneNumber)
            .NotEmpty()
            .WithMessage("Client Phone Number is missing")
            .Length(1, 20)
            .WithMessage("Client phone number has to be between 1 and 20 characters")
            .Matches("^[0-9]+$")
            .WithMessage("Client phone number should contain only numbers");


        this.RuleFor(client => client.Email)
            .NotEmpty()
            .WithMessage("Client Email is missing")
            .Length(1, 50)
            .WithMessage("Client Email has to be one character or less than 50");
    }
}