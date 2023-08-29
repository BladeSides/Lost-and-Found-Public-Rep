using RainFramework.Art;
using RainFramework.Structures;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : BaseObject
{
    public MaterialFader MaterialFader;

    public override void Interact()
    {
        base.Interact();

        StartCoroutine(StartCutscene());
    }

    public IEnumerator StartCutscene()
    {
        Interactable = false;
        Inspectable = false;

        Player.IsInCutscene = true;
        Player.CharacterController.enabled = false;
        Player.PlayerSpriteAnimator.ChangeAnimation(Player.Gender +
    Player.PlayerValues.IdleAnimation);
        Player.PlayerUI.ShowInspectButton(false);
        Player.PlayerUI.ShowInteractButton(false);


        MaterialFader.StartFadeIn();
        while (!MaterialFader.IsFinished)
        {
            yield return null;
        }

        GameManager.Instance.InteractedWithComputer = true;


        Player.PlayerUI.InspectDialogue = "Oh. It's my birthday today. My friends will be visiting.";
        Player.PlayerUI.StartInspecting();

        while (!Player.PlayerUI.HasInspected)
        {
            yield return null;
        }

        yield return new WaitForSeconds(2);

        Player.PlayerUI.InspectDialogue = "I should get ready.";
        Player.PlayerUI.StartInspecting();

        while (!Player.PlayerUI.HasInspected)
        {
            yield return null;
        }

        yield return new WaitForSeconds(2);


        MaterialFader.StartFadeOut();
        while (!MaterialFader.IsFinished)
        {
            yield return null;
        }

        Player.IsInCutscene = false;
        Player.CharacterController.enabled = true;

        Inspectable = true;

        GameManager.Instance.NextState(2);
    }

    public override void OnTriggerStay(Collider other)
    {
        base.OnTriggerStay(other);
        SetActiveObject();

        if (Inspectable && !GameManager.Instance.InteractedWithComputer)
        {
            foreach (Vector2String vector2String in GameManager.Instance.PlayerInstance.PlayerUI.InspectDialogues.Dialogues)
            {
                if (vector2String.Key == Name)
                {
                    GameManager.Instance.PlayerInstance.PlayerUI.InspectDialogue = vector2String.Value;
                    break;
                }
            }
        }
        else
        {
            GameManager.Instance.PlayerInstance.PlayerUI.InspectDialogue = "It's my birthday today.";
        }

    }
}
