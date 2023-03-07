namespace Harsha_5_30_01_2023
{
    public class CalculateNextMealTime
    {
        public static int[] calculate(out string meal)
        {
            string time = DateTime.Now.ToShortTimeString();
            string[] timeparts = time.Split(':');
            int hour = int.Parse(timeparts[0]);
            int minute = int.Parse(timeparts[1]);
            int[] result = new int[2];
            if (hour < 7)
            {
                result[0] = 7 - hour-1;
                if (minute == 0)
                {
                    result[1] = 0;
                }
                else
                {
                    result[1] = (60 - minute);
                }
                meal = "BreakFast";
            }
            //if (hour < 7)?(result[0]=7-hour-1 if(minute==0) ? result[1] = 0 : result[1]=(60-minute))
            else if (hour < 12)
            {
                result[0] = 12 - hour-1;
                if (minute == 0)
                {
                    result[1] = 0;
                }
                else
                {
                    result[1] = (60 - minute);
                }
                meal = "Lunch";
            }
            else if (hour < 19)
            {
                result[0] = 19 - hour - 1;
                if (minute == 0)
                {
                    result[1] = 0;
                }
                else
                {
                    result[1] = (60 - minute);
                }
                meal = "Dinner"; 
            }
            else
            {
                result[0] = 24 - hour + 7-1;
                if (minute == 0)
                {
                    result[1] = 0;
                }
                else
                {
                    result[1] = (60 - minute);
                }
                meal = "Breakfast";
            }
            return result;
        }
    }
}