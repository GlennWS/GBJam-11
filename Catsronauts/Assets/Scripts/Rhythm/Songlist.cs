using System.Collections.Generic;
using UnityEngine;

public class Songlist : MonoBehaviour
{
    public CocktailSonglistSO songlistSO;

    static Dictionary<string, int> songTempos = new Dictionary<string, int>()
    {
        {"PinyaCatlata", 0 },
        {"Meowgarita", 0 },
        {"CosmosMeowlatin", 0 },
        {"Meowtini", 150 },
        {"PurrrumandCoke", 130 },
        {"Yeowlgabombs", 0 },
        {"WiskeryandCoke", 0 },
        {"Lemeownade", 0 }
    };

    static Dictionary<string, float> songBeats = new Dictionary<string, float>()
    {
        {"PinyaCatlata", 0 },
        {"Meowgarita", 0 },
        {"CosmosMeowlatin", 0 },
        {"Meowtini", (150 / 60) * 50 },
        {"PurrrumandCoke", (130 / 60) * 59 },
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

    public static float GetSongBeats(string songName)
    {
        float songTotalBeats = songBeats[songName];
        return songTotalBeats;
    }
}
