using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    bool isPickedUp;
    int itemsPickedUp;
    public GameObject pickUpText;
    public TextMeshProUGUI itemsPickedUpHUD;
    // Start is called before the first frame update
    void Start()
    {
        pickUpText.SetActive(false);
        isPickedUp = false;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           // if (Input.GetKey(KeyCode.E))
                {
                pickUpText.SetActive(true);
                isPickedUp = true;
                itemsPickedUpHUD.text = itemsPickedUp.ToString();
                
                }
        }

    }

    void OnTriggerExit(Collider other)
    {
        pickUpText.SetActive(false);
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

}
