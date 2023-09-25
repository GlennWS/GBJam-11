using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public GameObject tutorialBox;
    public TextMeshProUGUI tutorialBoxText;
    public string[] tutorialText;
    public float delayBetweenCharacters = 0.05f;

    private string currentText = "";
    private bool typing = false;
    private bool finishedTyping = false;
    private bool waitForInput = false;

    void OnEnable()
    {
        tutorialBox.SetActive(true);
        StartCoroutine(TypeTutorialText());
    }

    public IEnumerator TypeText(string fullText)
    {
        typing = true;
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i + 1);
            tutorialBoxText.text = currentText;
            yield return new WaitForSeconds(delayBetweenCharacters);
        }
        typing = false;
    }

    public IEnumerator TypeTutorialText()
    {
        for (int i = 0; i < tutorialText.Length; i++)
        {
            tutorialBoxText.text = "";
            yield return StartCoroutine(TypeText(tutorialText[i]));
            yield return new WaitForSeconds(1);
            if (i ==  tutorialText.Length - 1)
            {
                tutorialBox.SetActive(false);
            }
        }
        finishedTyping = true;
    }

    public IEnumerator WaitForSecondsOrInput(float time)
    {
        WaitForSeconds waitTime = new WaitForSeconds(time);
        yield return waitTime;
        waitForInput = true;

        while (waitForInput)
        {
            if (Input.anyKeyDown)
            {
                waitForInput = false;
                yield break;
            }

            yield return null;
        }
    }

    void Update()
    {
        
    }
}
