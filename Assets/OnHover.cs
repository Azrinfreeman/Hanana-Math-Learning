using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Transform image;

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }
}
