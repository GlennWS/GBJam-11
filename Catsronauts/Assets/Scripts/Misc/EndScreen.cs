using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    GameObject blackoutSquare;
    GameObject titleScreenMaster;
    public AudioClip endMusic;

    // Start is called before the first frame update
    void Start()
    {
        blackoutSquare = GameObject.Find("FadeToBlackSquare");
        titleScreenMaster = GameObject.Find("TitleScreenMaster");
        titleScreenMaster.GetComponent<AudioSource>().clip = endMusic;
        titleScreenMaster.GetComponent<AudioSource>().volume = 0.16f;
        titleScreenMaster.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = blackoutSquare.GetComponent<Transform>().transform.position;
        blackoutSquare.GetComponent<Transform>().transform.position = Vector3.MoveTowards(currentPos, new Vector3(-10.0f, 0.0f, 0.0f), 5.0f * Time.deltaTime);
    }
}
