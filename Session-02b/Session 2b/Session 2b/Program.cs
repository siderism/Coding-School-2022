// See https://aka.ms/new-console-template for more information

//1
Console.WriteLine("Hello Michael");

//2
int num1 = 5;
int num2 = 21;
int sum = num1 + num2;
float div = (float)num1 / num2;
Console.WriteLine("The sum of 2 numbers is " + sum);
Console.WriteLine("The division of those 2 numbers is " + div);

//3a
int result1 = -1 + 5 * 6;
Console.WriteLine(result1);

//3b
int result2 = 38 + 5 % 7;
Console.WriteLine(result2);

//3c
double result3 = 14 + (-3 * 6 / (double)7);
Console.WriteLine(result3);

//3d
double result4 = (double)(2 + (13 / (double)6 * 6) + Math.Sqrt(7));
Console.WriteLine(result4);

//3e
double result5 = (Math.Pow(6, 4) + Math.Pow(5, 7)) / (9 % 4);
Console.WriteLine(result5);

//4
int age = 20;
string gender = "female";
Console.WriteLine("You are " + gender + " and look younger than " + age + ".");

//5
int seconds = 456778;
float minutes = (float)seconds / 60;
float hours = minutes / 60;
float days = hours / 24;
float years = days / 365;
Console.WriteLine(seconds + " seconds are equal with " + minutes + " minutes, equal with " + hours + " hours, equal with " + days + " days and equal with " + years + " years.");

//6
TimeSpan t = TimeSpan.FromSeconds(seconds);
double dMinutes = t.TotalMinutes;
double dHours = t.TotalHours;
double dDays = t.TotalDays;
double dYears = t.TotalDays / 365;
Console.WriteLine(seconds + " seconds are equal with " + dMinutes + " minutes, equal with " + dHours + " hours, equal with " + dDays + " days and equal with " + dYears + " years.");

//7
float celcius = 36.6f;
float fahrenheit = (celcius * 9) / 5 + 32;
float kelvin = celcius + 273;
Console.WriteLine(celcius + " Celcius degrees are " + fahrenheit + " Fahrenheit degrees and " + kelvin + " Kelvin degrees.");