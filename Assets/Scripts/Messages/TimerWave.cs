using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerWave : MonoBehaviour {

    private GameObject _timerText;
    private GameObject[] _enemies;

    private float _timer;

    private GameObject _waveController;
    private UnitSpawner _waveStarter;


	void Start () 
    {
        _waveController = GameObject.Find("Spawner");
        _waveStarter = _waveController.GetComponent<UnitSpawner>();
        _timer = 30f;
        _timerText = GameObject.Find("TimeText");
        _enemies = GameObject.FindGameObjectsWithTag("Enemy");
	}
	
	void Update () 
    {
        if (_timerText.activeSelf)
        {
            Timer();
            _timerText.GetComponent<Text>().text = "Time until next wave: 00:" + _timer.ToString("f0");
        }
        else
            _timer = 30f;


        if (_waveStarter.waveRunning)
        {
            _timerText.SetActive(false);
        }

        foreach (GameObject enemy in _enemies)
        {
            if (enemy == null)
            {
                TurnOn();
            }
        }
       
	}

    void Timer()
    {
       _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            _timerText.SetActive(false);
            _waveStarter.InvokeEnemies();
        }
    }

    public void TurnOn()
    {
        _timerText.SetActive(true);
    }
}
