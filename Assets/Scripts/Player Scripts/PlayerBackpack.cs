using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBackpack : MonoBehaviour
{

    public int maxNumberOfFruitsToStore = 50;

    public int currentNumberOfStoredFruits;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddFruits(int amount)
	{
        currentNumberOfStoredFruits += amount;

        if (currentNumberOfStoredFruits > maxNumberOfFruitsToStore)
		{
            currentNumberOfStoredFruits = maxNumberOfFruitsToStore;
		}
	}

    public int TakeFruits()
	{
        int takenFruits = currentNumberOfStoredFruits;

        currentNumberOfStoredFruits = 0;

        return takenFruits;
	}
}
