using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class TimeManager : MonoBehaviour
{

    [SerializeField]
    private Text timerText;

    public float timeToWin = 300;

    private bool gameOver;

    private GameObject artifact;

    private StringBuilder stringBuilder;

	private void Awake()
	{
        artifact = GameObject.FindGameObjectWithTag("Artifact");

        stringBuilder = new StringBuilder();
	}

	// Update is called once per frame
	void Update()
    {
        if (gameOver || !artifact)
            return;

        timeToWin -= Time.deltaTime;

        if (timeToWin <= 0)
		{
            timeToWin = 0f;
            
            gameOver = true;

            Destroy(artifact);
		}

        DisplayTime((int)timeToWin);
    }

    private void DisplayTime(int time)
	{
        stringBuilder.Length = 0;

        stringBuilder.Append("Time Remaining: ");
        stringBuilder.Append(time);

        timerText.text = stringBuilder.ToString();
	}
}
