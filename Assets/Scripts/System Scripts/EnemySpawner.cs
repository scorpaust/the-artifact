﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject wolfPrefab, wolfEaterPrefab;

    [SerializeField]
    private Transform[] spawnPoints;

    [SerializeField]
    private int eaterChance = 3;

    [SerializeField]
    private float spawnTime = 12f;

    [SerializeField]
    private float spawnReductionPerWolf = 1f;

    [SerializeField]
    private float minimalSpawnDelayPerWolf = 3.5f;

    private float currentSpawnTime;

    private float timer;

	private void Start()
	{
        currentSpawnTime = spawnTime;

        timer = Time.time;
	}

	private void Update()
	{
		if (Time.time > timer)
		{
            Spawn();

            currentSpawnTime -= spawnReductionPerWolf;

            if (currentSpawnTime <= minimalSpawnDelayPerWolf)
			{
                currentSpawnTime = minimalSpawnDelayPerWolf;
			}

            timer = Time.time + currentSpawnTime;
		}
	}

    private void Spawn()
	{
        if (Random.Range(0, 11) > eaterChance)
		{
            Instantiate(wolfPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
		}
        else
		{
            Instantiate(wolfEaterPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        }
	}
}
