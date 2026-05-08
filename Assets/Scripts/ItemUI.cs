using UnityEngine;
using System.Collections;

public class ItemUI : MonoBehaviour
{
    [SerializeField] GameObject _noChocolate;
    [SerializeField] GameObject _noCandy;
    [SerializeField] GameObject _noDonut;

    public void GetChoco()
    {
        _noChocolate.SetActive(false);
    }
    public void GetCandy()
    {
        _noCandy.SetActive(false);
    }
    public void GetDonut()
    {
        _noDonut.SetActive(false);
    }
}
