using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepressionText : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(GameManager.Instance.MainCamera.transform.position);
    }
}
