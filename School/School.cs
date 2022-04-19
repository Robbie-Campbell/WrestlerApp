using WrestlerApp.Wrestler;

namespace WrestlerApp.School;

/// <summary>
/// The School Class Which Houses Wrestlers.
/// </summary>
public class School
{
    private readonly int _schoolId;
    private readonly List<Wrestler.Wrestler> _wrestlerRoster;
    
    /// <summary>
    /// Constructor Method for the School Class.
    /// </summary>
    /// <param name="schoolId">The ID of the School.</param>
    /// <param name="rand">An Instance of the Random Class.</param>
    public School(int schoolId, Random rand)
    {
        _schoolId = schoolId;
        _wrestlerRoster = GenerateWrestlerRoster(rand);
    }
    
    /// <summary>
    /// Gets the Schools List of Wrestlers.
    /// </summary>
    /// <returns>The Wrestler List.</returns>
    public List<Wrestler.Wrestler> GetWrestlerList()
    {
        return _wrestlerRoster;
    }
    
    /// <summary>
    /// Gets the Total Number Of Wins for The School.
    /// </summary>
    /// <returns></returns>
    public int GetSchoolTotalWins()
    {
        int total = 0;
        foreach (var wr in _wrestlerRoster)
        {
            total += wr.GetWins();
        }

        return total;
    }
    
    public int GetSchoolTotalLosses()
    {
        int total = 0;
        foreach (var wr in _wrestlerRoster)
        {
            total += wr.GetLosses();
        }

        return total;
    }

    public override string ToString()
    {
        return $"{_schoolId}";
    }

    private List<Wrestler.Wrestler> GenerateWrestlerRoster(Random rand)
    {
        var wrestlerList = new WrestlerFactory(rand.Next(6, 12), _schoolId, rand);
        return wrestlerList.GetWrestlerList();
    }
}