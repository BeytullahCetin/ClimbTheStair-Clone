using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public static event Action OnStairCreate = delegate { };
    public static event Action<Transform> OnPlayerMove = delegate { };

    [SerializeField] Animator anim;

    [SerializeField] Transform stairSpawnTransform;
    [SerializeField] Transform stairsParent;
    [SerializeField] GameObject stair;

    [SerializeField] Transform woodSpawnTransform;
    [SerializeField] Transform woodsParent;
    [SerializeField] GameObject wood;

    [SerializeField] float moveSpeed = 1f;

    bool touchInput = false;
    bool isMoving = false;
    public bool IsMoving { get { return isMoving; } set { isMoving = value; } }

    float stairHeight;
    float positionHolder;

    private void Start()
    {
        stairHeight = stair.GetComponent<MeshRenderer>().bounds.size.y;
        positionHolder = stairHeight;

        moveSpeed = Mathf.Pow(1.1f, PlayerPrefs.GetFloat("SpeedUpgradeLevel", 1));
    }

    void Step()
    {
        RotateCharacter();
        MoveCharacter();
        CreateStair();

        OnPlayerMove(transform);

    }

    void RotateCharacter()
    {
        transform.Rotate(Vector3.up * moveSpeed * 15 * Time.deltaTime);
    }

    void MoveCharacter()
    {
        float movement = (moveSpeed / 10) * Time.deltaTime;
        positionHolder += movement;
        transform.position += Vector3.up * movement;
    }

    void CreateStair()
    {
        if (positionHolder >= stairHeight)
        {
            Instantiate(stair, stairSpawnTransform.position, stairSpawnTransform.rotation, stairsParent);
            positionHolder -= stairHeight;
            
            OnStairCreate();
            CreateWood();
        }
    }

    void CreateWood()
    {
        Instantiate(wood, woodSpawnTransform.position, woodSpawnTransform.rotation, woodsParent);
    }

    IEnumerator Move()
    {
        isMoving = true;
        while (touchInput)
        {
            Step();
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

        anim.SetBool("isMoving", touchInput);
    }
}
