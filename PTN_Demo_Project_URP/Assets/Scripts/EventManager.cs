using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    #region Level Events
    public static UnityEvent OnLevelStart = new UnityEvent();
    public static UnityEvent OnLevelFinish = new UnityEvent();
    public static UnityEvent OnLevelFail = new UnityEvent();
    public static UnityEvent OnRaceFinish = new UnityEvent();
    #endregion

    #region Player Events
    public static UnityEvent OnPlayerHitObstacle = new UnityEvent();
    public static RankEvent OnPlayerRankUpdated = new RankEvent();
    #endregion
}

public class RankEvent : UnityEvent<int> { }
