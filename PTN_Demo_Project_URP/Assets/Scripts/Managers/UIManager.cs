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
    private GameObject raceEndPanel;

    [SerializeField]
    private GameObject levelEndPanel;

    private void OnEnable()
    {
        EventManager.OnSceneStart.AddListener( () => tapToPlayPanel.SetActive(true) );
        EventManager.OnSceneStart.AddListener( () => inGamePanel.SetActive(false) );
        EventManager.OnSceneStart.AddListener( () => raceEndPanel.SetActive(false) );
        EventManager.OnSceneStart.AddListener( () => levelEndPanel.SetActive(false) );

        EventManager.OnLevelStart.AddListener( () => tapToPlayPanel.SetActive(false) );
        EventManager.OnLevelStart.AddListener( () => inGamePanel.SetActive(true) );
        EventManager.OnLevelStart.AddListener( () => raceEndPanel.SetActive(false) );

        EventManager.OnRaceFinish.AddListener( () => inGamePanel.SetActive(false) );
        EventManager.OnRaceFinish.AddListener( () => raceEndPanel.SetActive(true) );

        EventManager.OnPaintFinish.AddListener( () => raceEndPanel.SetActive(false) );
        EventManager.OnPaintFinish.AddListener( () => levelEndPanel.SetActive(true) );
        
    }

    private void OnDisable()
    {
        EventManager.OnSceneStart.RemoveListener( () => tapToPlayPanel.SetActive(true) );
        EventManager.OnSceneStart.RemoveListener( () => inGamePanel.SetActive(false) );
        EventManager.OnSceneStart.RemoveListener( () => raceEndPanel.SetActive(false) );
        EventManager.OnSceneStart.RemoveListener( () => levelEndPanel.SetActive(false) );

        EventManager.OnLevelStart.RemoveListener( () => tapToPlayPanel.SetActive(false) );
        EventManager.OnLevelStart.RemoveListener( () => inGamePanel.SetActive(true) );
        EventManager.OnLevelStart.RemoveListener( () => raceEndPanel.SetActive(false) );

        EventManager.OnRaceFinish.RemoveListener( () => inGamePanel.SetActive(false) );
        EventManager.OnRaceFinish.RemoveListener( () => raceEndPanel.SetActive(true) );

        EventManager.OnPaintFinish.RemoveListener( () => raceEndPanel.SetActive(false) );
        EventManager.OnPaintFinish.RemoveListener( () => levelEndPanel.SetActive(true) );
    }
}
