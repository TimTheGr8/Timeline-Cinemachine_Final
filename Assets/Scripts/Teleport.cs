using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    private Material _skybox;
    [SerializeField]
    private PlayableDirector _timeline;
    [SerializeField]
    private PlayableDirector _endingTimeline;
    [SerializeField]
    private bool _orangePortal = false;
    [SerializeField]
    private bool _purplePortal = false;
    [SerializeField]
    private bool _greenPortal = false;
    [SerializeField]
    private GameObject _orangePortalGO;
    [SerializeField]
    private GameObject _purplePortalGO;
    [SerializeField]
    private GameObject _greenPortalGO;
    [SerializeField]
    private ShipControls shipControls;
    [SerializeField]
    private GameManager _gm;

    private void Update()
    {
        transform.LookAt(Camera.main.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (_greenPortal)
                GreenPortal();
            if (_purplePortal)
                PurplePortal();
            if (_orangePortal)
                OrangePortal();

            RenderSettings.skybox = _skybox;
        }
    }

    private void GreenPortal()
    {
        _timeline.Play();
        _purplePortalGO.SetActive(true);
        _orangePortalGO.SetActive(false);
        _greenPortalGO.SetActive(false);
    }

    private void PurplePortal()
    {
        _timeline.Play();
        _purplePortalGO.SetActive(false);
        _orangePortalGO.SetActive(true);
        _greenPortalGO.SetActive(true);
        shipControls.ReturnToStartingPosition();
    }

    private void OrangePortal()
    {
        _timeline.Play();
        StartCoroutine(WaitForEnding());
    }

    IEnumerator WaitForEnding ()
    {
        yield return new WaitForSeconds(2.8f);
        _endingTimeline.Play();
    }
}
