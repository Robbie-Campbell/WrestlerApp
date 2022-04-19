namespace WrestlerApp.Match;

public static class Match
{
    public static Wrestler.Wrestler CalculateResult(Wrestler.Wrestler wrestler1, Wrestler.Wrestler wrestler2)
    {
        var sigma = GetMatchSigma(wrestler1, wrestler2);
        var player1Score = wrestler1.GetAbility() / sigma;
        var player2Score = wrestler2.GetAbility() / sigma;
        AddWrestlerResult(wrestler1, player1Score > player2Score);
        AddWrestlerResult(wrestler2, player2Score > player1Score);
        return player1Score > player2Score ? wrestler1 : wrestler2;
    }

    private static double GetMatchSigma(Wrestler.Wrestler wrestler1, Wrestler.Wrestler wrestler2)
    {
        double diff = Math.Abs(wrestler1.GetAbility() - wrestler2.GetAbility());
        return diff < 15 ? 15 : diff;
    }

    private static void AddWrestlerResult(Wrestler.Wrestler wrestler, bool isWinner)
    {
        if (isWinner)
            wrestler.AddWin();
        else
            wrestler.AddLoss();
    }
}