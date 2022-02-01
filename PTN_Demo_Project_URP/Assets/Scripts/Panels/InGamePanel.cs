using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGamePanel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI playerRankingText;

    void Start()
    {
        playerRankingText.text = RankManager.instance.PlayerRanking.ToString();
    }

    void Update()
    {
        playerRankingText.text = RankManager.instance.PlayerRanking.ToString();
    }
}
