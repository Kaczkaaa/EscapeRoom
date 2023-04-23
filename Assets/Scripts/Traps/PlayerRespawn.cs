using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class PlayerRespawn : MonoBehaviour,IDamagable
{
    private int deathCounter;

    [SerializeField] private TextMeshProUGUI deathCounterHud;
    
    public CheckpointController checkpointController;

    public ScriptableObject SOdeathcounter;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   /* private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            deathCounter++;
            deathCounterHud.text = deathCounter.ToString();
            checkpointController.Respawn(); 

        }
    }*/

   private void OnTriggerEnter(Collider other)
   {
       
   }
   // 
   public void OnKill()
   {
       deathCounter++;
       deathCounterHud.text = deathCounter.ToString();
       checkpointController.Respawn();
   }
}
