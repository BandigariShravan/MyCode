using Harsha_4_28_01_2023;
string surname = "Mouse".ToUpper();
string name = "Mickey".ToUpper();
char gender = 'M';
string dob = "16/1/1928";

//string surname = "edabit".ToUpper();
//string name = "matt".ToUpper();
//char gender = 'M';
//string dob = "1/1/1900";

//string surname = "Yu".ToUpper();
//string name = "Helen".ToUpper();
//char gender = 'F';
//string dob = "1/12/1950";





char[] vowels = { 'A', 'E', 'I', 'O', 'U' };
char[] consonants = {'B','C','D','F','G','H','J','K','L','M','N','P','Q','R','S','T','V','W','X','Y','Z'};
Date ObjSurname = new Date();
string Code1 = ObjSurname.SurnamePart(surname, vowels, consonants);
string Code2 = ObjSurname.NamePart(name, vowels,consonants);
string Code3 = ObjSurname.DatePart(dob, gender).ToUpper();
Console.WriteLine(Code1+ Code2 + Code3);
