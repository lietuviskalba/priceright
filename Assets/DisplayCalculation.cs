﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCalculation : MonoBehaviour {

    public Text txtPrice;
    public Text txtUserPayment;
    public Text txtResult;

    public Button btnSum;
    public Button btnNext;

    private float price;//price
    private float minPrice;
    private float maxPrice;
    private float userPays;//user
    private int minUser;
    private int maxUser;
    private float result;

	void Start () {
        txtResult.gameObject.SetActive(false);
        btnNext.gameObject.SetActive(false);

        MinMaxSetup(0.99f, 23.99f, 2, 25);
        GenerateRandomValues(minPrice, maxPrice, minUser, maxUser);
        DisplayValues(price, userPays, CalculatePrice(price, userPays));

        Debug.Log(price + " - " + userPays + "Answer: " + CalculatePrice(price, userPays));
	}

    float CalculatePrice(float price, float userPays)
    {
        result = price - userPays;
        return result;
    }

    void GenerateRandomValues(float minPrice, float maxPrice, int minUser, int maxUser)
    {
        price = Random.Range(minPrice, maxPrice); // the random price
        price = Mathf.Round(price * 100f) / 100f; // round up decimal
        userPays = Random.Range(minUser, maxUser);// the random user pays
        while (true)
        {
            if (userPays >= price) //escape loop once user payment is bigger then the price
            {
                minUser = 2;
                break;
            }
            Debug.Log("User pay was: " + userPays);
            minUser += minUser; // incrament min user to make less looping
            userPays = Random.Range(minUser, maxUser); // generate new value
        }
    }

    void DisplayValues(float price, float userPayment, float result)
    {
        txtPrice.text = "Price: \n" + price.ToString();
        txtUserPayment.text = "Payment: \n" + userPayment.ToString();
        txtResult.text = string.Format("Result: \n {0:#0.00}", result);
    }

    void MinMaxSetup(float minP, float maxP, int minU, int maxU)
    {
        minPrice = minP;
        maxPrice = maxP;
        minUser = minU;
        maxUser = maxU;
    }

    public void ShowResult()
    {
        txtResult.gameObject.SetActive(true);
        btnSum.gameObject.SetActive(false);
        btnNext.gameObject.SetActive(true);  
    }

    public void NextGame()
    {
        txtResult.gameObject.SetActive(false);
        btnSum.gameObject.SetActive(true);
        btnNext.gameObject.SetActive(false);

        GenerateRandomValues(minPrice, maxPrice, minUser, maxUser);
        DisplayValues(price, userPays, CalculatePrice(price, userPays));
    }
}
