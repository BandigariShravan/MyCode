namespace Harsha_4_28_01_2023
{
    public class Date : Name
    {
        public string[] date;
        public string DatePart(string dob, char gender)
        {
            string[] date = dob.Split('/');
            int day = int.Parse(date[0]);
            int month = int.Parse(date[1]);
            string year = int.Parse(date[2]).ToString().Substring(2);
            string monthCode = "";
            switch (month)
            {
                case 1:
                    monthCode = "A";
                    break;
                case 2:
                    monthCode = "B";
                    break;
                case 3:
                    monthCode = "C";
                    break;
                case 4:
                    monthCode = "D";
                    break;
                case 5:
                    monthCode = "E";
                    break;
                case 6:
                    monthCode = "F";
                    break;
                case 7:
                    monthCode = "G";
                    break;
                case 8:
                    monthCode = "H";
                    break;
                case 9:
                    monthCode = "I";
                    break;
                case 10:
                    monthCode = "J";
                    break;
                case 11:
                    monthCode = "K";
                    break;
                case 12:
                    monthCode = "T";
                    break;
            }
            string datePart = year + monthCode;
            if (gender == 'M')
            {
                if (day < 10)
                {
                    datePart =datePart+ "0" + day.ToString();
                }
                else
                {
                    datePart =datePart+ day.ToString();
                }
            }
            else
            {
                datePart =datePart+ (day + 40).ToString();
            }
            return datePart;
        }
    }
}

