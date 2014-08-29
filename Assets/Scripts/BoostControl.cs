using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoostControl : MonoBehaviour {
	
	public static bool boostTime;
	public static bool canBoost;
	
	public Transform boostBoard;
	
	public Transform tapStart;
	public Transform startHud;
	
	public tk2dTextMesh totalCost;
	public tk2dTextMesh currentEggs;
	int totalCostAmount;
	int currentEggsAmount;
	
	public Transform [] select01;
	public Transform [] select02;
	
	public static bool isSelected01;
	public static bool isSelected02;
	
	public static bool canSelectBoost;
	
	public Transform [] cantSelect;
	
	public static bool boost1;
	public static bool boost2;
	public static bool boost3;
	public static bool boost4;
	
	
	int valueSelect01;
	int valueSelect02;
	
	public static bool boostWasSelected;
	
	public Transform boostButton;
	
	// Use this for initialization
	void Start () {
		
		boostTime = false;
		canBoost = true;
		canSelectBoost = true;
		
		valueSelect01 = 0;
		valueSelect02 = 0;
		
		boostBoard.gameObject.SetActive(false);
		
		boost1 = false;
		boost2 = false;
		boost3 = false;
		boost4 = false;
		
		isSelected01 = false;
		isSelected02 = false;
		
		boostWasSelected = false;
		
		totalCostAmount = 0;
		
		currentEggsAmount = PlayerPrefs.GetInt("currentEggs");
	
	}
	
	// Update is called once per frame
	void Update () {
		
		totalCost.text = totalCostAmount.ToString();
		totalCost.Commit();
		
		currentEggs.text = currentEggsAmount.ToString();
		currentEggs.Commit();
		
		if((!GameControl.startGame && canBoost) || PlayerPrefs.GetInt("boostGameOver") == 1)
		{
			if(PlayerPrefs.GetInt("boostGameOver") == 1)
			{
				boostTime = true;
			}
			
			PlayerPrefs.SetInt("boostGameOver", 0);
			
			if(boostTime)
			{
				tapStart.gameObject.SetActive(false);
				startHud.gameObject.SetActive(false);
				boostBoard.gameObject.SetActive(true);
			}
			else if(!boostWasSelected)
			{
				tapStart.gameObject.SetActive(true);
				startHud.gameObject.SetActive(true);
				boostBoard.gameObject.SetActive(false);
				
				for(int i = 0; i < 4; i++)
				{
					select01[i].gameObject.SetActive(false);
					select02[i].gameObject.SetActive(false);
					cantSelect[i].gameObject.SetActive(false);
				}
				
				boost1 = false;
				boost2 = false;
				boost3 = false;
				boost4 = false;
				
				valueSelect01 = 0;
				valueSelect02 = 0;
				isSelected01 = false;
				isSelected02 = false;
				
				totalCostAmount = 0;
			}
			
			if(isSelected01 && isSelected02)
			{
				canSelectBoost = false;
			}
			else
			{
				canSelectBoost = true;
			}
			
			if(boostWasSelected)
			{
				if(totalCostAmount == 0)
				{
					boostTime = false;
					boostWasSelected = false;
				}
				else if(currentEggsAmount >= totalCostAmount)
				{
					canBoost = false;
					boostWasSelected = false;
					boostTime = false;
					currentEggsAmount -= totalCostAmount;
					PlayerPrefs.SetInt("currentEggs", currentEggsAmount);
					
					boostButton.gameObject.SetActive(false);
					tapStart.gameObject.SetActive(true);
					startHud.gameObject.SetActive(true);
					boostBoard.gameObject.SetActive(false);
				}
				else
				{
					currentEggs.SendMessage("NotEnough", SendMessageOptions.DontRequireReceiver);
					boostWasSelected = false;
				}
			}
		}
	}
	
	void SelectBoost(int index)
	{
		if(!isSelected01)
		{
			isSelected01 = true;
			cantSelect[index - 1].gameObject.SetActive(true);
			select01[index - 1].gameObject.SetActive(true);
			valueSelect01 = index;
		}
		else if(!isSelected02)
		{
			isSelected02 = true;
			cantSelect[index - 1].gameObject.SetActive(true);
			select02[index - 1].gameObject.SetActive(true);
			valueSelect02 = index;
		}
		
		switch(index)
		{
		case 1:
			boost1 = true;
			totalCostAmount += 2;
			break;
		case 2:
			boost2 = true;
			totalCostAmount += 3;
			break;
		case 3:
			boost3 = true;
			totalCostAmount += 4;
			break;
		case 4:
			boost4 = true;
			totalCostAmount += 5;
			break;
		}
	}
	
	void UnSelectBoost(int index)
	{
		if(index == 1)
		{
			isSelected01 = false;
			cantSelect[valueSelect01 - 1].gameObject.SetActive(false);
			select01[valueSelect01 - 1].gameObject.SetActive(false);
			
			switch(valueSelect01)
			{
			case 1:
				boost1 = false;
				totalCostAmount -= 2;
				break;
			case 2:
				boost2 = false;
				totalCostAmount -= 3;
				break;
			case 3:
				boost3 = false;
				totalCostAmount -= 4;
				break;
			case 4:
				boost4 = false;
				totalCostAmount -= 5;
				break;
			}
			
			valueSelect01 = 0;
		}
		else if(index == 2)
		{
			isSelected02 = false;
			cantSelect[valueSelect02 - 1].gameObject.SetActive(false);
			select02[valueSelect02 - 1].gameObject.SetActive(false);
			
			switch(valueSelect02)
			{
			case 1:
				boost1 = false;
				totalCostAmount -= 2;
				break;
			case 2:
				boost2 = false;
				totalCostAmount -= 3;
				break;
			case 3:
				boost3 = false;
				totalCostAmount -= 4;
				break;
			case 4:
				boost4 = false;
				totalCostAmount -= 5;
				break;
			}
			
			valueSelect02 = 0;
		}
	}
}
