using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public float sens;
    void Update()
    {
        float x = 0f;
        float y = 0f;
        x -= Input.GetAxis("Horizontal") * sens * Time.deltaTime;
        y += Input.GetAxis("Vertical") * sens * Time.deltaTime;
        transform.Rotate(y, 0f, x);
    }
}

