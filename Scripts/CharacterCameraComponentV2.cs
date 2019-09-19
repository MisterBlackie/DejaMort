using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CharacterCameraComponent : MonoBehaviour
{
    public float CameraSpeed = 2f;
    private float maxAngle = 60f;
    private float angle;
    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        angle += -Input.GetAxis("Mouse Y") * Time.deltaTime * CameraSpeed;
        angle = Mathf.Clamp(angle, -maxAngle, maxAngle);
        transform.Rotate(-Input.GetAxis("Mouse Y") * Time.deltaTime * CameraSpeed, 0, 0);
        /*transform.eulerAngles.y = Mathf.Clamp(transform.eulerAngles.z, -maxAngle, maxAngle);*/
    }
}
