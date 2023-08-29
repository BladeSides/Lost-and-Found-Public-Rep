using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shower : BaseObject
{
    public bool Showered = false;

    public override void Interact()
    {
        base.Interact();
        StartCoroutine(StartShower());
    }

    public IEnumerator StartShower()
    {
        Interactable = false;
        Inspectable = false;

        Player.IsInCutscene = true;
        Player.CharacterController.enabled = false;
        Player.PlayerSpriteAnimator.ChangeAnimation(Player.Gender +
    Player.PlayerValues.IdleAnimation);
        Player.PlayerUI.ShowInspectButton(false);
        Player.PlayerUI.ShowInteractButton(false);



        Player.PlayerUI.InspectDialogue = "Actually... I don't feel like taking a shower today. Guess I'll postpone it.";
        Player.PlayerUI.StartInspecting();

        while (!Player.PlayerUI.HasInspected)
        {
            yield return null;
        }


        yield return new WaitForSeconds(2);


        Player.IsInCutscene = false;
        Player.CharacterController.enabled = true;

        Inspectable = true;
        Showered = true;
    }
}
