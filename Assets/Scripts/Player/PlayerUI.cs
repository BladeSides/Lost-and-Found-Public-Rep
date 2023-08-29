using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public GameObject InteractUI;
    public GameObject InspectUI;
    public TextMeshProUGUI SubtitleText;
    public GameDialogues InspectDialogues;
    public Player Player;
    public TypeWriter sTypeWriter;
    public Coroutine SubtitleTextCoroutine;
    public AudioSource AudioSource;

    public string InspectDialogue;
    public bool EnabledDepressionText = false;
    public bool HasInspected
    {
        get
        {
            if (SubtitleText.text == InspectDialogue && sTypeWriter.IsFinished)
            {
                return true;
            }
            return false;
        }
    }

    public void Awake()
    {
        Player = GetComponent<Player>();
        sTypeWriter = SubtitleText.GetComponent<TypeWriter>();
    }

    public void ShowInteractButton(bool show)
    {
        InteractUI.SetActive(show);
    }
    public void ShowInspectButton(bool show)
    {
        InspectUI.SetActive(show);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && Player.CanInspect && sTypeWriter.IsTyping == false)
        {
            StartInspecting();
            Player.ActiveObject.Inspect();
        }

        if (GameManager.Instance.PlayerBrokenDown && !EnabledDepressionText)
        {
            Player.DepressionText.SetActive(true);
            EnabledDepressionText = true;
        }

        if (InteractUI.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            AudioSource.Play();
        }
    }

    public void StartInspecting()
    {
        SubtitleText.gameObject.SetActive(true);
        sTypeWriter.CurrentText = "";
        sTypeWriter.TargetText = InspectDialogue;
        sTypeWriter.StartTyping();
        Player.CanInspect = false;
        Player.CanInteract = false;
        SubtitleTextCoroutine = StartCoroutine(InspectText());
    }

    public IEnumerator InspectText()
    {
        while (!sTypeWriter.IsFinished)
        {
            SubtitleText.text = sTypeWriter.CurrentText + "|";
            yield return null;
        }

        SubtitleText.text = sTypeWriter.CurrentText;

        yield return new WaitForSeconds(2f);

        SubtitleText.gameObject.SetActive(false);
        sTypeWriter.StopTyping();
    }

}
