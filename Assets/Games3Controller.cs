using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Games3Controller : MonoBehaviour
{
    public static Games3Controller instance;

    void Awake()
    {
        instance = this;
    }

    public Transform Questions;
    public Transform Answers;
    public TextMeshProUGUI currentLevelText;
    public TextMeshProUGUI attemptText;

    public int level;
    public int attempt;

    public Transform CongratPanel;
    public Transform FailedPanel;
    public bool itemEnded;

    // Start is called before the first frame update
    void Start()
    {
        level = 1;
        attempt = 0;

        SetLevel();
    }

    public void addAttempt()
    {
        attempt++;
        SetLevel();

        if (attempt > 3)
        {
            FailedPanel.gameObject.SetActive(true);
        }
    }

    public void addLevel()
    {
        level++;
        if (level > Questions.childCount)
        {
            CongratPanel.gameObject.SetActive(true);
        }
    }

    public void SetLevel()
    {
        currentLevelText.text = "Level " + level.ToString();
        attemptText.text = attempt.ToString() + " / " + " 3";
    }

    // Call this when you want to check and activate the next child
    public void ActivateNext(Transform transform)
    {
        //deactive all
        for (int i = 0; i < Questions.childCount; i++)
        {
            Questions.GetChild(i).gameObject.SetActive(false);

            Answers.GetChild(i).gameObject.SetActive(false);
        }
        int max = Questions.childCount;
        if ((level - 1) < max)
        {
            Questions.GetChild(level - 1).gameObject.SetActive(true);
            Answers.GetChild(level - 1).gameObject.SetActive(true);
        }
    }

    public void CheckIfEnded()
    {
        //
        if (AreAllChildrenInactive(Questions.GetChild(level - 1).gameObject))
        {
            Debug.Log("level ended");
            itemEnded = true;
            addLevel();
        }
    }

    bool AreAllChildrenInactive(GameObject parent)
    {
        foreach (Transform child in parent.transform)
        {
            if (child.gameObject.activeInHierarchy) // still active in the scene
            {
                return false; // at least one is active
            }
        }
        return true; // all are inactive
    }

    // Update is called once per frame
    void Update() { }
}
