using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowerState : GameState
{
    Shower _shower;
    bool _startedNextState = false;
    public override void EndState()
    {
       // throw new System.NotImplementedException();
    }

    public override void StartState()
    {
        _shower = GameObject.FindGameObjectWithTag("Shower").GetComponent<Shower>();
        _shower.Interactable = true;

        ShowObjective();

        ObjectiveTextTypeWriter.TargetText = GameManager.Instance.objectiveText.GetValue("ShowerText");
    }

    public override void UpdateState()
    {
        ObjectiveText.text = ObjectiveTextTypeWriter.CurrentText;
        if (!ObjectiveTextTypeWriter.IsFinished)
        {
            ObjectiveText.text += "|";
        }

        if (!_shower.Interactable)
        {
            ObjectiveText.enabled = false;
        }
        else
        {
            ObjectiveText.enabled = true;
        }
        if (_shower.Showered && !_startedNextState)
        {
            _startedNextState = true;
            GameManager.Instance.NextState(2);
        }
    }
}
