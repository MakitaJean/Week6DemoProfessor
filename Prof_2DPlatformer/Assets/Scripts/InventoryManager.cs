using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject lightningPrefab;
    public GameObject heartPrefab;
    public GameObject starPrefab;

    private void Start()
    {
        buildHeartIcon();
    }

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

    void buildIcon(GameObject prefab, string type)
    {
        Transform box = findEmptyBox();
        if (box == null)
        {
            print("No room in inventory");
            return;
        }
        GameObject g = Instantiate(prefab);
        g.GetComponent<Icon>().type = type;
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
