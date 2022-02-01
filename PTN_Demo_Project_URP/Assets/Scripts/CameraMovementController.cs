using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class CameraMovementController : MonoBehaviour
{
    private Vector3 endSceneCamOffset = new Vector3(0.7f, 10f, 15f);

    private CinemachineVirtualCamera virtualCamera;

    private void OnEnable()
    {
        EventManager.OnRaceFinish.AddListener(moveCameraToEndScenePosition);
    }

    private void OnDisable()
    {
        EventManager.OnRaceFinish.RemoveListener(moveCameraToEndScenePosition);
    }

    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    private void moveCameraToEndScenePosition()
    {
        DOTween.To( () => virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset, x => virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = x, endSceneCamOffset, 3f);
    }
}
