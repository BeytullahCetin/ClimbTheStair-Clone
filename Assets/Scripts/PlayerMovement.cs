using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 1;
    [SerializeField] float jumpSpeed = .1f;

    [SerializeField] float movementTimeout = 1;
    [SerializeField] float currentMovementTimeout = 0;

    private void Start()
    {

    }
    private void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            if (currentMovementTimeout >= movementTimeout)
            {
                RotateCharacter();
                MoveCharacter();
            }
        }

        if (currentMovementTimeout < movementTimeout)
        {
            currentMovementTimeout += Time.deltaTime;
        }
    }

    void RotateCharacter()
    {

        transform.Rotate(Vector3.up * rotateSpeed);
        currentMovementTimeout = 0;

    }

    void MoveCharacter()
    {
        transform.position += Vector3.up * jumpSpeed;
        currentMovementTimeout = 0;


    }

    public void adasdasd(InputAction.CallbackContext context)
    {
        bool fire = context.ReadValueAsButton();

        Debug.Log(fire);
        Debug.Log("Fire Input: " + context.phase);
    }
}
