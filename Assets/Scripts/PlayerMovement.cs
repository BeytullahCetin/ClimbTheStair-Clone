using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Animator anim;

    [SerializeField] float rotateSpeed = 1;
    [SerializeField] float jumpSpeed = .1f;

    bool touchInput = false;
    bool isMoving = false;



    void RotateCharacter()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }

    void MoveCharacter()
    {
        transform.position += Vector3.up * jumpSpeed * Time.deltaTime;
    }

    IEnumerator Move()
    {
        isMoving = true;
        while (touchInput)
        {
            RotateCharacter();
            MoveCharacter();
            yield return null;
        }
        isMoving = false;
    }

    public void GetTouchInput(InputAction.CallbackContext context)
    {
        if (true == context.performed)
        {
            touchInput = true;

            if (false == isMoving)
            {
                StartCoroutine(Move());
            }

        }
        else if (true == context.canceled)
        {
            touchInput = false;
        }

        Debug.Log(touchInput);
        anim.SetBool("isMoving", touchInput);

    }
}
