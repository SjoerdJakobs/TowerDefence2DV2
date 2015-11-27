using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlacementMouse : MonoBehaviour
{


    //Int
    [SerializeField]
    private int grid;
    //Int

    //Transforms
    [SerializeField]
    private Transform tower1;
    [SerializeField]
    private Transform turret;
    [SerializeField]
    private Transform _wizardTower;
    [SerializeField]
    private Transform _cannonTower;
    //Transforms

    //LayerMask
    [SerializeField]
    private LayerMask isTaken;
    //LayerMask

    //Vector2
    private Vector2 mousePosition;
    private Vector2 gridPos;
    //Vector2

    //Color32
    private Color32 _giveColor;
    //Color32

    //Bool
    public bool building;
    public bool removing;

    private bool isFree;

    public bool spawnWall = false;
    public bool spawnTurret = false;
    public bool spawnWizard = false;
    public bool spawnCannon = false;
    //Bool

    //GameObjects
    private GameObject _TurretPlacement;
    private GameObject _WallPlacement;
    private GameObject _StartBuilding;
    private GameObject _buildWallButton;
    private GameObject _buildTowerButton;
    private GameObject _buildWizardButton;
    private GameObject _buildCannonButton;
    private GameObject _dropDown;
    private GameObject _scoreController;
    private GameObject _messagesController;
    private GameObject _findSpawner;
    private GameObject _removeBuilding;

    private GameObject _timerText;

    private GameObject _wallCost;
    private GameObject _archerCost;
    private GameObject _wizardCost;
    private GameObject _cannonCost;
    //GameObjects

    //Scripts
    private CoinsController _checkCoins;
    private UnitSpawner _checkWaveRunning;
    private Messages _checkMessage;
    //Scripts

    void Awake()
    {
        _findSpawner = GameObject.Find("Spawner");
        _checkWaveRunning = _findSpawner.GetComponent<UnitSpawner>();
        _scoreController = GameObject.Find("ScoreController");
        _checkCoins = _scoreController.GetComponent<CoinsController>();
        _messagesController = GameObject.Find("MessageController");
        _checkMessage = _messagesController.GetComponent<Messages>();
    }


    void Start()
    {

        _removeBuilding = GameObject.Find("RemoveButton");
        _StartBuilding = GameObject.Find("BuildButton");
        _StartBuilding.GetComponent<Button>().onClick.AddListener(ChangeBuild);
        _buildWallButton = GameObject.Find("WallButton");
        _buildWallButton.GetComponent<Button>().onClick.AddListener(ChangeWall);
        _buildTowerButton = GameObject.Find("TowerButton");
        _buildTowerButton.GetComponent<Button>().onClick.AddListener(ChangeTower);
        _buildWizardButton = GameObject.Find("WizardButton");
        _buildWizardButton.GetComponent<Button>().onClick.AddListener(ChangeWizard);
        _buildCannonButton = GameObject.Find("CannonButton");
        _buildCannonButton.GetComponent<Button>().onClick.AddListener(ChangeCannon);

        _wallCost = GameObject.Find("WallCost");
        _archerCost = GameObject.Find("ArcherCost");
        _wizardCost = GameObject.Find("WizardCost");
        _cannonCost = GameObject.Find("CannonCost");

        _timerText = GameObject.Find("TimeText");

        _removeBuilding.SetActive(false);
        _buildWallButton.SetActive(false);
        _buildTowerButton.SetActive(false);
        _buildWizardButton.SetActive(false);
        _buildCannonButton.SetActive(false);

        _wallCost.SetActive(false);
        _archerCost.SetActive(false);
        _wizardCost.SetActive(false);
        _cannonCost.SetActive(false);
    }



    void Update()
    {
        CheckMouse();
        PlaceInput();
        HideButtons();
        GridUpdater();
    }

    void GridUpdater()
    {
        gridPos = new Vector2(Mathf.Round(mousePosition.x / grid) * grid, Mathf.Round(mousePosition.y / grid) * grid);
    }


    void ChangeTower()
    {
        if (spawnTurret)
        {
            spawnTurret = false;
        }
        else
        {
            spawnWizard = false;
            spawnTurret = true;
            spawnWall = false;
            spawnCannon = false;
        }

    }
    void ChangeWall()
    {
        if (spawnWall)
        {
            spawnWall = false;
        }
        else
        {
            spawnTurret = false;
            spawnWizard = false;
            spawnCannon = false;
            spawnWall = true;
        }
    }

    void ChangeWizard()
    {
        if (spawnWizard)
        {
            spawnWizard = false;
        }
        else
        {
            spawnWizard = true;
            spawnWall = false;
            spawnTurret = false;
            spawnCannon = false;
        }

    }

    void ChangeCannon()
    {
        if (spawnCannon)
        {
            spawnCannon = false;
        }
        else
        {
            spawnCannon = true;
            spawnWall = false;
            spawnTurret = false;
            spawnWizard = false;
        }

    }

    void ChangeBuild()
    {
        spawnTurret = false;
        spawnWall = false;
        spawnWizard = false;
        spawnCannon = false;

        if (building)
        {
            building = false;
        }
        else
            building = true;

        _removeBuilding.SetActive(true);
        _buildWallButton.SetActive(true);
        _buildTowerButton.SetActive(true);
        _buildWizardButton.SetActive(true);
        _buildCannonButton.SetActive(true);
        _wallCost.SetActive(true);
        _archerCost.SetActive(true);
        _wizardCost.SetActive(true);
        _cannonCost.SetActive(true);

    }
    void CheckMouse()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        if (_checkWaveRunning.waveRunning == false)
        {
            if (building)
            {
                transform.position = gridPos;

            }
        }
        else transform.position = new Vector2(-10000, 0);
    }

    void HideButtons()
    {
        if (_checkWaveRunning.waveRunning)
        {
            _removeBuilding.SetActive(false);
            _buildWallButton.SetActive(false);
            _buildTowerButton.SetActive(false);
            _buildWizardButton.SetActive(false);
            _buildCannonButton.SetActive(false);

            _wallCost.SetActive(false);
            _archerCost.SetActive(false);
            _wizardCost.SetActive(false);
            _cannonCost.SetActive(false);
        }
        else if (building)
        {
            _removeBuilding.SetActive(true);
            _buildWallButton.SetActive(true);
            _buildTowerButton.SetActive(true);
            _buildWizardButton.SetActive(true);
            _buildCannonButton.SetActive(true);

            _wallCost.SetActive(true);
            _archerCost.SetActive(true);
            _wizardCost.SetActive(true);
            _cannonCost.SetActive(true);

        }
    }

    void PlaceInput()
    {
        if (building)
        {
            isFree = !(Physics2D.OverlapCircle(gridPos, (grid / 2), isTaken));
            if (isFree)
            {
                _giveColor = new Color(0, 255, 0, 128);
                this.GetComponent<SpriteRenderer>().color = _giveColor;

                if (Input.GetButtonDown("Fire1"))
                {
                    Debug.Log(_checkCoins._coinsValue);
                    if (spawnWall && _checkCoins._coinsValue > 99)
                    {
                        Instantiate(tower1, gridPos, Quaternion.identity);
                        _checkCoins.RemoveCoinsWall();
                    }

                    else if (spawnTurret && _checkCoins._coinsValue >= 249)
                    {
                      
                        Instantiate(turret, gridPos, Quaternion.identity);
                        _checkCoins.RemoveCoinsArch();
                    }

                    else if (spawnWizard && _checkCoins._coinsValue >= 399)
                    {
                        Instantiate(_wizardTower, gridPos, Quaternion.identity);
                        _checkCoins.RemoveCoinsWiz();
                    }

                    else if (spawnCannon && _checkCoins._coinsValue >= 499)
                    {
                        Instantiate(_cannonTower, gridPos, Quaternion.identity);
                        _checkCoins.RemoveCoinsCan();
                    }

                    else if (_checkCoins._coinsValue <= 99)
                    {
                        _checkMessage.TemporaryMsg();
                    }

                }
            }
        }
    }
}