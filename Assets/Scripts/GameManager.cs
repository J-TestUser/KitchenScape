using UnityEngine;
using UnityEngine.UI; //necesario para poder trabajar con elemento de UI
using System.Collections;

public class GameManager : MonoBehaviour
{
    public int coins = 0;
    public bool chocolate = false;
    public bool donut = false ;
    public bool sweet = false;

    public Text coinsText;

    
    public void AddCoins()
    {
        coins++;
        //coinsText.text = "x"+ coins.ToString();
    }

    public void AddChocolate()
    {
        chocolate = true;
    }

    public void AddDonut()
    {
        donut = true;
    }

    public void AddSweet()
    {
        sweet = true;
    }
}
