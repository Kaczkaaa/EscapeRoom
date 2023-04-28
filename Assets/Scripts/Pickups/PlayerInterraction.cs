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
    public TextMeshProUGUI itemsPickedUpHUD;
    [SerializeField] private float maxDistance = 50;
    private bool isInRayCast;
    [SerializeField] private Transform camera;
    private InteractionType lastinteracTypeRayCasted;
    public GameObject putOffText;
    private IPlayerInteraction lastRaycastedInteraction;
    public GameObject doorText;

    int itemsPlacedAlready;

   [SerializeField] int itemsNeededtoPlace = 3;
    // Start is called before the first frame update
    void Start()
    {
        pickUpText.SetActive(false);
        isInRayCast = false;
        putOffText.SetActive(false);
        doorText.SetActive(false);
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
                case InteractionType.PickUp:
                    PickUp();
                    lastRaycastedInteraction?.OnInteraction();
                    break;
                case InteractionType.PutOff:
                    if (itemsPickedUp > 0)
                    {
                        PutOff();
                        itemsPlacedAlready++;
                        lastRaycastedInteraction?.OnInteraction();
                    }
                    break;
                case InteractionType.OpenDoor:
                    lastRaycastedInteraction?.OnInteraction();
                    doorText.SetActive(false);
                    break;
                case InteractionType.OpenClosedDoor:
                    if (itemsPlacedAlready == itemsNeededtoPlace)
                    {
                        doorText.SetActive(false);
                        lastRaycastedInteraction?.OnInteraction();
                    }
                    break;
                
            }
        }
    }
    void PickUp()
    {
        itemsPickedUp++;
        pickUpText.SetActive(false);
        itemsPickedUpHUD.text = itemsPickedUp.ToString();
    }
    void PutOff()
    {
        itemsPickedUp --;
        putOffText.SetActive(false);
        itemsPickedUpHUD.text = itemsPickedUp.ToString();
    }
    void RayCastCheck()
    {
        camera = Camera.main.transform;
        
        RaycastHit hit;
        
        if(Physics.Raycast(camera.position,camera.forward, out hit,maxDistance))
        {
            var selection = hit.transform.GetComponent<Interactions>();

            if (selection == null)
            {
                isInRayCast = false;
                pickUpText.SetActive(false);
                putOffText.SetActive(false);
                doorText.SetActive(false);
                return;
            }
            
            isInRayCast = true;
            
            lastinteracTypeRayCasted = selection.interactionType;
            lastRaycastedInteraction = hit.transform.GetComponent<IPlayerInteraction>();
            switch (selection.interactionType)
            {
                case InteractionType.PickUp:
                    pickUpText.SetActive(true);
                    break;
                case InteractionType.PutOff:
                    putOffText.SetActive(true);
                    break;
                case InteractionType.OpenDoor:
                    doorText.SetActive(true);
                    break;
                case InteractionType.OpenClosedDoor:
                    doorText.SetActive(true);
                    break;
                default:
                    break;
            }
        }
    }
}
