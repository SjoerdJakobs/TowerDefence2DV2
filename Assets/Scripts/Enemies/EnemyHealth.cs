using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField]
    public float _Enemyhealth = 100f;
    [SerializeField]
    private GameObject _healthBar;

    [SerializeField]
    private GameObject _smokeFX;

    private float _EnemyHpScaler;
    private Color32 _changeColor;

    private GameObject _scoreController;
    private CoinsController _checkCoins;


    void Start()
    {
        _scoreController = GameObject.Find("ScoreController");
        _checkCoins = _scoreController.GetComponent<CoinsController>();

        _EnemyHpScaler = (_Enemyhealth / 2);
    }

    void Update()
    {
        DestroyEnemy();
        AdjustHealthBar();
        ChangeColor();

    }

    void DestroyEnemy()
    {
        if (_Enemyhealth <= 0)
        {
            Instantiate(_smokeFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    void ChangeColor()
    {
        if (_Enemyhealth <= 50)
        {
            _changeColor = new Color(128, 0, 0);
            _healthBar.GetComponent<SpriteRenderer>().color = _changeColor;
        }
        if (_Enemyhealth <= 25)
        {
            _changeColor = new Color(255, 0, 0);
            _healthBar.GetComponent<SpriteRenderer>().color = _changeColor;
        }
    }

    void AdjustHealthBar()
    {
        _healthBar.transform.localScale = new Vector3((_Enemyhealth / _EnemyHpScaler), 0.15f, 1f);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Bullet(Clone)")
        {
            _Enemyhealth -= 25;
            Destroy(other.gameObject);
            _checkCoins.AddCoinsArch();
        }

        else if(other.gameObject.name == "CannonBullet(Clone)")
        {
            _Enemyhealth -= 50;
            Destroy(other.gameObject);
            _checkCoins.AddCoinsCan();
        }

        else if (other.gameObject.name == "WizardBullet(Clone)")
        {
            _Enemyhealth -= 100;
            Destroy(other.gameObject);
            _checkCoins.AddCoinsWiz();
        }
    }
}
