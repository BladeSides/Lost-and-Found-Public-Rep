using RainFramework.Art;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : BaseObject
{
    public bool Brushed = false;
    public bool _canBrush = false;
    public MeshRenderer BrushingMeshRenderer;

    public GameObject BandageCutscene;
    public GameObject MedsCutscene;
    public override void Interact()
    {
        base.Interact();
        if (!GameManager.Instance.PlayerBrokenDown)
        {
            StartCoroutine(BrushTeethCutscene());
        }
        else
        {
            StartCoroutine(FixUpCutscene());
        }
    }

    private IEnumerator FixUpCutscene()
    {
        GameManager.Instance.ObjectiveText.enabled = false;

        Player.DepressionText.SetActive(false);

        Interactable = false;
        Inspectable = false;
        Player.IsInCutscene = true;
        Player.CharacterController.enabled = false;
        Player.PlayerSpriteAnimator.ChangeAnimation(Player.Gender +
    Player.PlayerValues.HurtIdleAnimation);
        Player.PlayerUI.ShowInspectButton(false);
        Player.PlayerUI.ShowInteractButton(false);

        MedsCutscene.SetActive(true);

        yield return new WaitForSeconds(2);

        BandageCutscene.SetActive(true);

        yield return new WaitForSeconds(2);

        MedsCutscene.SetActive(false);
        BandageCutscene.SetActive(false);

        Player.IsInCutscene = false;
        Player.CharacterController.enabled = true;
        GameManager.Instance.CleanedUp = true;
    }

    public IEnumerator BrushTeethCutscene()
    {
        Interactable = false;
        Inspectable = false;
        _canBrush = false;

        Player.IsInCutscene = true;
        Player.CharacterController.enabled = false;
        Player.PlayerSpriteAnimator.ChangeAnimation(Player.Gender +
    Player.PlayerValues.IdleAnimation);
        Player.PlayerUI.ShowInspectButton(false);
        Player.PlayerUI.ShowInteractButton(false);


        BrushingMeshRenderer.enabled = true;

        yield return new WaitForSeconds(1);

        Player.PlayerUI.InspectDialogue = "*rustling*";
        Player.PlayerUI.StartInspecting();

        while (!Player.PlayerUI.HasInspected)
        {
            yield return null;
        }


        yield return new WaitForSeconds(2);

        BrushingMeshRenderer.enabled = false;

        Player.IsInCutscene = false;
        Player.CharacterController.enabled = true;

        Inspectable = true;
        Brushed = true;
    }
}
