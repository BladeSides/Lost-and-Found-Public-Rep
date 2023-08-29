using BrewedInk.CRT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRTAnimator : MonoBehaviour
{
    public CRTCameraBehaviour CRTCameraBehaviour;
    private Material crtRenderMaterial;
    // Start is called before the first frame update
    void Start()
    {
        CRTCameraBehaviour = GetComponent<CRTCameraBehaviour>();
        crtRenderMaterial = CRTCameraBehaviour._runtimeMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        crtRenderMaterial.SetVector(CRTCameraBehaviour.PropColorScans, new Vector4
        {
            x = -0.1f,
            y = -0.1f,
            z = Random.Range(0f, 1f)
        });
    }
}
