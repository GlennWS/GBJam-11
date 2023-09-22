using UnityEngine;

public class Songlist : MonoBehaviour
{
    public CocktailSonglistSO songlistSO;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AudioClip GetSong(Cocktail songName)
    {
        AudioClip clip = songlistSO.songList.Find(x => x.cocktail == songName).song;
        return clip;
    }
}
