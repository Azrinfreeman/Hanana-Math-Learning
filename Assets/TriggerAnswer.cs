using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnswer : MonoBehaviour
{
    public string correctTriggerName;
    public RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == correctTriggerName)
        {
            //correct
            //collision.GetComponent<RectTransform>().anchoredPosition =
            //   rectTransform.anchoredPosition;
            StartCoroutine(correctAnswer(collision));
        }
        else if (collision.tag.Equals("Untagged"))
        {
            return;
        }
        else if (collision.tag != correctTriggerName)
        {
            Debug.Log("wrong");
            StartCoroutine(wrongAnswer(collision));
        }
    }

    IEnumerator correctAnswer(Collider2D collision)
    {
        ScoreController.instance.AddScores(10);
        collision.GetComponent<DragController>().enabled = false;

        yield return new WaitForSeconds(1.2f);
        collision.GetComponent<Transform>().gameObject.SetActive(false);
        GetComponent<Transform>().gameObject.SetActive(false);
        Games3Controller.instance.CheckIfEnded();
        if (Games3Controller.instance.itemEnded)
        {
            Games3Controller.instance.itemEnded = false;
            Games3Controller.instance.ActivateNext(Games3Controller.instance.Questions);
        }
        Games3Controller.instance.SetLevel();
    }

    IEnumerator wrongAnswer(Collider2D collision)
    {
        ScoreController.instance.MinusScore(10);
        collision.GetComponent<DragController>().enabled = false;

        yield return new WaitForSeconds(1.2f);
        collision.GetComponent<DragController>().enabled = true;
        collision.GetComponent<DragController>().rectTransform.anchoredPosition = collision
            .GetComponent<DragController>()
            .originalPosition;

        Games3Controller.instance.addAttempt();
    }

    // Update is called once per frame
    void Update() { }
}
