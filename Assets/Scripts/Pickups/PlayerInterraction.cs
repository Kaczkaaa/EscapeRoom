using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerInterraction : MonoBehaviour
{
    public TextMeshProUGUI itemsPickedUpHUD;
    [SerializeField] private float maxDistance = 50;
    private bool isInRayCast;
    [SerializeField] private Transform camera;
    private IPlayerInteraction lastRaycastedInteraction;
    [SerializeField] ScriptableObjectINT itemsPickedUp;
    [SerializeField] ScriptableObjectINT itemsPlacedAlready;
    // Start is called before the first frame update
    void Start()
    {
        isInRayCast = false;
        itemsPickedUp.value = 0;
    }
    void Update()
    {
        RayCastCheck();
    }

    public void OnPickUp(InputAction.CallbackContext context)
    {
        if (isInRayCast  && context.started)
        {
            lastRaycastedInteraction?.OnInteraction(gameObject);
        }
    }
    public void PickUp()
    {
        itemsPickedUp.value++;
        itemsPickedUpHUD.text = itemsPickedUp.value.ToString();
    }

    public void PutOff()
    {
        itemsPickedUp.value --;
        itemsPickedUpHUD.text = itemsPickedUp.value.ToString();
        itemsPlacedAlready.value++;
    }
    void RayCastCheck()
    {
        camera = Camera.main.transform;
        
        RaycastHit hit;
        
        if(Physics.Raycast(camera.position,camera.forward, out hit,maxDistance))
        {
            
            if(lastRaycastedInteraction != null)
            {
                lastRaycastedInteraction.textObject?.gameObject.SetActive(false);
            }
            
            lastRaycastedInteraction = hit.transform.GetComponent<IPlayerInteraction>();

            if (lastRaycastedInteraction == null)
            {
                isInRayCast = false;
                return;
            }

            
            isInRayCast = true;
            IPlayerInteraction ui = hit.transform.GetComponent<IPlayerInteraction>();
            ui.HandleUi();
        }
        else
        {
            if(lastRaycastedInteraction != null)
            {
                lastRaycastedInteraction.textObject?.gameObject.SetActive(false);
            }
        }
    }
}
