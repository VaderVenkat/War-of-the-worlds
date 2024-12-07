using System;
using UnityEngine;
using TMPro; 

public class GameBehavior : MonoBehaviour
{
    private int _itemsCollected = 0;
    private int _playerHP = 10;

    public int MaxItems = 4;

    public TMP_Text HealthText;
    public TMP_Text ItemText;
    public TMP_Text ProgressText;

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
                ProgressText.text = "You've found all the items !";
            }
            else
            {

                ProgressText.text = "Items found , only " + (MaxItems - _itemscollected) +"more !";
            }
        }
    }

    
    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;

            HealthText.text = "Player Health: " + HP;
            Debug.LogFormat("Lives: {0}", _playerHP);
        }
    }
}
