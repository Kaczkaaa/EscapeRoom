using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Traps : MonoBehaviour
{
    private int deathCounter = 0;

    [SerializeField] private TextMeshProUGUI deathCounterHud;
    
    public CheckpointController checkpointController;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            
            deathCounter++;
            deathCounterHud.text = deathCounter.ToString();
            checkpointController.Respawn();

        }
    }
    
}
