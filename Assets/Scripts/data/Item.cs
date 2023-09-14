﻿using System;
public static class Item
{
    public static bool CanBeStolen(ItemID item) => ItemTable[(int)item].type is ItemType.FieldItem or ItemType.BattleItem or ItemType.Medicine;

    public static FieldItem None = new()
    {
        itemName = "Error 901",
        price = 100,
    };

    public static FieldItem FireStone = new()
    {
        itemName = "Fire Stone",
        price = 10000,
        fieldEffect = FieldEffect.Evolution
    };

    public static FieldItem WaterStone = new()
    {
        itemName = "Water Stone",
        price = 10000,
        fieldEffect = FieldEffect.Evolution
    };

    public static FieldItem ThunderStone = new()
    {
        itemName = "Thunder Stone",
        price = 10000,
        fieldEffect = FieldEffect.Evolution
    };

    public static FieldItem LeafStone = new()
    {
        itemName = "Leaf Stone",
        price = 10000,
        fieldEffect = FieldEffect.Evolution
    };

    public static FieldItem MoonStone = new()
    {
        itemName = "Moon Stone",
        price = 10000,
        fieldEffect = FieldEffect.Evolution
    };

    public static FieldItem SunStone = new()
    {
        itemName = "Sun Stone",
        price = 10000,
        fieldEffect = FieldEffect.Evolution
    };

    public static FieldItem ShinyStone = new()
    {
        itemName = "Shiny Stone",
        price = 10000,
        fieldEffect = FieldEffect.Evolution
    };

    public static FieldItem DuskStone = new()
    {
        itemName = "Dusk Stone",
        price = 10000,
        fieldEffect = FieldEffect.Evolution
    };

    public static FieldItem DawnStone = new()
    {
        itemName = "Dawn Stone",
        price = 10000,
        fieldEffect = FieldEffect.Evolution
    };

    public static FieldItem IceStone = new()
    {
        itemName = "Ice Stone",
        price = 10000,
        fieldEffect = FieldEffect.Evolution
    };

    //Held items

    public static HeldItem KingsRock = new()
    {
        itemName = "King's Rock",
        price = 15000,
        heldEffect = HeldEffect.KingsRock,
    };

    public static HeldItem MetalCoat = new()
    {
        itemName = "Metal Coat",
        price = 15000,
        heldEffect = HeldEffect.MetalCoat,
    };

    //Abstract items - only used for evolutions/specific item checks

    public static AbstractItem DragonScale = new()
    {
        itemName = "Dragon Scale",
        price = 10000,
    };

    public static AbstractItem UpGrade = new()
    {
        itemName = "Up-Grade",
        price = 10000,
    };

    //Mega stones

    public static MegaStone Venusaurite = new()
    {
        itemName = "Venusaurite",
        price = 40000,
        originalSpecies = SpeciesID.Venusaur,
        destinationSpecies = SpeciesID.VenusaurMega,  //Replace when megas are implemented
    };

    public static MegaStone CharizarditeX = new()
    {
        itemName = "Venusaurite",
        price = 40000,
        originalSpecies = SpeciesID.Charizard,
        destinationSpecies = SpeciesID.CharizardMegaX,  //Replace when megas are implemented
    };

    public static MegaStone CharizarditeY = new()
    {
        itemName = "Venusaurite",
        price = 40000,
        originalSpecies = SpeciesID.Charizard,
        destinationSpecies = SpeciesID.CharizardMegaY,  //Replace when megas are implemented
    };

    public static MegaStone Blastoisinite = new()
    {
        itemName = "Venusaurite",
        price = 40000,
        originalSpecies = SpeciesID.Blastoise,
        destinationSpecies = SpeciesID.BlastoiseMega,  //Replace when megas are implemented
    };

    public static ItemData[] ItemTable = new ItemData[(int)ItemID.Count]
    {
    None,
    //Evolution items
    FireStone,
    WaterStone,
    ThunderStone,
    LeafStone,
    MoonStone,
    SunStone,
    ShinyStone,
    DuskStone,
    DawnStone,
    IceStone,
    //Held items
    KingsRock,
    MetalCoat,
    //Abstract items
    DragonScale,
    UpGrade,
    //Mega stones
    Venusaurite,
    CharizarditeX,
    CharizarditeY,
    Blastoisinite,
    };
}

