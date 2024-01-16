using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public Stove stove;

    public string triggerName = "";

    public GameObject breadPrefab;
    public GameObject eggPrefab;

    public GameObject heldItem;
    public string heldItemName = "";
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log(triggerName);
            
            if (triggerName == "Bread")
            {
                PickUpItem(breadPrefab, "breadSlice");
            }
            if (triggerName == "Stove")
            {
                Debug.Log("I'm at the stove"); 
                
                if (heldItemName == "breadSlice")
                {
                    stove.ToastBread();
                    PlaceHeldItem();
                }
                else
                {
                    if (stove.cookedFood == "toast")
                    {
                        PickUpItem(breadPrefab, "toastSlice");
                        stove.CleanStove();
                    }
                }
            }
            if (triggerName == "Receivers")
            {
                PlaceHeldItem();
                GameObject.Find("Receivers/French Toast/toastSlice").SetActive(true);
            }

            if (triggerName == "Egg")
            {
                PickUpItem(eggPrefab, "egg");
            }
        }

        if (Input.GetKeyDown("space"))
        {
            if (triggerName == "Bread")
            {

            }

            if (triggerName == "Stove")
            {

            }

            if (triggerName == "Receivers")
            {
                if (heldItemName == "toastSlice")
                {
                    Destroy(heldItem);
                    heldItemName = "";
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        triggerName = other.name;
    }

    private void OnTriggerExit(Collider other)
    {
        triggerName = "";
    }

    private void PlaceHeldItem()
    {
        Destroy(heldItem);
        heldItemName = "";
    }

    private void PickUpItem(GameObject itemPrefab, string itemName)
    {
        heldItem = Instantiate(itemPrefab, transform, false);
        heldItem.transform.localPosition = new Vector3(0f, 2f, 1f);
        heldItemName = itemName;
    }
}
