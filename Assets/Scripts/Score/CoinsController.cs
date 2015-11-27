using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoinsController : MonoBehaviour
{

    private GameObject _coinsText;
    public float _coinsValue;

    void Awake()
    {
        _coinsText = GameObject.Find("CoinsValue");

    }

    void Start()
    {

        _coinsValue = 1000f;
        _coinsText.GetComponent<Text>().text = " " + _coinsValue;

    }

    void CheckCoins()
    {
        _coinsText.GetComponent<Text>().text = " " + _coinsValue;
    }

    public void RemoveCoinsWiz()
    {

        _coinsValue -= 400f;
        CheckCoins();
    }
    public void RemoveCoinsWall()
    {

        _coinsValue -= 100;
        CheckCoins();
    }
    public void RemoveCoinsArch()
    {

        _coinsValue -= 250f;
        CheckCoins();
    }
    public void RemoveCoinsCan()
    {

        _coinsValue -= 500f;
        CheckCoins();
    }


    public void AddCoinsWiz()
    {
        _coinsValue += 50f;
        CheckCoins();
    }
   
    public void AddCoinsArch()
    {
        _coinsValue += 25f;
        CheckCoins();
    }
    public void AddCoinsCan()
    {
        _coinsValue += 100f;
        CheckCoins();
    }

    public void AddCoins()
    {
        _coinsValue += 150f;
        CheckCoins();
    }

}