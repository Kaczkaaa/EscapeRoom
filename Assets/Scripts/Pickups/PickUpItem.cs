using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PickUpItem : MonoBehaviour
{
    public static int itemsPickedUp;
    public int itemsPickUpsInt;
    public GameObject pickUpText;
    public GameObject pickUpItem;
    public TextMeshProUGUI itemsPickedUpHUD;
    [SerializeField] float maxDistance;
    bool isInRayCast;

    private bool isInTrigger;
    // Start is called before the first frame update
    void Start()
    {
        pickUpText.SetActive(false);
        isInTrigger = false;
        isInRayCast = false;
    }
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, maxDistance))
        {
            var selection = hit.transform;
            if (selection.tag == "PickUp")
            {
                isInRayCast = true;
            }
            else
            {
                isInRayCast = false;
            }
        }
    }

    public void OnPickUp(InputAction.CallbackContext context)
    {
        if (isInRayCast == true && context.started)
        {
            PickUp();
        }
    }
    

    /*void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            isInTrigger = true;
            pickUpText.SetActive(true);
        }
    }*/

    

    /*void OnTriggerExit(Collider other)
    {
        isInTrigger = false;
        pickUpText.SetActive(false);
    }*/

    void PickUp()
    {
        itemsPickedUp++;
        pickUpItem.GetComponent<MeshRenderer>().enabled = false;
        pickUpItem.GetComponent<BoxCollider>().enabled = false;
        pickUpText.SetActive(false);
        itemsPickUpsInt = itemsPickedUp;
        itemsPickedUpHUD.text = itemsPickedUp.ToString();
        Debug.Log(itemsPickUpsInt);
    }

}
