using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] VCR = GameObject.FindGameObjectsWithTag("VCR");
        if (VCR.Length > 1)
        {
            for (int i = 1; i < VCR.Length; i++)
            {
                Destroy(VCR[i]);
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
