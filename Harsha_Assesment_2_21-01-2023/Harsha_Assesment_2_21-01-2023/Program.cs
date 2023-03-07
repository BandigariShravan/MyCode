int flightTime = 120;
string[] movieData = File.ReadAllLines("C:\\Users\\bandi\\source\\repos\\Movies.txt");
List<string> titles = new List<string>();
List<int> Durations = new List<int>();
foreach (string line in movieData)
{
    string[] parts = line.Split(',');
    titles.Add(parts[0]);
    Durations.Add(int.Parse(parts[1]));
}
int[] movies = Durations.ToArray();
int max = 1;
for (int i = 0; i < movies.Length; i++)
{
    max =max * 2;
}
List<string> suggestedMovies = new List<string>();
for (int i = 1; i < max; i++)
{
    int timeLeft = flightTime;
    string movieSuggest = "";
    for (int j = 0; j < movies.Length; j++)
    {
        if ((i >> j) % 2 == 1)
        {
            timeLeft = timeLeft - movies[j];
            movieSuggest = movieSuggest + titles[j] + " ";
        }
    }
    if (timeLeft == 0)
    {
        suggestedMovies.Add(movieSuggest);
    }
}

foreach (string movie in suggestedMovies)
{
    Console.WriteLine(movie);
}