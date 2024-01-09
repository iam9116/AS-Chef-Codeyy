using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public string triggerName = "";

    public GameObject breadPrefab;

    public GameObject heldItem;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (triggerName == "Bread")
            {
                heldItem = Instantiate(breadPrefab, transform, false);
                heldItem.transform.localPosition = new Vector3(0f, 2f, 1f);
            }

            if (triggerName == "Stove")
            {
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
