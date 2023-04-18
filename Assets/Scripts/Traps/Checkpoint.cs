using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
   [SerializeField] CheckpointController checkpointController;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] Collider collider;

    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("1");
        if (other.gameObject.layer == 3)
        { 
            Debug.Log("2");
            checkpointController.actuallCheckpoint = gameObject.transform;
            if (collider != null)
            {
                collider.enabled = false;
            }
        }
    }


}
