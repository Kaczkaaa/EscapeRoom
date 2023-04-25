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
    [SerializeField] private float maxDistance = 50;
    private bool isInRayCast;
     
    [SerializeField] private Transform camera;
    private DropZoneInteractionType lastinteracTypeRayCasted;
    
    // Start is called before the first frame update
    void Start()
    {
        pickUpText.SetActive(false);
        isInRayCast = false;
    }
    void Update()
    {
        camera = Camera.main.transform;
        RaycastHit hit;
        if(Physics.Raycast(camera.position,camera.forward, out hit,maxDistance))
        {
            Debug.DrawLine(camera.position,camera.forward * maxDistance, Color.yellow);
            var selection = hit.transform.GetComponent<DropZone>();

            if (selection == null)
            {
                isInRayCast = false;
                pickUpText.SetActive(false);
                return;
            }
            
            isInRayCast = true;
            lastinteracTypeRayCasted = selection.dropZoneInteractionType;
            switch (selection.dropZoneInteractionType)
            {
                case DropZoneInteractionType.PutOn:
                    pickUpText.SetActive(true);
                    break;
                case DropZoneInteractionType.PutOf://putoff
                    break;
                default:
                    break;
            }
            
            if (selection.dropZoneInteractionType == DropZoneInteractionType.PutOn)
            {
                isInRayCast = true;
            }
            else
            {
                isInRayCast = false;
                pickUpText.SetActive(false);
            }
        }
    }

    public void OnPickUp(InputAction.CallbackContext context)
    {
        if (isInRayCast  && context.started)
        {
            switch (lastinteracTypeRayCasted)
            {
                case DropZoneInteractionType.PutOn:
                    PickUp();
                    break;
                case DropZoneInteractionType.PutOf:
                    //PutOff();
                    break;
            }
            PickUp();
        }
    }
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
