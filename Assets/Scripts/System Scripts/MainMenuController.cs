using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private Canvas howToPlay;

    public void PlayGame()
	{
        SceneManager.LoadScene("Gameplay");
	}

    public void HowToPlay()
	{
        howToPlay.enabled = true;
	}

    public void BackToMainMenu()
	{
        howToPlay.enabled = false;
	}
}
