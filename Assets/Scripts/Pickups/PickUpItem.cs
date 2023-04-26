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
    public GameObject pickUpText;
    public GameObject pickUpItem;
    public TextMeshProUGUI itemsPickedUpHUD;
    [SerializeField] private float maxDistance = 50;
    private bool isInRayCast;
     
    [SerializeField] private Transform camera;
    private DropZoneInteractionType lastinteracTypeRayCasted;
    
    
    public GameObject putOffText;
    public GameObject putOffItem;
    
    // Start is called before the first frame update
    void Start()
    {
        pickUpText.SetActive(false);
        isInRayCast = false;
        putOffText.SetActive(false);
    }
    void Update()
    {

        camera = Camera.main.transform;
        RaycastHit hit;
        if(Physics.Raycast(camera.position,camera.forward, out hit,maxDistance))
        {
            //Debug.DrawLine(camera.position,camera.forward * maxDistance, Color.yellow);
            var selection = hit.transform.GetComponent<DropZone>();

            if (selection == null)
            {
                isInRayCast = false;
                pickUpText.SetActive(false);
                putOffText.SetActive(false);
                return;
            }
            
            isInRayCast = true;
            lastinteracTypeRayCasted = selection.dropZoneInteractionType;
            switch (selection.dropZoneInteractionType)
            {
                case DropZoneInteractionType.PutOn:
                    pickUpText.SetActive(true);
                    break;
                case DropZoneInteractionType.PutOff:
                    putOffText.SetActive(true);
                    break;
                default:
                    break;
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
                case DropZoneInteractionType.PutOff:
                    PutOff();
                    break;
            }
        }
    }
    void PickUp()
    {
        itemsPickedUp++;
        pickUpItem.GetComponent<MeshRenderer>().enabled = false;
        pickUpItem.GetComponent<BoxCollider>().enabled = false;
        pickUpText.SetActive(false);
        itemsPickedUpHUD.text = itemsPickedUp.ToString();
    }
    void PutOff()
    {
        Debug.Log(itemsPickedUp);
        itemsPickedUp --;
        putOffText.SetActive(false);
        putOffItem.GetComponent<BoxCollider>().enabled = false;
        putOffItem.GetComponent<MeshRenderer>().enabled = true;
        itemsPickedUpHUD.text = itemsPickedUp.ToString();
    }
}
