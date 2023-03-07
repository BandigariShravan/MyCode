namespace Harsha_4_28_01_2023
{
    public class Surname
    {
        public string? FiscalCode1 = "";
        public string? FiscalCode2 = "";
        public  string SurnamePart(string surname, char[] vowels, char[] consonants)
        {
            for (int i = 0; i < surname.Length; i++)
            {
                for (int j = 0; j < consonants.Length; j++)
                {
                    if (surname[i] == consonants[j])
                    {
                        FiscalCode1 = FiscalCode1 + consonants[j];
                    }
                }
            }
            if (FiscalCode1.Length < 3)
            {
                for (int i = 0; i < surname.Length; i++)
                {
                    for (int j = 0; j < vowels.Length; j++)
                    {
                        if (surname[i] == vowels[j])
                        {
                            if (FiscalCode2.Length == 0)
                            {
                                FiscalCode2 = FiscalCode2 + vowels[j];
                            }
                            break;
                        }
                    }
                }
                if (FiscalCode1.Length < 2)
                {
                    FiscalCode2 = (FiscalCode2 + "XXX").Substring(0,3);
                }
            }
            return FiscalCode1+FiscalCode2;
        }
    }
}
