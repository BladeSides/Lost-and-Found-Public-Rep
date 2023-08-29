using RainFramework.Structures;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject : MonoBehaviour, IInspectable, IInteractable
{
    public string Name;
    public bool Inspectable;
    public bool Interactable;
    public Player Player;
    
    public virtual void Start()
    {
        Player = GameManager.Instance.PlayerInstance;
    }
    public virtual void OnTriggerEnter(Collider other)
    {
        SetActiveObject();

        if (Inspectable)
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

    }

    public virtual void OnTriggerStay(Collider other)
    {
        if (Player.IsInspecting) //Early return
        {
            return;
        }
        if (Inspectable)
        {
            Player.CanInspect = true;
        }
        if (Interactable)
        {
            Player.CanInteract = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        Player.CanInspect = false;
        Player.CanInteract = false;
    }
    public void SetActiveObject()
    {
        GameManager.Instance.PlayerInstance.SetActiveObject(this);
    }

    public virtual void Inspect()
    {
        if (!Inspectable)
        {
            return;
        }

        InspectSurroundings IS = GameManager.Instance.inspectSurroundings;

        bool flag = false;
        foreach (string surrounding in IS.inspectedSurroundings)
        {
            if (surrounding.Equals(Name))
            {
                flag = true;
            }
        }
        if (flag == false)
        {
            IS.inspectedSurroundings.Add(Name);
        }

    }

    public virtual void Interact()
    {
        if (!Interactable)
        {
            return;
        }
    }
}
