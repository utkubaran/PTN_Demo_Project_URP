using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int currentSceneIndex;
    public int CurrentSceneIndex { get { return currentSceneIndex; } }

    private void OnEnable()
    {
        EventManager.OnTapToPlayButtonPressed.AddListener(StartGameplay);
    }

    private void OnDisable()
    {
        EventManager.OnTapToPlayButtonPressed.RemoveListener(StartGameplay);
    }
    
    private void Awake()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        EventManager.OnSceneStart?.Invoke();
    }

    private void Start()
    {
        EventManager.OnSceneStart?.Invoke();
    }

    private void StartGameplay()
    {
        EventManager.OnLevelStart?.Invoke();
    }
}
