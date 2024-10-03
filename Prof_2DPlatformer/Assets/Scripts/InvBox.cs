using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InvBox : MonoBehaviour, IDropHandler
{
    void Start()
    {

    }

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            Transform droppedT = eventData.pointerDrag.transform;
            droppedT.SetParent(transform, false);
            return;
        }
        // no crafting
        /*
        Icon currentIcon = transform.GetChild(0).GetComponent<Icon>();
        Icon droppedIcon = eventData.pointerDrag.GetComponent<Icon>();

        if (currentIcon.type == "Heart" && droppedIcon.type == "Lightning")
        {
            Destroy(currentIcon.gameObject);
            Destroy(droppedIcon.gameObject);
            GetComponentInParent<InventoryManager>().buildStarIcon();
        }
        */
    }
}
