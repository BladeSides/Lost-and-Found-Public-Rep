using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InspectSurroundings : GameState
{
    public List<string> inspectedSurroundings = new();
    public int surroundingsToInspect = 5;
    private bool endingState;

    public override void EndState()
    {
    }

    public override void StartState()
    {
        ShowObjective();
        ObjectiveTextTypeWriter.TargetText = (GameManager.Instance.objectiveText.GetValue("InspectSurroundingsText") + " (" + (surroundingsToInspect - 
            inspectedSurroundings.Count) + ")");
    }

    public override void UpdateState()
    {
        ObjectiveText.text = ObjectiveTextTypeWriter.CurrentText;
        if (!ObjectiveTextTypeWriter.IsFinished)
        {
            ObjectiveText.text += "|";
        }

        if (ObjectiveTextTypeWriter.CurrentText.Contains("Inspect your surroundings. ("))
        {
            ObjectiveTextTypeWriter.TargetText = ("Inspect your surroundings. (" + (surroundingsToInspect -
        inspectedSurroundings.Count) + ")");
            ObjectiveTextTypeWriter.CurrentText = ObjectiveTextTypeWriter.TargetText;
        }

        if (inspectedSurroundings.Count >= surroundingsToInspect && !endingState)
        {
            endingState = true;
            ObjectiveText.gameObject.SetActive(false);
            GameManager.Instance.NextState(2);
        }
    }
}
