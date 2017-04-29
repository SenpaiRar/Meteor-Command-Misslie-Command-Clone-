using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CityManager : MonoBehaviour {
    public delegate void OnAllCityDestructin(); 
    public static event OnAllCityDestructin GameOverEvent;
    City[] Cities;
    int TotalAmountOfCities;

    void Awake () {

        Cities = FindObjectsOfType<City>(); //Find the gameobjects in the scene with tag "City"
        TotalAmountOfCities = Cities.Length; //Set the amount of cities to Cities[].Length

        foreach (var item in Cities) //Go through the list, subscribe to all the events in there
        {
            item.DeathEvent += SubtractTotalCityAmount;
        }
    }
	
	void Update () {
        Debug.Log("There are " + TotalAmountOfCities + "amount of cities!");
	}

    void SubtractTotalCityAmount() //Subtracts the amount of cities by one when a city is destroyed
    {
        TotalAmountOfCities -= 1;

        if(TotalAmountOfCities <= 0) //call this inside here instead of in Update() which improves performance
        {
            if(GameOverEvent != null)
            {
                GameOverEvent();
            }
        }
    }
    
}
