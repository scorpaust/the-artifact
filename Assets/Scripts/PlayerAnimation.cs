﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    [SerializeField]
    private Sprite[] animSprites;

    public float timeThreshold = 0.1f;

    private float timer;

    private int state = 0;

    private SpriteRenderer sr;

	private void Awake()
	{
        sr = GetComponent<SpriteRenderer>();
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timer)
		{
            sr.sprite = animSprites[state % animSprites.Length];
            state++;
            timer = Time.time + timeThreshold;
		}
    }
}
