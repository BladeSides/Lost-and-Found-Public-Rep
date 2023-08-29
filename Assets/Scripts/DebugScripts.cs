using RainFramework.Art;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TeleportLocations;

public class DebugScripts : MonoBehaviour
{
    public Player Player;
    public string Name;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameManager.Instance.PlayerInstance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {

            foreach (TeleportLocation teleportLocation in GameManager.Instance.TeleportLocations.Locations)
            {
                if (teleportLocation.Key.Equals("LivingRoomToOutside"))
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

        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            foreach (TeleportLocation teleportLocation in GameManager.Instance.TeleportLocations.Locations)
            {
                if (teleportLocation.Key.Equals("OutsideToLivingRoom"))
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
        if (Input.GetKeyDown(KeyCode.F3))
        {
            foreach (TeleportLocation teleportLocation in GameManager.Instance.TeleportLocations.Locations)
            {
                if (teleportLocation.Key.Equals("LivingRoomToBedRoom"))
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
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            foreach (TeleportLocation teleportLocation in GameManager.Instance.TeleportLocations.Locations)
            {
                if (teleportLocation.Key.Equals("LivingRoomToBathRoom"))
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
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            TeleportLocation tp = new()
            {
                TargetLocation = new Vector3(94.08f, 0.0756644f, -0.54f)
            };
            TeleportPlayer(tp);
            GameManager.Instance.MainCamera.GetComponent<SinAnimator>().UpdateStartingPosition(new Vector3(94, 5.55f, -10.23f));
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            GameManager.Instance.PlayerBrokenDown = !GameManager.Instance.PlayerBrokenDown;
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
