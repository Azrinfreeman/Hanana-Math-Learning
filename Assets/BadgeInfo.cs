using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BadgeInfo : MonoBehaviour
{
    public Image imageBadge;
    public string BadgeName;
    public bool isLock;

    public string detailBadge;

    // Start is called before the first frame update
    void Start()
    {
        imageBadge = transform.GetComponent<Image>();
        transform.GetComponent<Button>().onClick.AddListener(OnClickBadge);
    }

    // Update is called once per frame
    void Update() { }

    public void OnClickBadge()
    {
        if (!BadgesController.instance.locks[transform.GetSiblingIndex()].gameObject.activeSelf)
        {
            DetailBadge.instance.SetDetail(imageBadge, BadgeName, detailBadge);
        }
    }
}
