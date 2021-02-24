using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Camera))]
public class CharacterCamera : MonoBehaviour
{
    public Transform targetTransform;
    public Vector3 offest;
    [Range(0, 20)]public float rate = 1;
    public bool orientToTarget = true;
    public bool clampYaw = true;
    public bool ifYaw = true;
    public bool ifPitch = true;

    float pitch = 30;
    float yaw = 0;
    float distance = 3;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    void LateUpdate()
    {
        Quaternion rotationBase = (orientToTarget) ? targetTransform.rotation : Quaternion.identity;
        Quaternion rotation = rotationBase *  Quaternion.AngleAxis(yaw, Vector3.up) * Quaternion.AngleAxis(pitch, Vector3.right);

        Vector3 targetPosition = targetTransform.position + (rotation * (Vector3.back * distance));

        Ray ray = new Ray(targetTransform.position, (targetPosition - targetTransform.position));
        if(Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            targetPosition = raycastHit.point;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, rate * Time.deltaTime);

        Vector3 direction = targetTransform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(direction);
    }

    public void OnPitch(InputAction.CallbackContext callbackContext)
    {
        if(ifPitch)
        {
            pitch += callbackContext.ReadValue<float>();
            pitch = Mathf.Clamp(pitch, 0, 40);
        }
    }

    public void OnYaw(InputAction.CallbackContext callbackContext)
    {
        if(ifYaw)
        {
            yaw += callbackContext.ReadValue<float>();
            if(clampYaw) yaw = Mathf.Clamp(yaw, -70, 70);
        }
    }

    public void OnDistance(InputAction.CallbackContext callbackContext)
    {
        distance += callbackContext.ReadValue<float>();
        distance = Mathf.Clamp(distance, 3, 12);
    }

    public void OnCenter(InputAction.CallbackContext callbackContext)
    {
        if(callbackContext.started)
        {
            pitch = 30;
            yaw = 0;
            distance = 3;
        }
    }
}
