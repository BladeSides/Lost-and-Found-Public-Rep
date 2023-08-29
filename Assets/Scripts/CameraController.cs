using RainFramework.Art;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TODO: https://gamedev.stackexchange.com/questions/167317/scale-camera-to-fit-screen-size-unity
public class CameraController : MonoBehaviour
{
    public Vector3 TargetPosition;
    public float Speed = 3f;
    public bool IsMoving = false;
    public SinAnimator SinAnimator;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (IsMoving)
        {
           SinAnimator.UpdateStartingPosition(Vector3.MoveTowards(SinAnimator.GetStartingPosition(), TargetPosition, Speed * Time.deltaTime));
        }
    }
}
