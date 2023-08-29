using RainFramework.Art;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Closet : BaseObject
{
    public GameObject CutsceneOpenAlmira;
    public GameObject CutsceneParents;
    public GameObject CutsceneBullies;

    [SerializeField] private SpriteAnimator _cutAlmiraRenderer;
    [SerializeField] private SpriteAnimator _cutParentsRenderer;
    [SerializeField] private SpriteAnimator _cutBulliesRenderer;


    public override void Start()
    {
        base.Start();

        CutsceneOpenAlmira.SetActive(false);
        CutsceneParents.SetActive(false);
        CutsceneBullies.SetActive(false);
    }
    public override void Interact()
    {
        base.Interact();
        StartCoroutine(StartCutscene());

    }

    public IEnumerator StartCutscene()
    {
        this.Interactable = false;
        this.Inspectable = false;

        Player.PlayerUI.ShowInspectButton(false);
        Player.PlayerUI.ShowInteractButton(false);

        Player.IsInCutscene = true;
        Player.CharacterController.enabled = false;
        Player.PlayerSpriteAnimator.ChangeAnimation(Player.Gender +
    Player.PlayerValues.IdleAnimation);
        GameManager.Instance.ObjectiveText.enabled = false;


        CutsceneOpenAlmira.SetActive(true);

        GameManager.Instance.CameraController.IsMoving = true; 

        GameManager.Instance.CameraController.TargetPosition = new Vector3(Player.transform.position.x, Player.transform.position.y + 5.5f,
            Player.transform.position.z - 12f);


        yield return new WaitForSeconds(2f);

        Player.PlayerSpriteAnimator.ChangeAnimation(Player.Gender + "_BreakDown");

        GameManager.Instance.CameraController.TargetPosition = new Vector3(Player.transform.position.x, Player.transform.position.y + 5.5f,
    Player.transform.position.z - 9f);

        GameManager.Instance.PlayerInstance.PlayerUI.InspectDialogue = "No.";
        GameManager.Instance.PlayerInstance.PlayerUI.StartInspecting();

        while (Player.PlayerUI.SubtitleText.gameObject.activeSelf)
        {
            yield return null;
        }
        GameManager.Instance.StaticSource.Play();

        GameManager.Instance.PlayerInstance.PlayerUI.InspectDialogue = "STOP IT!";
        GameManager.Instance.PlayerInstance.PlayerUI.StartInspecting();


        while (Player.PlayerUI.SubtitleText.gameObject.activeSelf)
        {
            yield return null;
        }


        CutsceneParents.SetActive(true);

        yield return new WaitForSeconds(2f);

        CutsceneBullies.SetActive(true);


        GameManager.Instance.CameraController.TargetPosition = new Vector3(Player.transform.position.x, Player.transform.position.y + 5.5f,
    Player.transform.position.z - 7f);

        yield return new WaitForSeconds(2f);



        CutsceneBullies.SetActive(false);
        CutsceneOpenAlmira.SetActive(false);
        CutsceneParents.SetActive(false);

        yield return new WaitForSeconds(2f);

        Player.PlayerSpriteAnimator.CurrentFrame = 0;

        GameManager.Instance.PlayerInstance.PlayerUI.InspectDialogue = "...";
        GameManager.Instance.PlayerInstance.PlayerUI.StartInspecting();

        while (Player.PlayerUI.SubtitleText.gameObject.activeSelf)
        {
            yield return null;
        }


        Player.PlayerSpriteAnimator.ChangeAnimation(Player.Gender + "_Idle");
        yield return new WaitForSeconds(0.1f);
        GameManager.Instance.ShatterSource.Play();

        Player.PlayerSpriteAnimator.ChangeAnimation(Player.Gender + "_Explode");
        Player.PlayerSpriteAnimator.ResetAnimation();

        yield return new WaitForSeconds(3f);

        GameManager.Instance.EyeAnimator.ChangeAnimation("Eyes_Blink");

        Player.transform.position = new Vector3(94.08f, 0.0756644f, -0.54f);

        GameManager.Instance.MainCamera.GetComponent<SinAnimator>().UpdateStartingPosition(new Vector3(94, 5.55f, -10.23f));
        GameManager.Instance.CameraController.IsMoving = false;

        GameManager.Instance.EyeAnimator.ResetAnimation();

        Player.IsInCutscene = false;
        Player.ActiveObject = null;
        Player.CharacterController.enabled = true;

        BaseObject[] baseObjects = FindObjectsOfType<BaseObject>();
        foreach (BaseObject obj in baseObjects)
        {
            obj.Inspectable = false;
        }
        GameManager.Instance.PlayerBrokenDown = true;
        GameManager.Instance.NextState(0);
    }
}
