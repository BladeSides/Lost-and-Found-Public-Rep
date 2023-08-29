using RainFramework.Structures;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Phone : BaseObject
{
    public override void Interact()
    {

        base.Interact();
        
        if (!GameManager.Instance.CleanedUp)
        {
            GameManager.Instance.PlayerInstance.PlayerUI.InspectDialogue = "I should really fix myself up first.";
            GameManager.Instance.PlayerInstance.PlayerUI.StartInspecting();
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
