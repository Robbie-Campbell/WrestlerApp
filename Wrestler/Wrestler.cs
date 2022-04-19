namespace WrestlerApp.Wrestler;

/// <summary>
/// A class which represents a single wrestler.
/// </summary>
public class Wrestler
{
    private readonly int _weight, _id, _ability;
    private int _wins, _losses, _weightClass;
    
    /// <summary>
    /// Constructor Method for the Wrestler Class.
    /// </summary>
    /// <param name="id">ID of the Wrestler, also used to identify School.</param>
    /// <param name="weight">The Weight of the Wrestler.</param>
    /// <param name="ability">How Skilled the Wrestler is.</param>
    public Wrestler(int id, int weight, int weightClass, int ability)
    {
        _id = id;
        _weight = weight;
        _ability = ability;
        _wins = 0;
        _losses = 0;
        _weightClass = weightClass;
    }
    
    /// <summary>
    /// Gets the Wieght Class of a Wrestler.
    /// </summary>
    /// <returns>The Wrestlers Weight Class.</returns>
    public int GetWeightClass()
    {
        return _weightClass;
    }

    /// <summary>
    /// Gets the Ability Level of the Wrestler.
    /// </summary>
    /// <returns>The Wrestlers Ability.</returns>
    public int GetAbility()
    {
        return _ability;
    }

    /// <summary>
    /// Adds a Loss to the Wrestlers Record.
    /// </summary>
    public void AddLoss()
    {
        _losses += 1;
    }
    
    /// <summary>
    /// Get the Number of Wrestler Losses.
    /// </summary>
    /// <returns>The Number of Losses.</returns>
    public int GetLosses()
    {
        return _losses;
    }
    
    /// <summary>
    /// Adds a Win to the Wrestlers Record.
    /// </summary>
    public void AddWin()
    {
        _wins += 1;
    }
    
    /// <summary>
    /// Get the Number of Wrestler Wins.
    /// </summary>
    /// <returns></returns>
    public int GetWins()
    {
        return _wins;
    }
    
    /// <summary>
    /// Gets the Percentage Wins and Losses of The Wrestler.
    /// </summary>
    /// <returns>The Percentage Wins and Losses.</returns>
    public double CalculateWinRateAsPercentage()
    {
        if (_losses != 0)
            return _wins / _losses * 100;
        if (_wins == 0)
            return 0;
        return 100;
    }
    
    /// <summary>
    /// Returns a String Value of the Wrestler Stats.
    /// </summary>
    /// <returns>All of the Objects Attributes in String Format.</returns>
    public override string ToString()
    {
        return $"id: {_id}, weight: {_weight}, ability: {_ability}, wins: {_wins}, losses: {_losses}, " +
               $"win rate: {CalculateWinRateAsPercentage()}";
    }
}