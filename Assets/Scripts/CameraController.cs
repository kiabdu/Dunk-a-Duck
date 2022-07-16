using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // [Range(-0.5f, 1f)]
    // public float bottom = 0f;
    void Start()
    {
        Camera.main.projectionMatrix = Matrix4x4.Ortho(0f, 10f, -0.5f, 5f, 0.3f, 1000f);
    }
}
