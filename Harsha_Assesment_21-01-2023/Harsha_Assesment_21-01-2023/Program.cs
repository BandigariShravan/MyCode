string word = "Ariqt International";
int[] count = new int[256];
foreach (char c in word)
{
    count[c]++;
}
char unique = ' ';
foreach (char c in word)
{
    if (count[c] == 1)
    {
        unique = c;
        break;
    }
}
if (unique ==' ')
{
    Console.WriteLine("Not Found....");

}
else
{
    int i = word.IndexOf(unique);
    Console.WriteLine("First accourance is " + unique + " and Index: " + i);
}