using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Games2Controller : MonoBehaviour
{
    public int questionNum;
    public int jawapanNum;
    public Transform Questions;

    public Transform Jawapans;

    public Transform CongratsPanel;

    public void CorrectAnswer()
    {
        GameController.instance.AddScores(10);
        CheckAndNextQuestion();
    }

    public void WrongAnswer()
    {
        GameController.instance.MinusScore(10);
        CheckAndNextQuestion();
    }

    public void CheckAndNextQuestion()
    {
        StartCoroutine(Checking());
    }

    IEnumerator Checking()
    {
        //check if the jawapan for question is at the end or not
        GameObject.Find("EventSystem").GetComponent<EventSystem>().enabled = false;

        for (int i = 0; i < Jawapans.GetChild(questionNum).childCount; i++)
        {
            Debug.Log(Jawapans.GetChild(questionNum).GetChild(i).transform);
            if (Jawapans.GetChild(questionNum).GetChild(i).transform.gameObject.activeSelf)
            {
                if (i == Jawapans.GetChild(questionNum).childCount - 1)
                {
                    Debug.Log(Jawapans.GetChild(questionNum).transform + "huijung");

                    Questions.transform.GetChild(questionNum).transform.gameObject.SetActive(false);
                    Jawapans.transform.GetChild(questionNum).transform.gameObject.SetActive(false);
                    questionNum++;
                    jawapanNum = 0;
                    if (questionNum < Questions.transform.childCount)
                    {
                        Questions
                            .transform.GetChild(questionNum)
                            .transform.gameObject.SetActive(true);

                        Jawapans
                            .transform.GetChild(questionNum)
                            .transform.gameObject.SetActive(true);
                        yield return new WaitForSeconds(2f);
                        GameObject.Find("EventSystem").GetComponent<EventSystem>().enabled = true;
                        break;
                    }
                    else
                    {
                        CongratsPanel.transform.gameObject.SetActive(true);
                        yield return new WaitForSeconds(2f);
                        GameObject.Find("EventSystem").GetComponent<EventSystem>().enabled = true;
                        break;
                    }
                }
                else
                {
                    Debug.Log(i + " | " + Jawapans.GetChild(questionNum).childCount);
                    Debug.Log(
                        Jawapans.GetChild(questionNum).GetChild(i).transform + "next jawapan"
                    );

                    jawapanNum++;
                    Jawapans.GetChild(questionNum).GetChild(i + 1).gameObject.SetActive(true);
                    Jawapans.GetChild(questionNum).GetChild(i).gameObject.SetActive(false);
                    yield return new WaitForSeconds(2f);
                    GameObject.Find("EventSystem").GetComponent<EventSystem>().enabled = true;

                    break;
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        questionNum = 0;
        jawapanNum = 0;
        //CheckAndNextQuestion();
    }

    // Update is called once per frame
    void Update() { }
}
