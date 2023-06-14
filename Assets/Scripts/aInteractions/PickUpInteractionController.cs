using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUpInteractionController : MonoBehaviour, IPlayerInteraction
{
    public InteractionType interactionType = InteractionType.PickUp;
    public TextMeshProUGUI pickUpText;
    public TextMeshProUGUI textObject => pickUpText;
    public string textUI = "Use E to pick up";

    public InteractionType GetInteractionType() => interactionType;
    public void HandleUi()
    {
        textObject.text = textUI;
        textObject.gameObject.SetActive(true);
    }

    private void Start()
    {
        textObject.gameObject.SetActive(false);
    }

    public void OnInteraction(GameObject sender)
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;

        PlayerInterraction playerInterraction = sender.GetComponent<PlayerInterraction>();
        if(playerInterraction != null)
        {
            playerInterraction.PickUp();
            textObject.gameObject.SetActive(false);

        }
    }
    
}
