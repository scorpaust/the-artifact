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

    private GameObject artifact;

    private AudioSource audioSource;

    private Camera mainCamera;

    private Vector3 spawnPos;

    private void Awake()
	{
        audioSource = GetComponent<AudioSource>();

        mainCamera = Camera.main;

        artifact = GameObject.FindWithTag("Artifact");
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > timer)
		{
            Slash();

            timer = Time.time + cooldown;
		}
	}

    private void Slash()
	{

        if (!artifact)
            return;

        audioSource.Play();

        spawnPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        spawnPos.z = 0;

        Instantiate(slashPrefab, spawnPos, Quaternion.identity);
	}
}
