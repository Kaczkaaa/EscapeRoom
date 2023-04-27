using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerInterraction : MonoBehaviour
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
        RayCastCheck();
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
   public void PickUp()
    {
        itemsPickedUp++;
        IPlayerInteraction interactableobject = GetComponent<IPlayerInteraction>();
        if (interactableobject != null)
        {
            interactableobject.OnInteraction();
        }
        pickUpText.SetActive(false);
        itemsPickedUpHUD.text = itemsPickedUp.ToString();
    }
    public void PutOff()
    {
        itemsPickedUp --;
        putOffText.SetActive(false);
        IPlayerInteraction interactableobject = GetComponent<IPlayerInteraction>();
        if (interactableobject != null)
        {
            interactableobject.OnInteraction();
        }
        itemsPickedUpHUD.text = itemsPickedUp.ToString();
    }
    void RayCastCheck()
    {
        camera = Camera.main.transform;
        
        RaycastHit hit;
        
        if(Physics.Raycast(camera.position,camera.forward, out hit,maxDistance))
        {
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
}
