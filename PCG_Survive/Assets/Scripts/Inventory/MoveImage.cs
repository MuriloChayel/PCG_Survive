using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class MoveImage : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;

    private Vector2 tempRectPosition;
    private RectTransform rectTransform;

    private CanvasGroup canvasGroup;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>() ;
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        tempRectPosition = rectTransform.position;
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {

        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        //rectTransform.position = tempRectPosition; 
        transform.localPosition = Vector3.zero;
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;   
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        print("pressed");
    }
}
