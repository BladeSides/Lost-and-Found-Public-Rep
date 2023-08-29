using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushTeeth : GameState
{
    Sink _sink;
    bool _startedNext = false;
    public override void EndState()
    {
    }

    public override void StartState()
    {
        _sink = GameObject.FindGameObjectWithTag("Sink").GetComponent<Sink>();
        _sink.Interactable = true;

        ShowObjective();

        ObjectiveTextTypeWriter.TargetText = GameManager.Instance.objectiveText.GetValue("BrushTeethText");
    }

    public override void UpdateState()
    {
        ObjectiveText.text = ObjectiveTextTypeWriter.CurrentText;
        if (!ObjectiveTextTypeWriter.IsFinished)
        {
            ObjectiveText.text += "|";
        }

        if (!_sink.Interactable)
        {
            ObjectiveText.enabled = false;
        }
        else
        {
            ObjectiveText.enabled = true;
        }
        if (_sink.Brushed && !_startedNext)
        {
            GameManager.Instance.NextState(0);
            _startedNext = true;
        }
    }
}
