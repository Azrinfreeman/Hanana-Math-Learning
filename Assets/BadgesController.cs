using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadgesController : MonoBehaviour
{
    public static BadgesController instance;

    void Awake()
    {
        instance = this;
    }

    public List<Transform> badges;
    public List<Transform> locks;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Trophy_0", 1);
        AssignBadge();
    }

    // Update is called once per frame
    void Update() { }

    public void AssignBadge()
    {
        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            badges.Add(transform.GetChild(0).transform.GetChild(i));
            locks.Add(transform.GetChild(0).GetChild(i).transform.GetChild(0));

            if (PlayerPrefs.GetInt("Trophy_" + i) == 1)
            {
                locks[i].gameObject.SetActive(false);
            }
        }
    }
}
