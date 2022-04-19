namespace WrestlerApp.Tournament;

public class Tournament
{
    private readonly List<School.School> _schools;
    private Dictionary<int, List<Wrestler.Wrestler>> _participants;
    private Dictionary<int, List<Wrestler.Wrestler>> _seeds;
    
    public Tournament(List<School.School> schools)
    {
        _schools = schools;
        _participants = GetAllWrestlersAndOrderByWeightClass();
        _seeds = GenerateSeeds();
    }

    private Dictionary<int, List<Wrestler.Wrestler>> GetAllWrestlersAndOrderByWeightClass()
    {
        Dictionary<int, List<Wrestler.Wrestler>> tournamentListings = new Dictionary<int, List<Wrestler.Wrestler>>();
        foreach (var school in _schools)
        {
            foreach (Wrestler.Wrestler wrestler in school.GetWrestlerList())
            {
                if (tournamentListings.ContainsKey(wrestler.GetWeightClass()))
                    tournamentListings[wrestler.GetWeightClass()].Add(wrestler);
                else
                    tournamentListings.Add(wrestler.GetWeightClass(), new List<Wrestler.Wrestler>{wrestler});
            }
        }
        
        return tournamentListings;
    }

    private void OrderByWinRateThenAbility()
    {
        foreach (var weightClass in _participants)
        {
            _participants[weightClass.Key] = _participants[weightClass.Key]
                .OrderBy(wrestler => wrestler.CalculateWinRateAsPercentage())
                .ThenBy(wrestler => wrestler.GetAbility()).ToList();
        }
    }

    private Dictionary<int, List<Wrestler.Wrestler>> GenerateSeeds()
    {
        int matchId = 1;
        Dictionary<int, List<Wrestler.Wrestler>> seeds = new Dictionary<int, List<Wrestler.Wrestler>>();
        foreach (var weightClass in _participants)
        {
            for (int i = 0; i < _participants[weightClass.Key].Count; i++)
            {
                var wrestler = _participants[weightClass.Key].Last();
                _participants[weightClass.Key].Remove(wrestler);
                if (seeds.ContainsKey(matchId))
                    seeds[matchId].Add(wrestler);
                else
                    seeds.Add(matchId, new List<Wrestler.Wrestler>{wrestler});
                if (i % 2 == 0)
                    matchId++;
            }
        }

        return seeds;
    }

    public void CheckTourneyList()
    {
        OrderByWinRateThenAbility();
        foreach (var x in _seeds)
        {
            Console.WriteLine("\n\n");
            foreach (var w in _seeds[x.Key])
            {
                Console.WriteLine(x.Key + " " + w.ToString());
            }
        }
    }
}