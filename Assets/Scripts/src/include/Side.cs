public class Side
{
    public bool lightScreen = false;
    public int lightScreenTurns = 0;
    public bool reflect = false;
    public int reflectTurns = 0;
    public bool auroraVeil = false;
    public int auroraVeilTurns = 0;
    public bool mist = false;
    public int mistTurns = 0;
    public int spikes = 0;
    public bool safeguard = false;
    public int safeguardTurns = 0;
    public bool tailwind = false;
    public int tailwindTurns = 0;

    public readonly Battle battle;
    public readonly bool whichSide;

    public Side(bool side, Battle battle)
    {
        whichSide = side;
        this.battle = battle;
    }

}