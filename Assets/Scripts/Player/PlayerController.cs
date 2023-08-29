using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 Velocity;
    public Player Player;

    private void Awake()
    {
        Player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Velocity += Player.PlayerValues.Acceleration * Time.deltaTime * 
            (InputHandler.Instance.InputHorVer.x * transform.right
            + InputHandler.Instance.InputHorVer.y * transform.forward);
        if (Mathf.Abs(InputHandler.Instance.InputHorVer.x) <= 0.1f) //Offset
        {
            Velocity -= Velocity.x * Player.PlayerValues.Acceleration * Time.deltaTime * transform.right;
            if (Mathf.Abs(Velocity.x) < Mathf.Abs(Player.PlayerValues.Acceleration * Time.deltaTime))
            {
                Velocity = new Vector3(0, Velocity.y, Velocity.z);
            }
        }
        if (Mathf.Abs(InputHandler.Instance.InputHorVer.y) <= 0.1f) //Offset
        {
            Velocity -= Velocity.y * Player.PlayerValues.Acceleration * Time.deltaTime * transform.forward;
            if (Mathf.Abs(Velocity.y) < Mathf.Abs(Player.PlayerValues.Acceleration * Time.deltaTime))
            {
                Velocity = new Vector3(Velocity.x, Velocity.y, 0);
            }
        }

        if (!GameManager.Instance.PlayerBrokenDown)
        {
            if (Velocity.sqrMagnitude > Mathf.Pow(Player.PlayerValues.MaxSpeed, 2))
            {
                Velocity = Velocity.normalized * Player.PlayerValues.MaxSpeed;
            }
        }
        else
        {
            if (Velocity.sqrMagnitude > Mathf.Pow(Player.PlayerValues.MaxSpeed/2, 2))
            {
                Velocity = Velocity.normalized * Player.PlayerValues.MaxSpeed/2;
            }
        }

        if (Player.CharacterController.enabled == false)
        {
            return;
        }
        Player.CharacterController.Move((Velocity + Vector3.down) * Time.deltaTime );
    }
}
