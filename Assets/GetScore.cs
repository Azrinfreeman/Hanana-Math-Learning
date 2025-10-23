using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetScore : MonoBehaviour
{
    public TextMeshProUGUI textTotalScore;

    // Start is called before the first frame update
    void Start()
    {
        textTotalScore.text =
            (ScoreController.instance.score / 10)
            + " / "
            + (QuestionController.instance.questionLists.questionlist.Count * 5);
    }

    // Update is called once per frame
    void Update() { }
}
