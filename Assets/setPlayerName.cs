using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class setPlayerName : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("playerName");
    }

    // Update is called once per frame
    void Update() { }
}
