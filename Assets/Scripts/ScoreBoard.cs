using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Transform playerTransform;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, playerTransform.position.y + 0.16f, transform.position.z);
    }

    public void UpdateScore(float score)
    {
        scoreText.SetText(score.ToString("f1") + "m");
    }
}
