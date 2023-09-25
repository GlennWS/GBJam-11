using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    public AudioClip barMusic;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject.GetComponent<AudioSource>());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("TitleScreen"))
        {
            SceneManager.LoadScene("Bar");
            gameObject.GetComponent<AudioSource>().Stop();
            gameObject.GetComponent<AudioSource>().clip = barMusic;
            gameObject.GetComponent<AudioSource>().volume *= 0.25f;
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
