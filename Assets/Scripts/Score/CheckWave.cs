using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CheckWave : MonoBehaviour
{
    //GameObject
    private GameObject _waveText;
    //GameObject

    //Float
    public float _waveValue;
    //Float

    //bool
    private bool _runOnce;
    //bool

    private GameObject _spawnerController;
    private UnitSpawner _unitSpawner;

    void Start()
    {
        _waveValue = 0;
        _waveText = GameObject.Find("ShowWave");

        _spawnerController = GameObject.Find("Spawner");
        _unitSpawner = _spawnerController.GetComponent<UnitSpawner>();
    }

    public void AddWave()
    {
        
        _waveValue += 1;
        _waveText.GetComponent<Text>().text = _waveValue + "/10";
    }

    void Update()
    {
        if (!_runOnce)
        {
            _runOnce = true;
            if (_waveValue == 5)
            {
                _unitSpawner.SpawnBoss();
            }
        }
       
    }
}
