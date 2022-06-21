using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float t = 0.5f;


    private void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, playerTransform.position.y, t), transform.position.z);
    }
}
