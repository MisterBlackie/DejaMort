using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CharacterCameraComponent : MonoBehaviour
{
    public float CameraSpeed = 100f;

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(Input.GetAxis("Mouse Y") * Time.deltaTime * CameraSpeed, 0, 0);
    }
}
