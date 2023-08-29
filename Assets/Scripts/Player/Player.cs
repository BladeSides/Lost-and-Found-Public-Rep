using RainFramework.Art;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public CharacterController CharacterController;
    public SpriteAnimator PlayerSpriteAnimator;
    public PlayerController PlayerController;
    public PlayerAnimator PlayerAnimator;
    public PlayerValues PlayerValues;
    public PlayerUI PlayerUI;
    public string Gender = "F";
    public BaseObject ActiveObject;
    public bool CanInspect = false;
    public bool CanInteract = false;
    public bool IsInspecting;
    public bool IsInCutscene = false;
    public GameObject DepressionText;
    private void Awake()
    {
        CharacterController = GetComponent<CharacterController>();
        PlayerSpriteAnimator = GetComponent<SpriteAnimator>();
        PlayerController = GetComponent<PlayerController>();
        PlayerAnimator = GetComponent<PlayerAnimator>();
        PlayerUI = GetComponent<PlayerUI>();
    }

    public void SetActiveObject(BaseObject activeObject)
    {
        ActiveObject = activeObject;
    }


    // Update is called once per frame
    void Update()
    {
        if (IsInCutscene)
        {
            return;
        }
        if (PlayerUI.SubtitleText.IsActive())
        {
            IsInspecting = true;
        }
        else
        {
            IsInspecting = false;
        }
        if (IsInspecting)
        {
            CanInspect = false;
            CanInteract = false;
        }

        if (CanInteract)
        {
            if (ActiveObject == null)
            {
                return;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                ActiveObject.Interact();
            }
        }
    }
}
