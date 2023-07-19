using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControls : MonoBehaviour
{
    [SerializeField] 
    private float _rotSpeed;
    [SerializeField] 
    private float _moveSpeed;
    [SerializeField] 
    private float _currentSpeed;
    [SerializeField]
    private float _maxSpeed = 10;
    private float _roll;
    private float _yaw;
    private float _pitch;
    [SerializeField] 
    private float _maxRotate;
    [SerializeField] 
    private Transform _startingLocation;

    [SerializeField]
    private Material _earth;
    [SerializeField]
    private Material _jupiter;
    [SerializeField]
    private Material _galaxy;

    // Start is called before the first frame update
    void Start()
    {
        _currentSpeed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        ShipMovement();
    }

    private void ShipMovement()
    {
        // Roll
        _roll = Input.GetAxis("Roll");
        // Yaw
        _yaw = Input.GetAxis("Yaw");
        // Pitch 
        _pitch = Input.GetAxis("Pitch");

        if (Input.GetKeyDown(KeyCode.T))
        {
            _currentSpeed++;
            if (_currentSpeed > _maxSpeed)
            {
                _currentSpeed = _maxSpeed;
            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            _currentSpeed--;
            if (_currentSpeed < 1)
            {
                _currentSpeed = 1;
            }
        }

        // Yaw rotate 
        Vector3 yawRotate = new Vector3(0, _yaw, 0);
        transform.Rotate(yawRotate * _rotSpeed * Time.deltaTime); 

        // Roll rotate
        Vector3 rollRotate = new Vector3(-_roll, 0, 0);
        transform.Rotate(rollRotate * _rotSpeed * Time.deltaTime);

        // Pitch rotation
        transform.Rotate(new Vector3(0, 0, -_pitch * 0.2f), Space.Self);

        transform.position += transform.right * _currentSpeed * Time.deltaTime;
    }

    public void ReturnToStartingPosition()
    {
        this.transform.position = _startingLocation.transform.position;
    }
}
