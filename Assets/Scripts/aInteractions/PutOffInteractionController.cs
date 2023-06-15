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
    public void HandleUi()
    {
        textObject.text = textUI;
        textObject.gameObject.SetActive(true);
    }

    [SerializeField] ScriptableObjectINT itemsPickedUp;

    private void Start()
    {
        textObject.gameObject.SetActive(false);
    }

    public void OnInteraction(GameObject sender)
    {
        PlayerInterraction playerInterraction = sender.GetComponent<PlayerInterraction>();
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
         if (itemsPickedUp.value > 1)
         {
             if (playerInterraction != null)
                 playerInterraction.PutOff();
         }
        textObject.gameObject.SetActive(false);
    }

}
