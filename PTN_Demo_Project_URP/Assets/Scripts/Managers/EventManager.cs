using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    #region Level Events
    public static UnityEvent OnSceneStart = new UnityEvent();
    public static UnityEvent OnLevelStart = new UnityEvent();
    public static UnityEvent OnLevelFail = new UnityEvent();
    public static UnityEvent OnRaceFinish = new UnityEvent();
    public static UnityEvent OnPaintFinish = new UnityEvent();
    public static UnityEvent OnSceneFinish = new UnityEvent();
    #endregion

    #region Player Events
    public static UnityEvent OnPlayerHitObstacle = new UnityEvent();
    public static RankEvent OnPlayerRankUpdated = new RankEvent();
    #endregion

    #region Button Events
    public static UnityEvent OnTapToPlayButtonPressed = new UnityEvent();
    #endregion
}

public class RankEvent : UnityEvent<int> { }
