using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RainFramework.Art;
public class PlayerAnimator : MonoBehaviour
{
    public Player Player;

    private void Awake()
    {
        Player = GetComponent<Player>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.IsInCutscene)
        {
            return;
        }

        if (!GameManager.Instance.PlayerBrokenDown)
        {
            if (Player.PlayerController.Velocity.magnitude > 0.25f)
            {
                Player.PlayerSpriteAnimator.ChangeAnimation(Player.Gender + Player.PlayerValues.WalkingAnimation);
            }

            else
            {
                Player.PlayerSpriteAnimator.ChangeAnimation(Player.Gender + Player.PlayerValues.IdleAnimation);
            }
        }
        else
        {
            if (Player.PlayerController.Velocity.magnitude > 0.25f)
            {
                Player.PlayerSpriteAnimator.ChangeAnimation(Player.Gender + Player.PlayerValues.HurtWalkAnimation);
            }

            else
            {
                Player.PlayerSpriteAnimator.ChangeAnimation(Player.Gender + Player.PlayerValues.HurtIdleAnimation);
            }
        }


        if (InputHandler.Instance.InputHorVer.x > 0)
        {
            Player.PlayerSpriteAnimator.ToggleFlipX(true);
        }
        else if (InputHandler.Instance.InputHorVer.x < 0)
        {
            Player.PlayerSpriteAnimator.ToggleFlipX(false);
        }
    }
}
