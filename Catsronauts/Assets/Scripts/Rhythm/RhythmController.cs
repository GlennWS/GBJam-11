using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RhythmController : MonoBehaviour
{
    public BeatScroller beatScroller;
    public SpriteRenderer rhythmBarSR;
    public SpriteRenderer noteHitSR;
    public float totalScore = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI multiplierText;

    public int currentMultiplier;
    public int multiplierCounter;
    public int[] multiplierThresholds;

    void OnEnable()
    {
        currentMultiplier = 1;
        PlayerController.onServeCocktail += StartRhythmGame;
    }

    void OnDisable()
    {
        PlayerController.onServeCocktail -= StartRhythmGame;
    }

    void Update()
    {
        
    }

    void StartRhythmGame(Cocktail cocktail)
    {
        // Set the rhythm game as started
        beatScroller.hasStarted = true;
        // Show the sprites of the rhythm bar and hit outline
        rhythmBarSR.enabled = true;
        noteHitSR.enabled = true;
        Debug.Log("rhythm game started");
        // Get the correct song,
        Songlist sl = GetComponent<Songlist>();
        AudioClip clip = sl.GetSong(cocktail);
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
        // and play it!
        GetComponent<AudioSource>().clip = clip;
        GetComponent<AudioSource>().Play();
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
        Debug.Log("missed");

        totalScore -= 10;
        currentMultiplier = 1;
        multiplierCounter = 0;

        multiplierText.text = "Multiplier: x" + currentMultiplier;
    }
}
