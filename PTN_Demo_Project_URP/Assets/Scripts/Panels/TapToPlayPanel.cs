using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TapToPlayPanel : MonoBehaviour
{
    public void PressTapToPlayButton()
    {
        EventManager.OnTapToPlayButtonPressed?.Invoke();
    }
}
