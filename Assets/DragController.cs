using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public RectTransform rectTransform;
    public Canvas canvas;
    public CanvasGroup canvasGroup;
    public Vector2 originalPosition;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        //canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        // Remember starting position
        originalPosition = rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Remember starting position
        originalPosition = rectTransform.anchoredPosition;

        // Make it semi-transparent while dragging
        canvasGroup.alpha = 0.7f;
        canvasGroup.blocksRaycasts = false; // allow raycasts to pass through
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Move with mouse
        /*  Vector2 pos;
          RectTransformUtility.ScreenPointToLocalPointInRectangle(
              canvas.transform as RectTransform,
              eventData.position,
              eventData.pressEventCamera,
              out pos
          );

          rectTransform.anchoredPosition = pos;
      */
        //Debug.Log("OnDrag");
        GetComponent<RectTransform>().anchoredPosition += eventData.delta / canvas.scaleFactor;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Reset transparency
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        GetComponent<BoxCollider2D>().enabled = true;
        // If you want it to snap back to original place:
        // rectTransform.anchoredPosition = originalPosition;
    }
}
