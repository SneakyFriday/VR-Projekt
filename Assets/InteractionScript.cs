using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionScript : MonoBehaviour
{
    [Header("Pickup Options")]
    [SerializeField] private float _pickupRange = 3;
    [SerializeField] private float _pickupDistance = 7.0f;
    [SerializeField] private float _pickupHeight = 1.29f;
    [SerializeField] private LayerMask _pickupLayer;

    [Header("View")] [SerializeField]
    private Camera _camera;
    
    private Transform _pivotPoint;
    private Transform _rotationTarget;
    private Transform _pickupPoint;
    private PlayerInput _input;
    private Vector2 _swivelInput;
    private float _rotation;
    private Rigidbody _object;

    // Start is called before the first frame update
    void Start()
    {
        GameObject pivot = GameObject.Find("RobotHeadPivot");
        _pivotPoint = pivot.GetComponent<Transform>();
        GameObject rotation = GameObject.Find("RotationTarget");
        _rotationTarget = rotation.GetComponent<Transform>();
        GameObject pickup = GameObject.Find("PickupPoint");
        _pickupPoint = pickup.GetComponent<Transform>();
        _input = gameObject.GetComponent<PlayerInput>();
    }

    // Called with Physics Engine
    void FixedUpdate()
    {
        // if something is picked up, moves it to pickupPoint
        if (_object)
        {
            Vector3 direction = _pickupPoint.position - _object.position;
                    float distance = direction.magnitude;
            
                    _object.velocity = direction * 12f * distance;
        }
        
    }

    // Calls Swivel Method depending on Control Scheme
    public void OnSwivel(InputAction.CallbackContext context)
    {
        Debug.Log(_input.currentControlScheme);
        switch (_input.currentControlScheme)
        {
            case "Gamepad":
                GamepadSwivel(context);
                break;
            case "Keyboard":
                KeyboardSwivel(context);
                break;
        }
    }
    
    private void GamepadSwivel(InputAction.CallbackContext context)
    {
        _swivelInput = context.ReadValue<Vector2>();
        
        /*
        // Get Camera Directions
        Vector3 forward = _camera.transform.forward;
        Vector3 right = _camera.transform.right;
        forward = forward.normalized;
        right = right.normalized;
        Vector3 mix = forward + right;
        Vector2 relative = new Vector2(mix.x, mix.y);

        // Make Input Relative to Camera
        Vector2 relativeInput = _swivelInput * relative;
        */

        _rotationTarget.localPosition = new Vector3(_swivelInput.x*_pickupDistance, _pickupHeight, _swivelInput.y*_pickupDistance);
        _pivotPoint.LookAt(_rotationTarget);
    }
    private void KeyboardSwivel(InputAction.CallbackContext context)
    {
        Debug.Log("KeyboardSwivel reached");
        _swivelInput = context.ReadValue<Vector2>();
        
        // Finding the World Coordinates of what is pointed at
        var cameraRay = _camera.ScreenPointToRay(_swivelInput);
        var groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        
        // return if no Ground found 
        if (!groundPlane.Raycast(cameraRay, out rayLength)) return;
        
        // Find Direction from Player to Point
        Vector3 point = cameraRay.GetPoint(rayLength);

        Vector3 direction = point - _pivotPoint.position;
        direction.Normalize();
        
        // Does the Rotation
        _rotationTarget.localPosition = new Vector3(direction.x*_pickupDistance, _pickupHeight, direction.y*_pickupDistance);

        transform.LookAt(new Vector3(point.x, transform.position.y, point.z));

    }
    
    // Calls Pickup or Drop Methods  
    public void OnUse(InputAction.CallbackContext context)
    {
        if (_object)
        {
            DropObject();
            return;
        }
        
        DetectObject();
        
    }

    // Drops the Object
    private void DropObject()
    {
        _object = null;
    }

    // Detects 1st Object in Sphere and assigns it as "Pickup"
    // (Physical Pickup in FixedUpdate Method)
    private void DetectObject()
    {
        Collider[] objects = Physics.OverlapSphere(_rotationTarget.position, _pickupRange, _pickupLayer);
        if (objects[0])
        {
            _object = objects[0].attachedRigidbody;
        }
        
    }
}
