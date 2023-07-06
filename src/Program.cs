using RPPTennisScorer;
using System.Text;


string source = args[0];
string destination = args[1];

StringBuilder output = new();

using (StreamReader sr = File.OpenText(source))
{
    string? nextScoreTxt;
    while ((nextScoreTxt = sr.ReadLine()) != null)
    {
        Match match = new();
        match.ScoreMatch(nextScoreTxt);
        output.AppendLine(match.ToString());
    }
}

File.WriteAllText(destination, output.ToString());