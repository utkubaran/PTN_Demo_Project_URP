using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject inGamePanel;

    [SerializeField]
    private GameObject tapToPlayPanel;

    [SerializeField]
    private GameObject levelEndPanel;

    private void OnEnable()
    {
        EventManager.OnSceneStart.AddListener( () => tapToPlayPanel.SetActive(true) );
        EventManager.OnSceneStart.AddListener( () => inGamePanel.SetActive(false) );
        EventManager.OnSceneStart.AddListener( () => levelEndPanel.SetActive(false) );

        EventManager.OnLevelStart.AddListener( () => tapToPlayPanel.SetActive(false) );
        EventManager.OnLevelStart.AddListener( () => inGamePanel.SetActive(true) );
        EventManager.OnLevelStart.AddListener( () => levelEndPanel.SetActive(false) );

        EventManager.OnSceneFinish.AddListener( () => inGamePanel.SetActive(false) );
        EventManager.OnRaceFinish.AddListener( () => inGamePanel.SetActive(false) );
        EventManager.OnRaceFinish.AddListener( () => levelEndPanel.SetActive(true) );
    }

    private void OnDisable()
    {
        EventManager.OnSceneStart.RemoveListener( () => tapToPlayPanel.SetActive(true) );
        EventManager.OnSceneStart.RemoveListener( () => inGamePanel.SetActive(false) );
        EventManager.OnSceneStart.RemoveListener( () => levelEndPanel.SetActive(false) );

        EventManager.OnLevelStart.RemoveListener( () => tapToPlayPanel.SetActive(false) );
        EventManager.OnLevelStart.RemoveListener( () => inGamePanel.SetActive(true) );
        EventManager.OnLevelStart.RemoveListener( () => levelEndPanel.SetActive(false) );

        EventManager.OnSceneFinish.RemoveListener( () => inGamePanel.SetActive(false) );
        EventManager.OnRaceFinish.RemoveListener( () => inGamePanel.SetActive(false) );
        EventManager.OnRaceFinish.RemoveListener( () => levelEndPanel.SetActive(true) );
    }
}
