using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class RankManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> participants = new List<GameObject> ();

    [SerializeField]
    private float rankTimer = 1f;

    private GameObject player;

    private int playerRanking; 
    public int PlayerRanking { get { return playerRanking; } }

    private float timeRemaining;

    private bool isPlaying;

    #region Event Actions
    private void OnEnable()
    {
        EventManager.OnLevelStart.AddListener( () => isPlaying = true );
        EventManager.OnLevelFail.AddListener( () => isPlaying = false );
        EventManager.OnRaceFinish.AddListener( () => isPlaying = false );
    }
    
    private void OnDisable()
    {
        EventManager.OnLevelStart.RemoveListener( () => isPlaying = true );
        EventManager.OnLevelFail.RemoveListener( () => isPlaying = false );
        EventManager.OnRaceFinish.RemoveListener( () => isPlaying = false );
    }
    #endregion

    private void Awake()
    {
        participants = GameObject.FindGameObjectsWithTag("Opponent").ToList();
        player = FindObjectOfType<PlayerMovementController>().gameObject;
        participants.Add(player);
    }

    void Start()
    {
        isPlaying = true;           // todo remove after events is enabled
        timeRemaining = rankTimer;
    }

    void Update()
    {
        UpdateRanking();
    }

    private void UpdateRanking()
    {
        timeRemaining -= Time.deltaTime;

        if (timeRemaining >= 0f || !isPlaying) return;

        participants = participants.OrderBy( GameObject => -GameObject.transform.position.z ).ToList();
        playerRanking = participants.IndexOf(player) + 1;
        EventManager.OnPlayerRankUpdated?.Invoke(playerRanking);
        timeRemaining = rankTimer;
    }
}
