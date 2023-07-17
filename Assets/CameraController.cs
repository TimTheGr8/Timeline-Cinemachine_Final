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
    [SerializeField]
    private GameObject _CinematicCameras;
    
    private int _currentCam = 1;
    public bool _cinematicSequencePlaying = false;
    public bool _countdownStarted = false;

    void Update()
    {
        if(Input.anyKeyDown == false || Input.GetAxis("Mouse X") == 0 || Input.GetAxis("Mouse Y") == 0 && !_countdownStarted)
        {
            _countdownStarted = true;
            StartCoroutine(DetectInput());
        }
        if(Input.anyKeyDown == true || Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0 && _countdownStarted)
        {
            _countdownStarted = false;
            _cinematicSequencePlaying = false;
            CinematicSequence(_cinematicSequencePlaying);
            StopAllCoroutines();
        }

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

    private void CinematicSequence(bool startSequence)
    {
        _CinematicCameras.SetActive(startSequence);
    }

    IEnumerator DetectInput()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("Switch Cameras");
        _cinematicSequencePlaying = true;
        CinematicSequence(_cinematicSequencePlaying);
    }
}
