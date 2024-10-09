using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Icon : MonoBehaviour, IDragHandler, 
    IBeginDragHandler, IEndDragHandler, IPointerClickHandler
{
    public PickUpController pickUpCon;

    Transform canvasTransform;
    Transform origParent;
    void Start()
    {
        canvasTransform = GameObject.Find("Canvas").transform;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        origParent = transform.parent;
        transform.SetParent(canvasTransform, true);
        GetComponent<Image>().raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<Image>().raycastTarget = true;
        if (transform.parent == canvasTransform)
        {
            //we failed to find new parent.
            transform.SetParent(origParent, false);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        pickUpCon.invClick(gameObject);
    }
}
