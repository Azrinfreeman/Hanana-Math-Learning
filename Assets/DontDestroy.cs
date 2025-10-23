using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public static DontDestroy instance;

    // Start is called before the first frame update
    void Start()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // ✅ keep it alive across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update() { }
}
