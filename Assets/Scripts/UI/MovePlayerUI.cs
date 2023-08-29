using RainFramework.Art;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerUI : MonoBehaviour
{
    public Player Player;
    public Camera MainCamera;
    public float RightPositionX = 3.53f;
    public float LeftPositionX = -0.61f;
    public SinRectAnimator SinAnimator1;
    public SinRectAnimator SinAnimator2;

    private void Awake()
    {
        if (MainCamera == null)
        {
            MainCamera = Camera.main;
        }
    }
    private void Start()
    {
        Player = GameManager.Instance.PlayerInstance;
    }


    // Update is called once per frame
    void Update()
    {
        if (MainCamera.WorldToViewportPoint(Player.transform.position).x > 0.75f)
        {
            Vector3 sp1 = SinAnimator1.GetStartingPosition();
            Vector3 sp2 = SinAnimator2.GetStartingPosition();
            SinAnimator1.UpdateStartingPosition(new Vector3(LeftPositionX, sp1.y, sp1.z));
            SinAnimator2.UpdateStartingPosition(new Vector3(LeftPositionX, sp2.y, sp2.z));
        }
        else
        {
            Vector3 sp1 = SinAnimator1.GetStartingPosition();
            Vector3 sp2 = SinAnimator2.GetStartingPosition();
            SinAnimator1.UpdateStartingPosition(new Vector3(RightPositionX, sp1.y, sp1.z));
            SinAnimator2.UpdateStartingPosition(new Vector3(RightPositionX, sp2.y, sp2.z));
        }
    }
}
