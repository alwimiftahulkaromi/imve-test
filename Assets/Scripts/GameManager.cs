using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	[Header("UI Elements")]
	public GameObject gameOverPanel;
	public Text survivalTimeText;
	public Text inGameTimerText;

	private float survivalTime;
	private bool isGameOver;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	private void Start()
	{
		if (gameOverPanel != null)
		{
			gameOverPanel.SetActive(false);
		}
		if (inGameTimerText != null)
		{
			inGameTimerText.gameObject.SetActive(true);
		}

		survivalTime = 0f;
		isGameOver = false;
	}

	private void Update()
	{
		if (!isGameOver)
		{
			survivalTime += Time.deltaTime;

			if (inGameTimerText != null)
			{
				inGameTimerText.text = $"Time: {survivalTime:F2} s";
			}
		}
	}

	public void GameOver()
	{
		isGameOver = true;

		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;

		inGameTimerText.gameObject.SetActive(false);

		if (gameOverPanel != null)
		{
			gameOverPanel.SetActive(true);
		}

		if (survivalTimeText != null)
		{
			survivalTimeText.text = $"Survival Time: {survivalTime:F2} seconds";
		}

		Time.timeScale = 0;
	}

	public void RestartGame()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void BackToMenu()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("MainMenu");
	}
}
