﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ConsoleApp.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public string Password { get; set; }

    public string Email { get; set; }

    public short Active { get; set; }

    public string Description { get; set; }

    public string SourceAddress { get; set; }

    public DateTime? Created { get; set; }

    public string BoType { get; set; }

    public byte? Permissions { get; set; }

    public Guid? Key { get; set; }
}