using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public Stove stove;

    public string triggerName = "";

    public GameObject breadPrefab;

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
                heldItem = Instantiate(breadPrefab, transform, false);
                heldItem.transform.localPosition = new Vector3(0f, 2f, 1f);
                heldItemName = "breadSlice";
                Debug.Log("I have bread");
            }

            if (triggerName == "Stove")
            {
                Debug.Log("I'm at the stove"); 
                
                if (heldItemName == "breadSlice")
                {
                    Debug.Log("Ready to toast");
                    Destroy(heldItem);
                    stove.ToastBread();
                    heldItemName = "";
                }
                else
                {
                    if (stove.cookedFood == "toast")
                    {
                        heldItem = Instantiate(breadPrefab, transform, false);
                        heldItem.transform.localPosition = new Vector3(0, 2, 2);
                        heldItemName = "toastSlice";
                        stove.CleanStove();
                    }
                }
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
}
