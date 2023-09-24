using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public GameObject tutorialBox;
    public TextMeshProUGUI tutorialBoxText;
    // string array? just loop through them
    public string firstText;
    public string secondText;
    public string thirdText;
    public string fourthText;
    public float delayBetweenCharacters = 0.05f;

    private string currentText = "";
    private bool typing = false;

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
        tutorialBoxText.text = "";
        yield return StartCoroutine(TypeText(firstText));
        yield return new WaitForSeconds(4);
        tutorialBoxText.text = "";
        yield return StartCoroutine(TypeText(secondText));
        yield return new WaitForSeconds(4);
        tutorialBoxText.text = "";
        yield return StartCoroutine(TypeText(thirdText));
        yield return new WaitForSeconds(4);
        tutorialBoxText.text = "";
        yield return StartCoroutine(TypeText(fourthText));
    }

    void Update()
    {
        
    }
}
