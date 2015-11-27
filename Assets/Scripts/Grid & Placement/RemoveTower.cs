using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RemoveTower : MonoBehaviour {
    
    private GameObject _removeBuilding;
    [SerializeField]
    public bool canRemove;
    
    private PlacementMouse _placeScript;
    private GameObject _hover;
    private GameObject _scoreController;
    private CoinsController _checkCoins;


    void Start()
    {
        _hover = GameObject.Find("Hover");
        _placeScript = _hover.GetComponent<PlacementMouse>();
        _scoreController = GameObject.Find("ScoreController");
        _checkCoins = _scoreController.GetComponent<CoinsController>();

        _removeBuilding = GameObject.Find("RemoveButton");
        _removeBuilding.GetComponent<Button>().onClick.AddListener(removeBool);

    }
    void removeBool()
    {
        
        if (canRemove)
        {
            canRemove = false;
        }
        else
        {
            canRemove = true;
            _placeScript.spawnCannon = false;
            _placeScript.spawnTurret = false;
            _placeScript.spawnWall = false;
            _placeScript.spawnWizard = false;
        }
    }
    void OnMouseDown()
    {
        if (canRemove)
        {
            Destroy(gameObject);
            _checkCoins.AddCoins();
        }
    }
}
