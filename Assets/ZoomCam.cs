using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCam : MonoBehaviour
{
    public float distance = 115f;
    public float distanceMin = 55f;
    public float distanceMax = 150f;
    void Update()
    {
        distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 10, distanceMin, distanceMax);
       Vector3 newPosition = new(transform.localPosition.x, distance, transform.localPosition.z);
        transform.localPosition = newPosition;
    }
}