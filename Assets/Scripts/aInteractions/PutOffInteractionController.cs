using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PutOffInteractionController : MonoBehaviour, IPlayerInteraction
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI textObject => text;
    public InteractionType GetInteractionType() => InteractionType.OpenClosedDoor;
    public string textUI = "Use E to put off";
    [SerializeField] ScriptableObjectINT itemsPickedUp;
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
        PlayerInterraction playerInterraction = sender.GetComponent<PlayerInterraction>();
        
         if (itemsPickedUp.value > 0)
         {
             gameObject.GetComponent<BoxCollider>().enabled = false;
             gameObject.GetComponent<MeshRenderer>().enabled = true;
             if (playerInterraction != null)
                 playerInterraction.PutOff();
         }
        textObject.gameObject.SetActive(false);
    }

}
