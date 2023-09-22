using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Cocktail2Song
{
    public Cocktail cocktail;
    public AudioClip song;
}

[CreateAssetMenu(fileName = "songlist", menuName = "ScriptableObject/Songlist")]
public class CocktailSonglistSO : ScriptableObject
{
    public List<Cocktail2Song> songList;
}
