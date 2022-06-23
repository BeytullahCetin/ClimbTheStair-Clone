using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerStamina playerStamina;

    [SerializeField] ScoreBoard scoreBoard;

    [SerializeField] GameObject GameOverUI;

    float currentScore;
    float highScore;
    [SerializeField] float scoreToNextLevel;

    private void Start()
    {
        highScore = PlayerPrefs.GetFloat("HighScore", 0);
    }

    private void OnEnable()
    {
        PlayerMovement.OnPlayerMove += UpdateScore;
        PlayerStamina.OnStaminaRunOut += Die;
    }

    private void OnDisable()
    {
        PlayerMovement.OnPlayerMove -= UpdateScore;
        PlayerStamina.OnStaminaRunOut -= Die;
    }

    void UpdateScore(Transform playerTransform)
    {
        currentScore = playerTransform.position.y;
        scoreBoard.UpdateScore(currentScore);
    }

    void Die()
    {
        GameOverUI.SetActive(true);

        playerMovement.IsMoving = false;
        playerMovement.gameObject.SetActive(false);


        if (PlayerPrefs.GetFloat("HighScore", 0) < currentScore)
        {
            PlayerPrefs.SetFloat("HighScore", currentScore);
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void Continue()
    {
        playerStamina.ResetStamina();
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
