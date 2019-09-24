using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovingComponentv2 : MonoBehaviour
{
    Rigidbody RigidBody;
    bool isMouseLocked;

    public float MovementSpeed = 10f;
    public float CameraSpeed = 100f;
    public float JumpSpeed = 2f;

    bool isGrounded; // Permet de savoir si l'objet est par terre
    // Start is called before the first frame update
    void Start()
    {
        RigidBody = GetComponent<Rigidbody>();
        LockMouse();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Rotate();
    }

    void Jump()
    {
        if (Input.GetButton("Jump") && isGrounded)
        {
            RigidBody.AddForce(Vector3.up * JumpSpeed, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void Move()
    {
        transform.Translate(Input.GetAxis("Horizontal") * MovementSpeed * Time.deltaTime, 0, Input.GetAxis("Vertical") * MovementSpeed * Time.deltaTime);

    }

    private void Rotate() {
        if (isMouseLocked)
            transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * CameraSpeed, 0);
    }

    private void LockMouse() {
        Cursor.lockState = CursorLockMode.Locked;
        isMouseLocked = true;
    }

    private void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        isMouseLocked = false;
    }


    #region EVENTS
    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    private void OnApplicationFocus(bool focus)
    {
        if (isMouseLocked)
            LockMouse();
    }

    #endregion
}
