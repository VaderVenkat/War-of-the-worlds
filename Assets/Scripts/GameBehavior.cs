using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    private int _itemsCollected = 0;
    private int _playerHP = 10;

    public int MaxItems = 4;

    public TMP_Text HealthText;
    public TMP_Text ItemText;
    public TMP_Text ProgressText;

    public Button WinButton;

    public Button LossButton;

    public void UpdateScene(string updatedText)
    {
        ProgressText.text = updatedText;
        Time.timeScale = 0f;
    }

   
    private void Start()
    {
        ItemText.text += _itemsCollected;
        HealthText.text += _playerHP;
    }

    private int _itemscollected = 0;
    public int Items
    {
        get { return _itemsCollected; }
        set
        {
            _itemsCollected = value;
           ItemText.text = " Items Collected : " + Items;

            if (_itemsCollected >= MaxItems)
            {
                

                WinButton.gameObject.SetActive(true);
                UpdateScene("You're found all the items!");
               
            }
            else
            {

                ProgressText.text = "Items found , only " + (MaxItems - _itemscollected) +"more to go !";
            }
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    
    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;

            HealthText.text = "Health: " + HP;

            if(_playerHP <= 0)
            {
                UpdateScene("you want another life with that? ");

                LossButton.gameObject.SetActive(true);
             
            }
            else
            {
                ProgressText.text = "Ouch.... thats's got hurt";
            }
            Debug.LogFormat("Lives:{0}", _playerHP);
        }
    }
}
