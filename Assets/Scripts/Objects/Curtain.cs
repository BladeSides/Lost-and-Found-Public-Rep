using RainFramework.Art;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curtain : BaseObject
{
    public SpriteAnimator SpriteAnimator;
    private void Awake()
    {
        SpriteAnimator = GetComponent<SpriteAnimator>();
    }
    public override void Interact()
    {
        base.Interact();
        if (SpriteAnimator.currentAnimation.Name == "CurtainClosed")
        {
            SpriteAnimator.ChangeAnimation("CurtainOpening");
        }
        if (SpriteAnimator.currentAnimation.Name == "CurtainOpen")
        {
            SpriteAnimator.ChangeAnimation("CurtainClosing");
        }
    }
    public void Update()
    {
        if (SpriteAnimator.currentAnimation.Name.Equals("CurtainClosed") || SpriteAnimator.currentAnimation.Name.Equals("CurtainOpen"))
        {
            Interactable = true;
        }
        else
        {
            Interactable = false;
            if (SpriteAnimator.currentAnimation.Name.Equals("CurtainClosing") && SpriteAnimator.IsFinished)
            {
                SpriteAnimator.ChangeAnimation("CurtainClosed");
            }
            if (SpriteAnimator.currentAnimation.Name.Equals("CurtainOpening") && SpriteAnimator.IsFinished)
            {
                SpriteAnimator.ChangeAnimation("CurtainOpen");
            }
        }
    }

}
