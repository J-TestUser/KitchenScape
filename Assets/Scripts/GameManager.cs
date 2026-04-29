using UnityEngine;
using UnityEngine.UI; //necesario para poder trabajar con elemento de UI
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] int coins = 0;
    [SerializeField] bool chocolate = false;
    [SerializeField] bool donut = false ;
    [SerializeField] bool sweet = false;

    private AudioSource _audioSource;

    [SerializeField] AudioClip _coinSound;
    [SerializeField] AudioClip _itemSound;
    [SerializeField] AudioClip _powerUpSound;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    
    public void AddCoins()
    {
        coins++;
        _audioSource.PlayOneShot(_coinSound);
        //coinsText.text = "x"+ coins.ToString();
    }

    public void AddChocolate()
    {
        chocolate = true;
        _audioSource.PlayOneShot(_itemSound);
    }

    public void AddDonut()
    {
        donut = true;
        _audioSource.PlayOneShot(_itemSound);
    }

    public void AddSweet()
    {
        sweet = true;
        _audioSource.PlayOneShot(_itemSound);
    }
}
