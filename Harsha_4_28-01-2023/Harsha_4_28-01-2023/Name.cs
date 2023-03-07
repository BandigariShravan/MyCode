using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harsha_4_28_01_2023
{
    public class Name:Surname
    {   
        public string? FacialCode3="";
        public string NamePart(string name, char[] vowels, char[] consonants)
        {
            int count = 0;
            for (int i = 0; i < name.Length; i++)
            {
                for (int j = 0; j < consonants.Length; j++)
                {
                    if (name[i] == consonants[j])
                    {
                        count++;
                        FacialCode3 = FacialCode3 + consonants[j];
                        break;
                    }
                }
            }
            if (FacialCode3.Length == 3)
            {
                return FacialCode3;
            }
            else if(FacialCode3.Length >3) 
            {
                return FacialCode3.Remove(1,1).Substring(0,3);
            }
            else
            {
                int valu = 3 - FacialCode3.Length;
                int vowelCount = 0;
                for(int i=0;i<name.Length && vowelCount < valu ; i++)
                {
                    for (int j = 0;j< vowels.Length; j++)
                    {
                        if (name[i] == vowels[j])
                        {
                            FacialCode3 = FacialCode3+ vowels[j];
                            vowelCount++;
                            break;
                        }
                    }
                    if(FacialCode3.Length==3 || vowelCount==3)
                    {
                        break;
                    }
                }
                if (FacialCode3.Length < 3)
                {
                    FacialCode3 = (FacialCode3 + "XXX").Substring(0,3);
                }
            }
            return FacialCode3;
        }
    }
}
