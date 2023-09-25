using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RhythmController : MonoBehaviour
{
    public BeatScroller beatScroller;
    public SpriteRenderer rhythmBarSR;
    public SpriteRenderer noteHitSR;
    public float totalScore = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI multiplierText;
    public GameObject blackoutSquare;

    public int currentMultiplier;
    public int multiplierCounter;
    public int[] multiplierThresholds;
    private AudioSource audioSource;
    private AudioSource titleScreenAudio;
    public AudioClip endMusic;
    private float titleScreenAudioVolume;

    private int currentSeatNum;
    private bool gameFinished;
    private bool loadEndSequence;

    void OnEnable()
    {
        currentMultiplier = 1;
        audioSource = gameObject.GetComponent<AudioSource>();
        currentSeatNum = GameObject.Find("Player").GetComponent<PlayerController>()._currSeatIndex;
        titleScreenAudio = GameObject.Find("TitleScreenMaster").GetComponent<AudioSource>();
        titleScreenAudioVolume = GameObject.Find("TitleScreenMaster").GetComponent<AudioSource>().volume;
        PlayerController.onServeCocktail += StartRhythmGame;
    }

    void OnDisable()
    {
        PlayerController.onServeCocktail -= StartRhythmGame;
    }

    void Update()
    {
        if (gameFinished == true)
        {
            Vector3 currentPos = blackoutSquare.GetComponent<Transform>().transform.position;
            blackoutSquare.GetComponent<Transform>().transform.position = Vector3.MoveTowards(currentPos, new Vector3(0.0f, 0.0f, 0.0f), 5.0f * Time.deltaTime);
            if (currentPos == new Vector3(0.0f, 0.0f, 0.0f))
            {
                loadEndSequence = true;
            }
        }

        if (loadEndSequence == true)
        {
            StartCoroutine(FadeOutMusic(titleScreenAudio, 3.0f));
            DontDestroyOnLoad(blackoutSquare);
            SceneManager.LoadScene("EndScreen");
        }
    }

    void StartRhythmGame(Cocktail cocktail)
    {
        // Set the rhythm game as started
        beatScroller.hasStarted = true;
        beatScroller.currentOrder = cocktail;
        beatScroller.beatTempo = Songlist.GetSongTempo(cocktail.ToString()) / 60f;
        // Show the sprites of the rhythm bar and hit outline
        rhythmBarSR.enabled = true;
        noteHitSR.enabled = true;
        // Get the correct song,
        Songlist sl = GetComponent<Songlist>();
        AudioClip clip = sl.GetSong(cocktail);
        currentSeatNum = GameObject.Find("Player").GetComponent<PlayerController>()._currSeatIndex;
        // TO DO: condense this into a list by .transform
        switch(cocktail.ToString())
        {
            case "PinyaCatlata":
                beatScroller.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                break;
            case "Meowgarita":
                beatScroller.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                break;
            case "CosmosMeowlatin":
                beatScroller.gameObject.transform.GetChild(2).gameObject.SetActive(true);
                break;
            case "Meowtini":
                beatScroller.gameObject.transform.GetChild(3).gameObject.SetActive(true);
                break;
            case "PurrrumandCoke":
                beatScroller.gameObject.transform.GetChild(4).gameObject.SetActive(true);
                break;
            case "Yeowlgabombs":
                beatScroller.gameObject.transform.GetChild(5).gameObject.SetActive(true);
                break;
            case "WiskeryandCoke":
                beatScroller.gameObject.transform.GetChild(6).gameObject.SetActive(true);
                break;
            case "Lemeownade":
                beatScroller.gameObject.transform.GetChild(7).gameObject.SetActive(true);
                break;
        }
        float delayTime = beatScroller.SetNotePlacements(GameObject.Find(cocktail.ToString()));
        // and play it!
        audioSource.clip = clip;
        StartCoroutine(FadeOutMusic(titleScreenAudio, 3.0f));
        StartCoroutine(PlaySong(delayTime));
    }

    private IEnumerator PlaySong(float startDelay)
    {
        yield return new WaitForSeconds(startDelay - 0.2f);
        audioSource.Play();
        StartCoroutine(SongDoneYet());
    }

    private IEnumerator SongDoneYet()
    {
        yield return null;
        while (audioSource.isPlaying) 
        {
            yield return null;
        }
        if (HasGameFinished() == true)
        {
            gameFinished = true;
        }
        beatScroller.hasStarted = false;
        rhythmBarSR.enabled = false;
        noteHitSR.enabled = false;
        titleScreenAudio.volume = titleScreenAudioVolume;
        SeatController.RemoveCatFromSeat(currentSeatNum);
        titleScreenAudio.Play();
    }

    private IEnumerator FadeOutMusic(AudioSource audioSrc, float fadeTime)
    {
        float startingVolume = audioSrc.volume;
        while (audioSrc.volume > 0)
        {
            audioSrc.volume -= startingVolume * Time.deltaTime / fadeTime;

            yield return null;
        }

        audioSrc.Pause();
    }

    private bool HasGameFinished()
    {
        if (totalScore >= 2500)
        {
            return true;
        } else 
        { 
            return false;
        }
    }

    public void NoteHit(float noteScore)
    {
        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierCounter++;
            if (multiplierThresholds[currentMultiplier - 1] <= multiplierCounter)
            {
                multiplierCounter = 0;
                currentMultiplier++;
            }
        }
        totalScore += noteScore * currentMultiplier;
        scoreText.text = "Score: " + totalScore;
        multiplierText.text = "Multiplier: x" + currentMultiplier;
    }

    public void NoteMissed()
    {
        totalScore -= 10;
        currentMultiplier = 1;
        multiplierCounter = 0;

        scoreText.text = "Score: " + totalScore;
        multiplierText.text = "Multiplier: x" + currentMultiplier;
    }
}
