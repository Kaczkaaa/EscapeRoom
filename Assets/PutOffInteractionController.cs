using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PutOffInteractionController : MonoBehaviour, IPlayerInteraction
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI textObject => text;
    public InteractionType GetInteractionType() => InteractionType.OpenClosedDoor;
   
    [SerializeField] ScriptableObjectINT itemsPickedUp;

    public void OnInteraction(GameObject sender)
    {
        PlayerInterraction playerInterraction = sender.GetComponent<PlayerInterraction>();
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
         if (itemsPickedUp.value > 0)
         {
             if (playerInterraction != null)
                 playerInterraction.PutOff();
         }
        textObject.gameObject.SetActive(false);

    }

}
