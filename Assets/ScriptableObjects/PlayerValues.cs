using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerValues : ScriptableObject
{
    //Animations
    public string WalkingAnimation = "_Walk";
    public string IdleAnimation = "_Idle";
    public string SleepAnimation = "_Sleep";
    public string GetUpAnimation = "_GetUp";
    public string HurtIdleAnimation = "_HurtIdle";
    public string HurtWalkAnimation = "_HurtWalk";  

    //Player Movement Values
    public float MaxSpeed = 2f;
    public float Acceleration = 4f;
}
