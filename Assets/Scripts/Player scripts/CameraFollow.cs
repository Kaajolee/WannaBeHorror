using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    public float smoothSpeed = 0.5f;
    public Vector3 offset;
    private void LateUpdate()
    {
        if(playerTransform == null)
        {
            //Debug.LogWarning("Camera target not set");
            return;
        }
        Vector3 desiredPosition = playerTransform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(playerTransform);

    }
}
