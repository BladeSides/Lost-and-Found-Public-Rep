using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectCloset : GameState
{
    Closet _closet;

    public override void EndState()
    {
        //throw new System.NotImplementedException();
    }

    public override void StartState()
    {
        _closet = GameObject.FindGameObjectWithTag("Closet").GetComponent<Closet>();
        _closet.Interactable = true;

        ShowObjective();

        ObjectiveTextTypeWriter.TargetText = GameManager.Instance.objectiveText.GetValue("InspectClosetText");
    }

    public override void UpdateState()
    {
        ObjectiveText.text = ObjectiveTextTypeWriter.CurrentText;
        if (!ObjectiveTextTypeWriter.IsFinished)
        {
            ObjectiveText.text += "|";
        }
    }
}
