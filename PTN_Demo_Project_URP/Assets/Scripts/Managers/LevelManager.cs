using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int currentSceneIndex;

    private void OnEnable()
    {
        EventManager.OnTapToPlayButtonPressed.AddListener(StartGameplay);
        EventManager.OnPlayButtonPressed.AddListener(LoadSameScene);
    }

    private void OnDisable()
    {
        EventManager.OnTapToPlayButtonPressed.RemoveListener(StartGameplay);
        EventManager.OnPlayButtonPressed.RemoveListener(LoadSameScene);
    }
    
    private void Awake()
    {
        Screen.SetResolution(1080, 1920, true);     // for windows build portrait mode
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Start()
    {
        EventManager.OnSceneStart?.Invoke();
    }

    private void StartGameplay()
    {
        EventManager.OnLevelStart?.Invoke();
    }

    private void LoadSameScene()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }
}
