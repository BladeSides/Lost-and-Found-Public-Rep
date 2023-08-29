using RainFramework.Art;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static TeleportLocations;

public class WakeUp : GameState
{
    public Camera MainCamera;
    public bool hasPressedE = false;
    public bool hasWokenUp = false;
    public bool Ended = false;
    Player Player;
    public override void EndState()
    {

    }

    public override void StartState()
    {
        ShowObjective();

        ObjectiveTextTypeWriter.TargetText = GameManager.Instance.objectiveText.GetValue("WakeUpText");

        SetStartingLocations();

        Player = GameManager.Instance.PlayerInstance;
        Player.CharacterController.enabled = false;

        Player.PlayerSpriteAnimator.ChangeAnimation(Player.Gender +
            Player.PlayerValues.SleepAnimation);


        Player.IsInCutscene = true;
        MainCamera = Camera.main;
    }

    public override void UpdateState()
    {
        if (Ended)
        {
            return;
        }

        ObjectiveText.text = ObjectiveTextTypeWriter.CurrentText;

        if (!ObjectiveTextTypeWriter.IsFinished)
        {
            ObjectiveText.text += "|";
        }

        if (!hasWokenUp)
        {
            Player.PlayerUI.ShowInteractButton(true);
        }

        if (Input.GetKeyDown(KeyCode.E) && !hasPressedE)
        {
            hasPressedE = true;
            GameManager.Instance.ObjectiveText.enabled = false;
            hasWokenUp = true;
            Player.PlayerUI.ShowInteractButton(false);
            StartWakeUpAnimation();

        }
        if (Player.PlayerSpriteAnimator.currentAnimation.Name == Player.Gender + Player.PlayerValues.GetUpAnimation)
        {
            if (Player.PlayerSpriteAnimator.IsFinished)
            {
                Player.CharacterController.enabled = true;
                Player.IsInCutscene = false;
                GameManager.Instance.NextState(3);
                Ended = true;
            }
        }
    }

    private void StartWakeUpAnimation()
    {
        GameManager.Instance.EyeAnimator.ChangeAnimation("Eyes_Blink");
        Player.PlayerSpriteAnimator.ChangeAnimation(Player.Gender + Player.PlayerValues.GetUpAnimation);
        Player.PlayerSpriteAnimator.AnimationMesh.transform.localRotation = Quaternion.Euler(100, 0, -180);
        Player.transform.position = new Vector3(37.341F, 0.075f, -2.469f);
    }

    private void SetStartingLocations()
    {
        foreach (TeleportLocation teleportLocation in GameManager.Instance.TeleportLocations.Locations)
        {
            if (teleportLocation.Key == "PlayerWakeUpLocation")
            {
                TeleportPlayer(teleportLocation);
            }
        }
        foreach (TeleportLocation teleportLocation in GameManager.Instance.TeleportLocations.Locations)
        {
            if (teleportLocation.Key == "CameraBedRoom")
            {
                TeleportCamera(teleportLocation);
            }
        }

        foreach (TeleportLocation teleportLocation in GameManager.Instance.TeleportLocations.Locations)
        {
            if (teleportLocation.Key == "PlayerWakeUpLocationSpriteAnimator")
            {
                GameManager.Instance.PlayerInstance.PlayerSpriteAnimator.AnimationMesh.gameObject.transform.localRotation
                    = Quaternion.Euler(teleportLocation.TargetLocation);
            }
        }

        foreach (TeleportLocation teleportLocation in GameManager.Instance.TeleportLocations.Locations)
        {
            if (teleportLocation.Key == "PlayerWakeUpRotationSpriteAnimator")
            {
                GameManager.Instance.PlayerInstance.PlayerSpriteAnimator.AnimationMesh.gameObject.transform.localRotation
                    = Quaternion.Euler(teleportLocation.TargetLocation);
            }
        }
    }


    private void TeleportCamera(TeleportLocation teleportLocation)
    {
        GameManager.Instance.MainCamera.GetComponent<SinAnimator>().UpdateStartingPosition(teleportLocation.TargetLocation);;
    }

    private void TeleportPlayer(TeleportLocation teleportLocation)
    {
        CharacterController c = GameManager.Instance.PlayerInstance.GetComponent<CharacterController>();
        c.enabled = false;
        GameManager.Instance.PlayerInstance.transform.position = teleportLocation.TargetLocation;
        c.enabled = true;
        ExitCollider();
    }

}
