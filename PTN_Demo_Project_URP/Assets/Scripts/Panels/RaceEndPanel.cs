using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceEndPanel : MonoBehaviour
{
    [SerializeField]
    private Slider wallPaintSlider;

    [SerializeField]
    private TexturePainter texturePainter;

    private void OnEnable()
    {
        wallPaintSlider.value = texturePainter.PaintedWallPerct;
    }

    void Update()
    {
        wallPaintSlider.value = texturePainter.PaintedWallPerct;
    }
}
