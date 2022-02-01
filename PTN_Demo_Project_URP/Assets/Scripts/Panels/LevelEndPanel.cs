using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndPanel : MonoBehaviour
{
    public void PressPlayButton()
    {
        EventManager.OnPlayButtonPressed?.Invoke();
    }
}
