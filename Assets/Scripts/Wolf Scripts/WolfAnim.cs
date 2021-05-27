﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAnim : MonoBehaviour
{
    [SerializeField]
    private Sprite[] wolfAnimSprites;

	[SerializeField]
	private float animTimeThreshold = 0.15f;

	private SpriteRenderer sr;

	private WolfAI wolfAI;

    private int state = 0;

    private float animTimer;

	private void Awake()
	{
        sr = GetComponent<SpriteRenderer>();
		wolfAI = GetComponent<WolfAI>();
	}

	private void Update()
	{
		if (wolfAI.isMoving)
		{
			if (Time.time > animTimer)
			{
				sr.sprite = wolfAnimSprites[state % wolfAnimSprites.Length];

				state++;

				if (state == wolfAnimSprites.Length)
					state = 0;

				animTimer = Time.time + animTimeThreshold;
			}
		}
		else
		{
			sr.sprite = wolfAnimSprites[0];
		}
		sr.flipX = wolfAI.left;
	}
}

