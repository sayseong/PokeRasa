using static MoveEffect;
public enum MoveEffect : ushort
{
    //No added effect
    None,
    Hit,
    //Multi-hit moves
    MultiHit2,
    MultiHit2to5,
    Twineedle,
    TripleHit,
    //Status-inducing moves
    Burn,
    Paralyze,
    Poison,
    Toxic,
    Freeze,
    Sleep,
    Confuse,
    TriAttack,
    Swagger,
    Flatter,
    //Stat changes
    AttackUp1,
    AttackUp2,
    DefenseUp1,
    DefenseUp2,
    SpAtkUp1,
    SpAtkUp2,
    SpAtkUp3,
    SpDefUp2,
    SpeedUp1,
    SpeedUp2,
    EvasionUp1,
    EvasionUp2,
    CritRateUp2,
    AttackDown1,
    AttackDown2,
    DefenseDown1,
    DefenseDown2,
    SpAtkDown1,
    SpAtkDown2,
    SpDefDown1,
    SpDefDown2,
    SpeedDown1,
    SpeedDown2,
    AccuracyDown1,
    EvasionDown2,
    AttackDefenseUp1,
    AttackSpeedUp1,
    AttackAccuracyUp1,
    DefenseSpDefUp1,
    SpAtkSpDefUp1,
    AttackDefenseDown1,
    DefenseSpDefDown1,
    AttackUp1SpeedUp2,
    AttackDefAccUp1,
    SpAtkSpDefSpeedUp1,
    AllUp1,
    Acupressure,
    Autotomize,
    BellyDrum,
    Captivate,
    Charge,
    DefenseCurl,
    Growth,
    Minimize,
    ShellSmash,
    //Other status moves
    AfterYou,
    Attract,
    Bestow,
    Curse,
    Defog,
    Disable,
    Embargo,
    Encore,
    Entrainment,
    ForcedSwitch,
    Foresight,
    GuardSplit,
    GuardSwap,
    HealBlock,
    HealPulse,
    HeartSwap,
    Imprison,
    LeechSeed,
    MeFirst,
    Memento,
    MindReader,
    MiracleEye,
    Nightmare,
    PerishSong,
    PowerSplit,
    PowerSwap,
    PsychoShift,
    PsychUp,
    Quash,
    ReflectType,
    RolePlay,
    SimpleBeam,
    SkillSwap,
    Snatch,
    Soak,
    Spite,
    SuppressAbility,
    Taunt,
    Telekinesis,
    Torment,
    Trap,
    Trick,
    WorrySeed,
    Yawn,
    //Direct damage
    Direct20,
    Direct40,
    DirectLevel,
    Psywave,
    SuperFang,
    //Recoil
    Recoil33,
    Recoil25,
    Recoil25Max,
    Crash50Max,
    VoltTackle,
    FlareBlitz,
    //Other added effects
    Absorb50,
    BreakScreens,
    ClearStats,
    FakeOut,
    Feint,
    FlameBurst,
    Flinch,
    KnockOff,
    PayDay,
    RapidSpin,
    SecretPower,
    SmackDown,
    SmellingSalts,
    Thief,
    WakeUpSlap,
    //Unique attack types
    AlwaysCrit,
    Assurance,
    BeatUp,
    ChargingAttack,
    ContinuousDamage,
    Counter,
    DreamEater,
    EchoedVoice,
    Endeavor,
    FalseSwipe,
    FinalGambit,
    Fling,
    FuryCutter,
    FutureSight,
    HiddenPower,
    Incinerate,
    IgnoreDefenseStage,
    Judgement,
    LastResort,
    MetalBurst,
    NaturalGift,
    NaturePower,
    OHKO,
    PainSplit,
    Pluck,
    Psyshock,
    Rage,
    Recharge,
    Rollout,
    Round,
    SelfDestruct,
    Snore,
    SuckerPunch,
    SwitchHit,
    Synchronoise,
    Thrash,
    Uproar,
    //Moves which double in power under certain conditions
    Acrobatics,
    Brine,
    Facade,
    Hex,
    Payback,
    Pursuit,
    Retaliate,
    Revenge,
    Venoshock,
    WeatherBall,
    //Moves with unique power calcs
    WeightPower,
    RelativeWeightPower,
    HealthPower,
    Reversal,
    TargetHealthPower,
    LowSpeedPower,
    HighSpeedPower,
    UserStatPower,
    TargetStatPower,
    Return,
    Frustration,
    Magnitude,
    Present,
    TrumpCard,
    FoulPlay,
    //Paired effects
    Bide,
    BideHit,
    Stockpile,
    Swallow,
    SpitUp,
    FocusPunchWindup,
    FocusPunchAttack,
    SkyDrop,
    SkyDropHit,
    Pledge,
    Rainbow,
    Swamp,
    BurningField,
    //Field effects
    Gravity,
    Haze,
    LightScreen,
    LuckyChant,
    MagicRoom,
    Mist,
    MudSport,
    Reflect,
    Safeguard,
    StealthRock,
    Spikes,
    Tailwind,
    ToxicSpikes,
    TrickRoom,
    WaterSport,
    Weather,
    WonderRoom,
    //Self-targeting effects
    AquaRing,
    Assist,
    BatonPass,
    Camouflage,
    Conversion,
    Conversion2,
    Copycat,
    DestinyBond,
    Endure,
    Grudge,
    Heal50,
    HealBell,
    HealingWish,
    HealStatus,
    HealWeather,
    Ingrain,
    MagicCoat,
    MagnetRise,
    Metronome,
    Mimic,
    MirrorMove,
    PowerTrick,
    Protect,
    QuickGuard,
    Recycle,
    Rest,
    Roost,
    SleepTalk,
    Substitute,
    Teleport,
    Transform,
    Sketch,
    WideGuard,
    Wish,
    //Effects for doubles/triples
    AllySwitch,
    FollowMe,
    HelpingHand,
    RagePowder,
}

public static class MoveEffectUtils
{

    public static bool IsStatDrop(this MoveEffect effect)
        => effect is AttackDown1 or AttackDown2 or DefenseDown1
        or DefenseDown2 or SpAtkDown1 or SpAtkDown2 or SpDefDown1
        or SpDefDown2 or SpeedDown1 or SpeedDown2 or AttackDefenseDown1
        or DefenseSpDefDown1 or Captivate;

    public static bool IsStatusMove(this MoveEffect effect)
        => effect is Paralyze or Freeze or Burn or Sleep or Poison or Toxic
        or TriAttack;

    public static bool IsShieldDustAffected(this MoveEffect effect)
    {
        return effect.IsStatusMove() || effect.IsStatDrop()
            || effect is Flinch;
    }
    public static bool HasRecoil(this MoveEffect effect)
        => effect is Recoil25 or Recoil33 or Crash50Max;
}