using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public string LevelToLoad;
	public GameObject MainMenuContainer;
	public GameObject CreditsMenuContainer;

	public void goToGame()
	{
		Application.LoadLevel(LevelToLoad);
	}

	public void goToCredits()
	{
		CreditsMenuContainer.SetActive(true);
		MainMenuContainer.SetActive(false);
	}

	public void goToMainMenu()
	{
		MainMenuContainer.SetActive(true);
		CreditsMenuContainer.SetActive(false);
	}
}
