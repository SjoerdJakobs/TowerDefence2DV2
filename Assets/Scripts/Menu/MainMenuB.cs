using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuB : MonoBehaviour {


    private GameObject _playButton;
    private GameObject _howToPlayButton;
    private GameObject _creditsButton;

    private GameObject _gameText;
    private GameObject _creditsText;
    private GameObject _howToPlayText;


	void Start () {
        _playButton = GameObject.Find("Play");
        _gameText = GameObject.Find("LOGO");
        _howToPlayButton = GameObject.Find("HowToPlay");
        _creditsButton = GameObject.Find("Credits");


        _creditsText = GameObject.Find("CreditsObject");

        _playButton.GetComponent<Button>().onClick.AddListener(PlayButton);
        _howToPlayButton.GetComponent<Button>().onClick.AddListener(HowToPlayButton);
        _creditsButton.GetComponent<Button>().onClick.AddListener(CreditsButton);

        _creditsText.SetActive(false);
	}
	

    public void PlayButton()
    {
        Application.LoadLevel(1);
    }

    public void MenuButton()
    {
        Application.LoadLevel(0);
    }

    void CreditsButton()
    {
        _creditsText.SetActive(true);
        _gameText.SetActive(false);
    }

    void HowToPlayButton()
    {
        //
    }
}
