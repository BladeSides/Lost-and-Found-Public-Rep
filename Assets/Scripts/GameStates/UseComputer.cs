using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseComputer : GameState
{
    public Computer Computer;
    public override void EndState()
    {
        //throw new System.NotImplementedException();
    }

    public override void StartState()
    {
        Computer = GameObject.FindGameObjectWithTag("Computer").GetComponent<Computer>();
        Computer.Interactable = true;
        ShowObjective();

        if (!GameManager.Instance.InteractedWithComputer)
        {
            ObjectiveTextTypeWriter.TargetText = GameManager.Instance.objectiveText.GetValue("UseComputerText");
        }
        else
        {
            ObjectiveTextTypeWriter.TargetText = "It's my birthday today.";
        }
    }

    public override void UpdateState()
    {
        ObjectiveText.text = ObjectiveTextTypeWriter.CurrentText;
        if (GameManager.Instance.InteractedWithComputer)
        {
            ObjectiveText.enabled = false;
        }
    }

}
