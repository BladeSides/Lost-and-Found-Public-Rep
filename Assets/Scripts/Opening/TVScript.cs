using RainFramework.Art;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TVScript : MonoBehaviour
{
    public Material StartMaterial;
    public Material BootUpMaterial;
    public Material BootedMaterial;
    public Material CompanyMaterial;
    public MeshRenderer TVMeshRenderer;
    public GameObject Tape;

    public Vector3 FirstRotation;
    public Vector3 FirstTranslation;

    public Vector3 SecondRotation;
    public Vector3 SecondTranslation;

    public Vector3 ThirdRotation;
    public Vector3 ThirdTranslation;

    public Vector3 FourthRotation;
    public Vector3 FourthTranslation;

    public SpriteAnimator spriteAnimator;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        TVMeshRenderer.material = StartMaterial;
        StartCoroutine(Cutscene());
    }

    public IEnumerator Cutscene()
    {
        TVMeshRenderer.material = StartMaterial;
        yield return new WaitForSeconds(2);
        
        audioSource.Play();

        for (int i = 0; i < 5; i++)
        {
            TVMeshRenderer.material = BootUpMaterial;
            yield return new WaitForSeconds(0.2f);
            TVMeshRenderer.material = BootedMaterial;
            yield return new WaitForSeconds(0.2f);
        }

        TVMeshRenderer.material = BootedMaterial;

        Quaternion startingRotation = Tape.transform.localRotation;
        Vector3 startingPosition = Tape.transform.localPosition;
        float deltaTime = 0f;

        while (deltaTime < 1)
        {
           Tape.transform.localPosition = Vector3.Lerp(startingPosition, 
                FirstTranslation,
                deltaTime);
            Tape.transform.localRotation = Quaternion.Slerp(startingRotation, 
                Quaternion.Euler(FirstRotation), 
                deltaTime);
            deltaTime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        deltaTime = 0f;
        startingRotation = Tape.transform.localRotation;
        startingPosition = Tape.transform.localPosition;

        while (deltaTime < 1)
        {
            Tape.transform.localPosition = Vector3.Lerp(startingPosition,
                 SecondTranslation,
                 deltaTime);
            Tape.transform.localRotation = Quaternion.Slerp(startingRotation,
                Quaternion.Euler(SecondRotation),
                deltaTime);
            deltaTime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(1);

        deltaTime = 0f;
        startingRotation = Tape.transform.localRotation;
        startingPosition = Tape.transform.localPosition;

        while (deltaTime < 1)
        {
            Tape.transform.localPosition = Vector3.Lerp(startingPosition,
                 ThirdTranslation,
                 deltaTime);
            Tape.transform.localRotation = Quaternion.Slerp(startingRotation,
                Quaternion.Euler(ThirdRotation),
                deltaTime);
            deltaTime += Time.deltaTime;
            yield return null;
        }

        deltaTime = 0f;
        startingRotation = Tape.transform.localRotation;
        startingPosition = Tape.transform.localPosition;

        while (deltaTime < 1)
        {
            Tape.transform.localPosition = Vector3.Lerp(startingPosition,
                 FourthTranslation,
                 deltaTime);
            Tape.transform.localRotation = Quaternion.Slerp(startingRotation,
                Quaternion.Euler(FourthRotation),
                deltaTime);
            deltaTime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);
        TVMeshRenderer.material = CompanyMaterial;
        yield return new WaitForSeconds(2);

        spriteAnimator.ChangeAnimation("Eyes_Blink");


        yield return new WaitForSeconds(0.1f);


        SceneManager.LoadScene("MainMenu");

        yield return null;
    }

    private void Update()
    {
        
    }
}
