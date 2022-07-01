


public enum States
{
        Girl,
        SwordMan,
        Archer,
        Wizard    
}

public static class PlayerStates
{
    public static string Name(this States states)
    {
        string[] names = { "­—", "Œ•m", "‹|g‚¢", "–‚–@g‚¢" };
        return names[(int)states];

    }



    
}

