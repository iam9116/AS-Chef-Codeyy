using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject toast;
    public GameObject friedEgg;

    [Header("Inventory")]
    public string cookedFood = "";
    public bool isCooking = false;

    [Header("Particles")]
    public ParticleSystem smoke;
    public ParticleSystem complete;
    // Start is called before the first frame update
    void Start()
    {
        toast.SetActive(false);
        friedEgg.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToastBread()
    {
        isCooking = true;
        smoke.Play();
        toast.SetActive(true);
        cookedFood = "toast";
        Invoke("CompleteCooking", 5f);
    }

    public void FryEgg()
    {
        isCooking = true;
        smoke.Play();
        friedEgg.SetActive(true);
        cookedFood = "friedEgg";
        Invoke("CompleteCooking", 5f);
    }

    public void CleanStove()
    {
        friedEgg.SetActive(false);
        toast.SetActive(false);
        cookedFood = "";
        complete.Stop();
    }

    private void CompleteCooking()
    {
        isCooking = false;
        smoke.Stop();
        complete.Play();
    }
}
