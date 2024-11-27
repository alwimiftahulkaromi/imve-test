using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
	public GameObject howToPlayPanel;

	public void StartGame()
	{
		SceneManager.LoadScene("EndlessSurvival");
	}

	public void QuitGame()
	{
		Debug.Log("Game Quit!");
		Application.Quit();
	}

	public void ShowHowToPlay()
	{
		howToPlayPanel.SetActive(true);
	}

	public void HideHowToPlay()
	{
		howToPlayPanel.SetActive(false);
	}
}
