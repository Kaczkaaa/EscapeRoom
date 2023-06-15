using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private int actualScene;
    private int nextScene;
    void Start()
    {
        actualScene = SceneManager.sceneCount;
        nextScene = actualScene + 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
