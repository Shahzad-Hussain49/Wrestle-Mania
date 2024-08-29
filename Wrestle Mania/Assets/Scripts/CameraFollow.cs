using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 5f;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, rotationSpeed * horizontal );
    }
}
