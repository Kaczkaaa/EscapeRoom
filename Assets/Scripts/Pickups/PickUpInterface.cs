using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpInterface : MonoBehaviour,IPlayerInteraction
{
    public void OnInteraction()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}
