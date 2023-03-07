namespace Harsha_6_04_02_2023
{
    public class CFugeFunction
    {
        public bool CFugeBalance(int n, int k)
        {
            //for (int i = k; i * i <= n; i++)
            //{
            //    if (n % i == 0)
            //    {
            //        return true;
            //    }
            //}
            //return false;
            //if (n > k)
            //{
            //    return true;
            //}
            //else if (k > n)
            //{
            //    return false;
            //}
            //else// if (k == n)
            //{
            //    return true;
            //}
            //int i = 1;
            //while (i * i <= n)
            //{
            //    if(n%i==0 && i >= k)
            //    {
            //        return true;
            //    }
            //    i++;
            //}
            //return false;
            if (n % 2 == 0 && k % 2 == 0)
            {
                return true;
            }
            if (n % 2 == 1 && k % 2 == 1 && n == k)
            {
                return true;
            }
            return false;
        }
    }
}
