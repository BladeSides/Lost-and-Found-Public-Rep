using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : BaseObject
{
    public Light Light;

    public override void Interact()
    {
        base.Interact();
        Light.enabled = !Light.enabled;
        base.Interact();
    }
}
