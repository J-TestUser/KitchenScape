using UnityEngine;
using UnityEngine.UI; //necesario para poder trabajar con elemento de UI
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] int coins = 0;
    [SerializeField] bool chocolate = false;
    [SerializeField] bool donut = false ;
    [SerializeField] bool sweet = false;

    public bool _victory = false;
    private AudioSource _audioSource;
    public Button winButton;

    [SerializeField] AudioClip _coinSound;
    [SerializeField] AudioClip _itemSound;
    [SerializeField] AudioClip _powerUpSound;

    public GameObject victoryCanvas;
    public SceneLoader _sceneLoader;
    [SerializeField] string _gameOverScene;

    void Awake()
    {
        _sceneLoader = GameObject.Find("SceneLoader").GetComponent<SceneLoader>();
        victoryCanvas = GameObject.Find("VictoryCanvas").GetComponent<GameObject>();
        _audioSource = GetComponent<AudioSource>();
    }

    public IEnumerator GameOver()
    {    
        yield return new WaitForSeconds(3);
        _sceneLoader.ChangeScene(_gameOverScene);
        
    }

    public IEnumerator Victory()
    {
        yield return new WaitForSeconds(3);
        if (_victory == false)
        {
            _victory = true;
            winButton.Select();
        }
        else
        {
            _victory = false;
        }
        victoryCanvas.SetActive(_victory); 
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
