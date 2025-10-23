using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StoringScore1();
    }

    public void StoringScore1()
    {
        int tempScore = PlayerPrefs.GetInt("StarsCollected_0");
        PlayerPrefs.SetInt("StarsCollected_0", GameController.instance.scores + tempScore);
    }

    // Update is called once per frame
    void Update() { }
}
