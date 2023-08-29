using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectButtonShower : MonoBehaviour
{
    BaseObject baseObject;
    private void Awake()
    {
        baseObject = GetComponent<BaseObject>();
    }

    void OnTriggerStay(Collider other)
    {
        if (baseObject.Inspectable)
        {
            if (GameManager.Instance.PlayerInstance.CanInspect)
            {
                GameManager.Instance.PlayerInstance.PlayerUI.ShowInspectButton(true);
            }
            else
            {
                GameManager.Instance.PlayerInstance.PlayerUI.ShowInspectButton(false);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        GameManager.Instance.PlayerInstance.PlayerUI.ShowInspectButton(false);
    }
}
