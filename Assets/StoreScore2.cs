using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreScore2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StoringScore1();
    }

    public void StoringScore1()
    {
        int tempScore = PlayerPrefs.GetInt("StarsCollected_0");
        PlayerPrefs.SetInt("StarsCollected_0", ScoreController.instance.scores + tempScore);
    }
}
