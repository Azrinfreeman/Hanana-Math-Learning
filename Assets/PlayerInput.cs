using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public TMP_InputField textName;

    // Start is called before the first frame update
    void Start()
    {
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("CurrentPlayer_")))
        {
            transform.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update() { }

    public void SetUsername()
    {
        DateTime theTime = DateTime.Now;
        string time = theTime.ToString("HHmmssyy");

        string fullname = textName.text;

        GetComponent<Animator>().Play("dismiss");
        GameStartupController.instance.SaveNewPlayerName(fullname, time);
        GameStartupController.instance.SetAsCurrentPlayer(fullname, time);

        PlayerPrefs.SetInt("FirstTime", 1);
        GameStartupController.instance.ApplyScoreAgain();

        PlayerPrefs.SetString("CurrentPlayer_", textName.text);
    }
}
