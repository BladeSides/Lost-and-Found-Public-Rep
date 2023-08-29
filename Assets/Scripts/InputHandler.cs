using RainFramework.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : SingletonPersistent<InputHandler>
{
    public Vector2 InputHorVer;

    // Update is called once per frame
    void Update()
    {
        InputHorVer = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}
