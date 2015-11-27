using UnityEngine;
using System.Collections;

public class Messages : MonoBehaviour {


    private GameObject _buildMessages;
    private GameObject _resourcesMessage;

	void Start () 
    {
        _resourcesMessage = GameObject.Find("NotEnough");
        _buildMessages = GameObject.Find("BuildMessage");

        _resourcesMessage.SetActive(false);

        StartCoroutine("RemoveMessage");
	}

    public void TemporaryMsg()
    {
        StartCoroutine("TemporaryMessage");
    }
	
	
	void Update () 
    {
	//
	}

    IEnumerator RemoveMessage()
    {
        yield return new WaitForSeconds(2);
        _buildMessages.SetActive(false);
    }

    IEnumerator TemporaryMessage()
    {
        _resourcesMessage.SetActive(true);
        yield return new WaitForSeconds(2);
        _resourcesMessage.SetActive(false);
    }



}
