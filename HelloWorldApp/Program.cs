// using namespace to use a namespace
using System;

namespace HelloWorld

{
    // class declaration
    public class Person
{
    private DateTime _birthdate;

    public DateTime GetBirthdate()
    {
        return this._birthdate;
    }

    public void SetBirthDate(DateTime newBirthDate)
    { 
        if (newBirthDate > DateTime.Now)
        {
            throw new ArgumentException("Birthdate cannot be in the future.");
        }
        this._birthdate = newBirthDate;
    }


}
    

    class Program
    {
        // Main method - entry point of the program
        static void Main(string[] args)
        {
            // // Print "Hello, World!" to the console
            // Console.WriteLine("Hello, World!");

            // // decalring variables
            // byte num6 = 23;
            // short num4 = 1234;
            // int number = 42;
            // float fnum = 3.14f;
            // double dnum = 2.312;
            // char letter = 'A';
            // string txt = "This is a string";
            // bool check = false;
            // System.Console.WriteLine("Number: " + number);
            // System.Console.WriteLine("{0},{1}", byte.MinValue, byte.MaxValue);

            // string num = "1234";
            // // int num2=(int) num;
            // // this will give an error
            // // Here we use Convert 
            // int num9 = Convert.ToInt32(num);
            // System.Console.WriteLine("Converted number: " + num9);

            Person John = new Person();
            // System.Console.WriteLine(John._birthdate);
            System.Console.WriteLine(John.GetBirthdate());
            John.SetBirthDate(new DateTime(2002, 12, 29));
            System.Console.WriteLine(John.GetBirthdate());
          



        }
    }
}