using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    // public GameObject lightningPrefab;
    // public GameObject heartPrefab;
    // public GameObject starPrefab;
    public GameObject invIconPrefab;
    
    private void Start()
    {
        // buildHeartIcon();
    }

    /*
    public void buildLightningIcon()
    {
        buildIcon(lightningPrefab, "Lightning");
    }

    public void buildHeartIcon()
    {
        buildIcon(heartPrefab, "Heart");
    }

    public void buildStarIcon()
    {
        buildIcon(starPrefab, "Star");
    }
    */

    //void buildIcon(GameObject prefab, string type)
    public void buildIcon(GameObject pickedUp)
    {
        Transform box = findEmptyBox();
        if (box == null)
        {
            print("No room in inventory");
            return;
        }

        //GameObject g = Instantiate(prefab);
        GameObject g = Instantiate(invIconPrefab);
        //g.GetComponent<Icon>().type = type;
        g.GetComponent<Image>().sprite = pickedUp.GetComponent<SpriteRenderer>().sprite;
        g.transform.SetParent(box, false);
    }

    Transform findEmptyBox()
    {
        foreach (InvBox b in GetComponentsInChildren<InvBox>())
        {
            if (b.transform.childCount == 0)
                return b.transform;
        }
        return null;
    }

}
