using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlash : MonoBehaviour
{
    [SerializeField]
    private GameObject slashPrefab;

    [SerializeField]
    private float cooldown = 0.3f;

    private float timer;

    private AudioSource audioSource;

    private Camera mainCamera;

    private Vector3 spawnPos;

    private void Awake()
	{
        audioSource = GetComponent<AudioSource>();

        mainCamera = Camera.main;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > timer)
		{
            Slash();

            audioSource.Play();

            timer = Time.time + cooldown;
		}
	}

    private void Slash()
	{
        spawnPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        spawnPos.z = 0;

        Instantiate(slashPrefab, spawnPos, Quaternion.identity);
	}
}
