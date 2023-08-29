using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixUp : GameState
{
    public override void EndState()
    {
        //throw new System.NotImplementedException();
    }

    public override void StartState()
    {
        GameManager.Instance.PlayerBrokenDown = true;

        ShowObjective();

        GameObject.FindGameObjectWithTag("Sink").GetComponent<Sink>().Interactable = true;

        ObjectiveTextTypeWriter.TargetText = GameManager.Instance.objectiveText.GetValue("FixUpText");
    }

    public override void UpdateState()
    {
        ObjectiveText.text = ObjectiveTextTypeWriter.CurrentText;

        if (!ObjectiveTextTypeWriter.IsFinished)
        {
            ObjectiveText.text += "|";
        }

        //throw new System.NotImplementedException();
    }
}
