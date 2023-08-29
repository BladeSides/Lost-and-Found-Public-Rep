using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelection : MonoBehaviour
{
    public GameObject SelectionHighlight;
    public string Gender;

    public void DisplaySelectionHighlight()
    {
        SelectionHighlight.SetActive(true);
    }

    public void HideSelectionHighlight()
    {
        SelectionHighlight?.SetActive(false);
    }

    public void StoreGender()
    {
        PlayerPrefs.SetString("Gender", Gender);
        PlayerPrefs.Save();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
