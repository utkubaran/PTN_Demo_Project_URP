using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class CameraMovementController : MonoBehaviour
{
    private Vector3 endSceneCamOffset = new Vector3(0f, 5f, 15f);

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
        virtualCamera.LookAt = null;
        transform.DORotate(Vector3.zero, 3f, RotateMode.Fast);
        // virtualCamera.transform.rotation = Quaternion.Euler(Vector3.zero);
        DOTween.To( () => virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset, x => virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = x, endSceneCamOffset, 3f);
    }
}
