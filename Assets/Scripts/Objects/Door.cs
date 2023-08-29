using RainFramework.Art;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TeleportLocation = TeleportLocations.TeleportLocation;
public class Door : BaseObject
{
    public List<GameObject> ObjectsToSetActive = new();
    public List<GameObject> ObjectsToSetInactive = new();
    public SinAnimator _cameraSinAnimator;
    public override void Interact()
    {
        base.Interact();
        GameManager.Instance.EyeAnimator.ChangeAnimation("Open_Eyes");
        GameManager.Instance.EyeAnimator.ResetAnimation();
        switch (Name)
        {
            case "LivingRoomToOutside":
                foreach (TeleportLocation teleportLocation in GameManager.Instance.TeleportLocations.Locations)
                {
                    if (teleportLocation.Key.Equals(Name))
                    {
                        TeleportPlayer(teleportLocation);
                        break;
                    }
                }
                foreach (TeleportLocation teleportLocation in GameManager.Instance.TeleportLocations.Locations)
                {
                    if (teleportLocation.Key.Equals("CameraOutside"))
                    {
                        TeleportCamera(teleportLocation);
                        break;
                    }
                }
                break;
            case "OutsideToLivingRoom":
                foreach (TeleportLocation teleportLocation in GameManager.Instance.TeleportLocations.Locations)
                {
                    if (teleportLocation.Key.Equals(Name))
                    {
                        TeleportPlayer(teleportLocation);
                        break;
                    }
                }
                foreach (TeleportLocation teleportLocation in GameManager.Instance.TeleportLocations.Locations)
                {
                    if (teleportLocation.Key.Equals("CameraLivingRoom"))
                    {
                        TeleportCamera(teleportLocation);
                        break;
                    }
                }
                break;
            case "LivingRoomToBedRoom":
                foreach (TeleportLocation teleportLocation in GameManager.Instance.TeleportLocations.Locations)
                {
                    if (teleportLocation.Key.Equals(Name))
                    {
                        TeleportPlayer(teleportLocation);
                        break;
                    }
                }
                foreach (TeleportLocation teleportLocation in GameManager.Instance.TeleportLocations.Locations)
                {
                    if (teleportLocation.Key.Equals("CameraBedRoom"))
                    {
                        TeleportCamera(teleportLocation);
                        break;
                    }
                }
                break;
            case "BedRoomToLivingRoom":
                foreach (TeleportLocation teleportLocation in GameManager.Instance.TeleportLocations.Locations)
                {
                    if (teleportLocation.Key.Equals(Name))
                    {
                        TeleportPlayer(teleportLocation);
                        break;
                    }
                }
                foreach (TeleportLocation teleportLocation in GameManager.Instance.TeleportLocations.Locations)
                {
                    if (teleportLocation.Key.Equals("CameraLivingRoom"))
                    {
                        TeleportCamera(teleportLocation);
                        break;
                    }
                }
                break;
            case "LivingRoomToBathRoom":
                foreach (TeleportLocation teleportLocation in GameManager.Instance.TeleportLocations.Locations)
                {
                    if (teleportLocation.Key.Equals(Name))
                    {
                        TeleportPlayer(teleportLocation);
                        break;
                    }
                }
                foreach (TeleportLocation teleportLocation in GameManager.Instance.TeleportLocations.Locations)
                {
                    if (teleportLocation.Key.Equals("CameraBathRoom"))
                    {
                        TeleportCamera(teleportLocation);
                        break;
                    }
                }
                break;
            case "BathRoomToLivingRoom":
                if (GameManager.Instance.PlayerBrokenDown)
                {
                    foreach (TeleportLocation teleportLocation in GameManager.Instance.TeleportLocations.Locations)
                    {
                        if (teleportLocation.Key.Equals("BreakdownLivingRoom"))
                        {
                            TeleportPlayer(teleportLocation);
                            Debug.Log(teleportLocation.TargetLocation);
                            break;
                        }
                    }
                    foreach (TeleportLocation teleportLocation in GameManager.Instance.TeleportLocations.Locations)
                    {
                        if (teleportLocation.Key.Equals("CameraBreakdown"))
                        {
                            TeleportCamera(teleportLocation);
                            break;
                        }
                    }
                }
                else
                {
                    foreach (TeleportLocation teleportLocation in GameManager.Instance.TeleportLocations.Locations)
                    {
                        if (teleportLocation.Key.Equals(Name))
                        {
                            TeleportPlayer(teleportLocation);
                            break;
                        }
                    }
                    foreach (TeleportLocation teleportLocation in GameManager.Instance.TeleportLocations.Locations)
                    {
                        if (teleportLocation.Key.Equals("CameraLivingRoom"))
                        {
                            TeleportCamera(teleportLocation);
                            break;
                        }
                    }
                }
                
                break;
        }
    }

    private void TeleportCamera(TeleportLocation teleportLocation)
    {
        GameManager.Instance.MainCamera.GetComponent<SinAnimator>().UpdateStartingPosition(teleportLocation.TargetLocation);
    }

    private void TeleportPlayer(TeleportLocation teleportLocation)
    {
        CharacterController c = GameManager.Instance.PlayerInstance.GetComponent<CharacterController>();
        c.enabled = false;
        GameManager.Instance.PlayerInstance.transform.position = teleportLocation.TargetLocation;
        c.enabled = true;
        StartCoroutine(ExitCollider());
        SetActiveObjects();
    }

    private void SetActiveObjects()
    {
        foreach (GameObject obj in ObjectsToSetActive)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in ObjectsToSetInactive)
        {
            obj.SetActive(false);
        }
    }

    private IEnumerator ExitCollider()
    {
        yield return new WaitForFixedUpdate();
        GameManager.Instance.PlayerInstance.PlayerUI.ShowInteractButton(false);
        GameManager.Instance.PlayerInstance.PlayerUI.ShowInspectButton(false);
        GameManager.Instance.PlayerInstance.CanInspect = false;
        GameManager.Instance.PlayerInstance.CanInteract = false;
    }

}
