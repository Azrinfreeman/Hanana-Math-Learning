using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DetailBadge : MonoBehaviour
{
    public static DetailBadge instance;

    void Awake()
    {
        instance = this;
    }

    public Image image;
    public TextMeshProUGUI text;
    public TextMeshProUGUI text2;

    // Start is called before the first frame update
    void Start()
    {
        image = transform.GetChild(0).GetComponent<Image>();
        text = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        text2 = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update() { }

    public void SetDetail(Image image1, string nameTitle, string details)
    {
        image.sprite = image1.sprite;
        text.text = nameTitle;
        text2.text = details;
    }
}
