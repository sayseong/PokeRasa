﻿public static class Team
{
    public static TeamData mayTestTeam = new()
    {
        trainerName = "Pokémon Trainer May",
        Party = new TeamPokemon[]
        {
            new()
            {
                species = SpeciesID.Squirtle,
                gender = Gender.Any,
                nature = Nature.Any,
                evIv = Spread.random,
                level = 1
            }
        }
    };
}