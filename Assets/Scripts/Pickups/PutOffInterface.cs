using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutOffInterface : MonoBehaviour,IPlayerInteraction
{
    public void OnInteraction()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
}
