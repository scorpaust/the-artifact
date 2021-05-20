﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movementSpeed = 3.0f;

    private Rigidbody2D myBody;

    private Vector2 moveVector;

    private SpriteRenderer sr;

    private float harvestTimer;

    private bool isHarvesting;

    private GameObject artifact;

    private string MOVEMENT_AXIS_X = "Horizontal";

    private string MOVEMENT_AXIS_Y = "Vertical";

    private void Awake()
	{
        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

	void FixedUpdate()
	{
        MovePlayer();
    }

	// Update is called once per frame
	void Update()
    {
        FlipSprite();   
    }

    private void FlipSprite()
	{
        if (Input.GetAxisRaw(MOVEMENT_AXIS_X) == 1)
		{
            sr.flipX = false;
		} 
        else if (Input.GetAxisRaw(MOVEMENT_AXIS_X) == -1)
		{
            sr.flipX = true;
		}
	}

    private void MovePlayer()
	{
        if (isHarvesting)
        {
            myBody.velocity = Vector2.zero;
        }
        else
        {
            moveVector = new Vector2(Input.GetAxis(MOVEMENT_AXIS_X), Input.GetAxis(MOVEMENT_AXIS_Y));

            if (moveVector.sqrMagnitude > 1)
            {
                moveVector = moveVector.normalized;
            }

            myBody.velocity = new Vector2(moveVector.x * movementSpeed, moveVector.y * movementSpeed);
        }
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Bush"))
		{
            Debug.Log("The value of fruits is: " + collision.gameObject.GetComponent<BushFruits>().HarvestFruit());
		}
	}
}
