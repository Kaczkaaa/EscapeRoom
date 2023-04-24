using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PutOffItem : MonoBehaviour
{
    public PickUpItem itemsPickedUp;
    private int itemToPutOff;
    public GameObject putOffText;

    public GameObject putOffItem;

    private bool isInTrigger;

    public TextMeshProUGUI itemsPickedUpHUD;
    // Start is called before the first frame update
    void Start()
    {
        putOffText.SetActive(false);
        isInTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnPutOffItems(InputAction.CallbackContext context)
    {
        if (isInTrigger == true && itemToPutOff > 0)
        {
            Debug.Log(4);
            PutOff();
        }
    }
    
    void PutOff()
    {
        itemToPutOff -= 1;
        putOffText.SetActive(false);
        putOffItem.GetComponent<BoxCollider>().enabled = false;
        putOffItem.GetComponent<MeshRenderer>().enabled = true;
        itemsPickedUpHUD.text = itemToPutOff.ToString();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "PutOff")
        {
            isInTrigger = true;
            putOffText.SetActive(true);
            itemToPutOff = itemsPickedUp.itemsPickUpsInt;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        putOffText.SetActive(false);
    }
}
