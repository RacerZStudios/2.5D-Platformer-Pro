using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private Text coinText; 

    public void UpdateCoinInfo(int coin)
    {
        coinText.text += "/ " + coin.ToString() + "/ "; 
    }
}
