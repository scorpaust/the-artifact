using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBackpack : MonoBehaviour
{

    [SerializeField]
    private Text backpackInfoTxt;

    public int maxNumberOfFruitsToStore = 50;

    public int currentNumberOfStoredFruits;

	private void Start()
	{
		SetBackpackInfoTxt(0);
	}

	public void AddFruits(int amount)
	{
        currentNumberOfStoredFruits += amount;

        if (currentNumberOfStoredFruits > maxNumberOfFruitsToStore)
		{
            currentNumberOfStoredFruits = maxNumberOfFruitsToStore;
		}

		SetBackpackInfoTxt(currentNumberOfStoredFruits);
	}

    public int TakeFruits()
	{
        int takenFruits = currentNumberOfStoredFruits;

        currentNumberOfStoredFruits = 0;

		SetBackpackInfoTxt(currentNumberOfStoredFruits);

        return takenFruits;
	}

    private void SetBackpackInfoTxt(int amount)
	{
        backpackInfoTxt.text = "Backpack: " + amount + "/" + maxNumberOfFruitsToStore;
	}
}
