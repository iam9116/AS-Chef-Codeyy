using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public Stove stove;

    public string triggerName = "";

    public GameObject breadPrefab;
    public GameObject eggPrefab;
    public GameObject friedEggPrefab;

    public GameObject heldItem;
    public string heldItemName = "";
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log(heldItemName);
            
            if (triggerName == "Bread")
            {
                PickUpItem(breadPrefab, "breadSlice");
            }

            if (triggerName == "Sources")
            {
                PickUpItem(eggPrefab, "egg");
            }

            if (triggerName == "Stove")
            {
                Debug.Log("I'm at the stove");

                if (heldItemName == "breadSlice")
                {
                    stove.ToastBread();
                    PlaceHeldItem();
                }
                else if (heldItemName == "egg")
                {
                    stove.FryEgg();
                    PlaceHeldItem();
                }

                else
                {
                    if (stove.cookedFood == "toast" && stove.isCooking == false)
                    {
                        PickUpItem(breadPrefab, "toastSlice");
                        stove.CleanStove();
                    }
                    if (stove.cookedFood == "friedEgg" && stove.isCooking == false)
                    {
                        PickUpItem(friedEggPrefab, "friedEgg");
                        stove.CleanStove();
                    }
                }
            }

            if (triggerName == "Receivers")
            {
               if (heldItemName == "toastSlice")
               {
                    PlaceHeldItem();
                    GameObject.Find("Receivers/French Toast/toastSlice").SetActive(true);
               }
               if (heldItemName == "friedEgg")
               {
                    PlaceHeldItem();
                    GameObject.Find("Receivers/French Toast/friedEgg").SetActive(true);
               }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        triggerName = other.name;
        Debug.Log(triggerName);
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
