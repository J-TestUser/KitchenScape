using UnityEngine;
using UnityEngine.UI; //necesario para poder trabajar con elemento de UI
using System.Collections;

public class GameManager : MonoBehaviour
{
    public int coins = 0;
    public bool chocolate;
    public bool donut;
    public bool sweet;

    public Text coinsText;

    
    public void AddCoins()
    {
        coins++;
        //coinsText.text = "x"+ coins.ToString();
    }
}
