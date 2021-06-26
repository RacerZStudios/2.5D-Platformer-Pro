using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 
using UnityEngine;

public class My_UI_Manager : MonoBehaviour
{
    [SerializeField]
    private Text coinText;
    [SerializeField]
    private Text livesText;

    public void UpdateCoinInfo(int coin)
    {
        coinText.text += "/ " + coin.ToString() + "/ "; 
    }

    public void UpdateLivesInfo(int lives)
    {
        livesText.text += "/ " + lives + "/ ";
    }
}