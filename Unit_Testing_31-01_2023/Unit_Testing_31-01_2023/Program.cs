﻿// See https://aka.ms/new-console-template for more information
using Unit_Testing_31_01_2023;

Console.WriteLine("Hello, World!");
BankAccount ba=new BankAccount("Mr. Bryan Walton",11.99);
ba.Credit(5.77);
ba.Debit(11.22);
Console.WriteLine("Current balance is ${0}", ba.Balance);