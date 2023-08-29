using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractButtonShower : MonoBehaviour
{
    BaseObject _baseObject;
    Player _player;

    private void Awake()
    {
        _baseObject = GetComponent<BaseObject>();
    }

    private void Start()
    {
        _player = GameManager.Instance.PlayerInstance;
    }
    public virtual void OnTriggerStay(Collider other)
    {
        if (_baseObject.Interactable && !_player.IsInspecting)
        {
            if (GameManager.Instance.PlayerInstance.CanInteract)
            {
                GameManager.Instance.PlayerInstance.PlayerUI.ShowInteractButton(true);
            }
        }
        else
        {
            GameManager.Instance.PlayerInstance.PlayerUI.ShowInteractButton(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        GameManager.Instance.PlayerInstance.PlayerUI.ShowInteractButton(false);
    }
}
