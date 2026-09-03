using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace HelloWorld
{
    public static class StringExtensions
    {
        public static bool IsValidEmail(this string value)
        {
            return value.Contains("@");
        }
    }
    class Program
    {
        public static void Main(string[] str)
        {
            string email = "test@gmail.com";

            bool result = email.IsValidEmail();

            Console.WriteLine(result);
        }

    }

}

/*
An extension method allows us to add a new method to an existing class/type without modifying the original class or inheriting from it.


Rules for Extension Methods

An extension method:

Must be inside a static class
Must be a static method
The first parameter must have the this keyword
The first parameter specifies the type being extended

Real-world ASP.NET Core example

You frequently use extension methods in ASP.NET Core:

builder.Services.AddControllers();

app.UseAuthentication();

app.UseAuthorization();

Methods such as these are commonly implemented as extension methods to keep configuration APIs clean.

*/

