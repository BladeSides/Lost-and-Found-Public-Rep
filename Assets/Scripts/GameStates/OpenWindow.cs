using RainFramework.Art;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OpenWindow : GameState
{
    public SpriteAnimator windowAnimator;
    public bool startedCurtainText = false;
    public bool startedChanging = false;

    public override void EndState()
    {
        GameManager.Instance.PlayerInstance.IsInCutscene = false;
        GameManager.Instance.PlayerInstance.CharacterController.enabled = true;
    }

    public override void StartState()
    {
        windowAnimator = GameObject.FindGameObjectWithTag("Window").GetComponent<SpriteAnimator>();

        ShowObjective();

        ObjectiveTextTypeWriter.TargetText = GameManager.Instance.objectiveText.GetValue("OpenWindowText");
        windowAnimator.gameObject.GetComponent<BaseObject>().Inspectable = false;
    }

    public override void UpdateState()
    {
        ObjectiveText.text = ObjectiveTextTypeWriter.CurrentText;
        if (!ObjectiveTextTypeWriter.IsFinished)
        {
            ObjectiveText.text += "|";
        }


        if (windowAnimator.currentAnimation.Name == "CurtainOpen" && !startedCurtainText)
        {
            startedCurtainText = true;
            ObjectiveText.enabled = false;
            GameManager.Instance.PlayerInstance.IsInCutscene = true;
            GameManager.Instance.PlayerInstance.CharacterController.enabled = false;
            GameManager.Instance.PlayerInstance.PlayerUI.InspectDialogue = "It's so bright outside.";
            GameManager.Instance.PlayerInstance.PlayerSpriteAnimator.ChangeAnimation(GameManager.Instance.PlayerInstance.Gender +
                GameManager.Instance.PlayerInstance.PlayerValues.IdleAnimation);
            GameManager.Instance.PlayerInstance.PlayerUI.StartInspecting();
        }

        if (startedCurtainText && GameManager.Instance.PlayerInstance.PlayerUI.HasInspected && !startedChanging)
        {
            startedChanging = true;
            windowAnimator.gameObject.GetComponent<BaseObject>().Inspectable = true;
            GameManager.Instance.NextState(2);
        }
    }
}
