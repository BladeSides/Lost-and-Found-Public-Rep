using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public abstract class GameState
{
    public TextMeshProUGUI ObjectiveText;
    public TypeWriter ObjectiveTextTypeWriter;

    public abstract void StartState();
    public abstract void UpdateState();
    public abstract void EndState();

    public IEnumerator ExitCollider()
    {
        yield return new WaitForFixedUpdate();
        GameManager.Instance.PlayerInstance.PlayerUI.ShowInteractButton(false);
        GameManager.Instance.PlayerInstance.PlayerUI.ShowInspectButton(false);
        GameManager.Instance.PlayerInstance.CanInspect = false;
        GameManager.Instance.PlayerInstance.CanInteract = false;
    }

    public void ShowObjective()
    {
        ObjectiveText = GameManager.Instance.ObjectiveText;
        ObjectiveTextTypeWriter = ObjectiveText.GetComponent<TypeWriter>();
        ObjectiveText.text = "";
        ObjectiveTextTypeWriter.CurrentText = "";
        ObjectiveText.enabled = true;
        ObjectiveText.gameObject.SetActive(true);
        ObjectiveTextTypeWriter.IsTyping = true;
    }

}
