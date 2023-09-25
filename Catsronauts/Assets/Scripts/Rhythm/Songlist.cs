using System.Collections.Generic;
using UnityEngine;

public class Songlist : MonoBehaviour
{
    public CocktailSonglistSO songlistSO;

    static Dictionary<string, int> songTempos = new Dictionary<string, int>()
    {
        {"PinyaCatlata", 150 },
        {"Meowgarita", 259 },
        {"CosmosMeowlatin", 176 },
        {"Meowtini", 150 },
        {"PurrrumandCoke", 130 },
        {"Yeowlgabombs", 0 },
        {"WiskeryandCoke", 0 },
        {"Lemeownade", 0 }
    };

    static Dictionary<string, int> songBeats = new Dictionary<string, int>()
    {
        {"PinyaCatlata", Mathf.RoundToInt((150f / 60f) * 41.6f) },
        {"Meowgarita", Mathf.RoundToInt((259f / 60f) * 12.973f) },
        {"CosmosMeowlatin", Mathf.RoundToInt((176f / 60f) * 24.545f) },
        {"Meowtini", Mathf.RoundToInt((150f / 60f) * 51.2f) },
        {"PurrrumandCoke", Mathf.RoundToInt((130f / 60f) * 36.923f) - 7 },
        {"Yeowlgabombs", 0 },
        {"WiskeryandCoke", 0 },
        {"Lemeownade", 0 }
    };

    public AudioClip GetSong(Cocktail songName)
    {
        AudioClip clip = songlistSO.songList.Find(x => x.cocktail == songName).song;
        return clip;
    }

    public static int GetSongTempo(string songName)
    {
        int songTempo = songTempos[songName];
        return songTempo;
    }

    public static int GetSongBeats(string songName)
    {
        int songTotalBeats = songBeats[songName];
        return songTotalBeats;
    }
}
