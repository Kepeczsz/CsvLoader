﻿namespace Modules.User.Domain;

public class Client
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public Client(Guid id, string name, string surname, string email, string phoneNumber)
    {
        Id = id;
        Name = name;
        Surname = surname;
        Email = email;
        PhoneNumber = phoneNumber;
    }
}