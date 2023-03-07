// See https://aka.ms/new-console-template for more information
using Harsha_3_28_01_2023;
string timeStamp = "08:30:45";
Console.Write("OldTime:"+timeStamp);
Console.WriteLine("\n Enter the time values wannna change in time");
Console.WriteLine("\nEnter Hours");
int hours = int.Parse("\n"+Console.ReadLine());
Console.WriteLine("\nEnter Minutes");
int minutes = int.Parse(Console.ReadLine());
Console.WriteLine("\nEnter Seconds");
int seconds = int.Parse(Console.ReadLine());
string ajustedTime = NewAjustTime.NewTime(timeStamp.ToString(), hours, minutes, seconds);
string[] parts = ajustedTime.Split(',');
String hrs = parts[0];
String mins = parts[1];
String secs = parts[2];
Console.WriteLine("NewTime :{0}hrs.{1}min and {2}sec",hrs,mins,secs);

