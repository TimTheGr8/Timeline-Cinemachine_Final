using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera _followCam;
    [SerializeField]
    private CinemachineVirtualCamera _cockpitCam;
    
    private int _currentCam = 1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SwitchCameras();
        }
    }

    private void SwitchCameras()
    {
        if(_currentCam == 1)
        {
            _currentCam = 2;
            _followCam.Priority = 15;
            _cockpitCam.Priority = 10;
        }
        else if (_currentCam == 2)
        {
            _currentCam = 1;
            _followCam.Priority = 10;
            _cockpitCam.Priority = 15;
        }
        else
        {
            Debug.Log("The current cam index is out of range.");
        }
    }
}
