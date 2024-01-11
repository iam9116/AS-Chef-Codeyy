using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public string triggerName = "";

    public GameObject breadPrefab;

    public GameObject heldItem;
    public string heldItemName = "";
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (triggerName == "Bread")
            {
                heldItem = Instantiate(breadPrefab, transform, false);
                heldItem.transform.localPosition = new Vector3(0f, 2f, 1f);
                heldItemName = "breadSlice";
            }

            if (triggerName == "Stove")
            {
                Debug.Log("I'm at the stove"); 
                
                if (heldItemName == "breadSlice")
                {
                    Debug.Log("Ready to toast");
                }
                else
                {
                    Debug.Log("Codey is empty handed!");
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        triggerName = other.name;
    }

    private void OnTriggerExit(Collider other)
    {
        triggerName = "";
    }
}
