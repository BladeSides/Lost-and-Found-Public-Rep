using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public TypeWriter TypeWriter;
    public AudioSource AudioSource;
    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        if (sceneName == "Opening")
        {
            TypeWriter.TargetText = "Credits:\n\nDeveloped by BladeSides (Pyush Chamoli)\nArt by Han Pham Nguyen (RealShortGuy13)\nVoice by Theoni Fotoglou\n\n raincloud interactive.\n\nWritten as a letter to myself.";
        }
        StartCoroutine(BeginText());
    }

    public IEnumerator BeginText()
    {
        yield return new WaitForSeconds(2f);
        AudioSource.Play();
        TypeWriter.StartTyping();
    }

    // Update is called once per frame
    void Update()
    {
        Text.text = TypeWriter.CurrentText;

        if (TypeWriter.IsFinished && TypeWriter.CurrentText != "")
        {
            StartCoroutine(ReturnToMenu());
        }
    }

    public IEnumerator ReturnToMenu()
    {
        if (sceneName == "Opening")
        {
            yield return new WaitForSeconds(5f);
            Application.Quit();
        }
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneName);
    }
}
