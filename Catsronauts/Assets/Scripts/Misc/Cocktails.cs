using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Cocktail
{
    PinyaCatlata = 0,
    Meowgarita = 1,
    CosmosMeowlatin = 2,
    Meowtini = 3,
    PurrrumandCoke = 4,
    Yeowlgabombs = 5,
    WiskeryandCoke = 6,
    Lemeownade = 7
}

public static class Cocktails
{
    public static Dictionary<Cocktail, string> cocktailNames = new Dictionary<Cocktail, string> 
    {
        { Cocktail.PinyaCatlata, "Pinya Catlata" },
        { Cocktail.Meowgarita, "Meowgarita" },
        { Cocktail.CosmosMeowlatin, "Cosmos Meowlatin" },
        { Cocktail.Meowtini, "Meowtini" },
        { Cocktail.PurrrumandCoke, "Purrrum and Coke" },
        { Cocktail.Yeowlgabombs, "Yeowlgabombs" },
        { Cocktail.WiskeryandCoke, "Wiskery and Coke" },
        { Cocktail.Lemeownade, "Lemeownade" }
    };

    public static Cocktail GetRandomCocktail()
    {
        int random = UnityEngine.Random.Range(0, cocktailNames.Count);
        return (Cocktail) random;
    }
}
