using System.Collections;
using System.Collections.Generic;
using RainFramework.Art;
using RainFramework.Structures;
using RainFramework.Utilities;
using TMPro;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Player PlayerInstance;
    public TeleportLocations TeleportLocations;
    public Camera MainCamera;
    public SpriteAnimator EyeAnimator;

    public GameState CurrentGameState;
    public List<GameState> GameStates = new();
    public int GameStateIndex = 0;
    public TextMeshProUGUI ObjectiveText;
    public InspectSurroundings inspectSurroundings;
    public StringDictionaryObject objectiveText;

    public bool PlayerBrokenDown = false;
    public bool CleanedUp = false;
    public bool InteractedWithComputer = false;
    public CameraController CameraController;

    public AudioSource StaticSource;
    public AudioSource ShatterSource;

    public AudioSource VCR;

    public void CreateStates()
    {
        WakeUp wakeUp = new();
        GameStates.Add(wakeUp);

        OpenWindow openWindow = new();
        GameStates.Add(openWindow);

        inspectSurroundings = new();
        GameStates.Add(inspectSurroundings);

        UseComputer useComputer = new();
        GameStates.Add(useComputer);

        BrushTeeth brushTeeth = new();
        GameStates.Add(brushTeeth);

        ShowerState showerState = new();
        GameStates.Add(showerState);

        InspectCloset inspectCloset = new();
        GameStates.Add(inspectCloset);

        FixUp fixUp = new();
        GameStates.Add(fixUp);
    }
    public void Start()
    {
        try
        {
            VCR = GameObject.FindGameObjectWithTag("VCR").GetComponent<AudioSource>();
            VCR.Stop();
        }
        catch
        {
            Debug.Log("Start the game from beginning, bozo");
        }
        PlayerInstance.Gender = PlayerPrefs.GetString("Gender");

        CreateStates();
        CurrentGameState = GameStates[GameStateIndex];
        CurrentGameState.StartState();
        CameraController = MainCamera.GetComponent<CameraController>();
    }
    public void Update()
    {
        CurrentGameState.UpdateState();
    }
    public void NextState(int delay)
    {
        StartCoroutine(NextStateCoroutine(delay));
    }

    public IEnumerator NextStateCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        CurrentGameState.EndState();
        GameStateIndex++;

        if (GameStateIndex > GameStates.Count - 1)
        {
            Debug.LogError("You fucked up. You reached GameState " + GameStateIndex);
            GameStateIndex--;
        }

        CurrentGameState = GameStates[GameStateIndex];
        CurrentGameState.StartState();
    }
}
