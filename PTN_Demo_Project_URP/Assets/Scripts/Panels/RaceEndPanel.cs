using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RaceEndPanel : MonoBehaviour
{
    [SerializeField]
    private Slider wallPaintSlider;

    [SerializeField]
    private TextMeshProUGUI wallPaintPerctText;

    [SerializeField]
    private GameObject instructionText;

    [SerializeField]
    private TexturePainter texturePainter;

    private void OnEnable()
    {
        ActivateInstructionTextWithDelay();
        wallPaintSlider.value = texturePainter.PaintedWallPerct;
        wallPaintPerctText.text = ((int)(texturePainter.PaintedWallPerct * 100)).ToString() + " %";
    }

    void Update()
    {
        wallPaintSlider.value = texturePainter.PaintedWallPerct;
        wallPaintPerctText.text = ((int)(texturePainter.PaintedWallPerct * 100)).ToString() + " %";
    }

    private void ActivateInstructionTextWithDelay()
    {
        StartCoroutine(ActivateInstructionText());
    }

    private IEnumerator ActivateInstructionText()
    {
        Debug.Log("works");
        instructionText.SetActive(true);
        yield return new WaitForSeconds(2f);
        instructionText.SetActive(false);
    }
}
