using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

 public interface IPlayerInteraction
{
    public TextMeshProUGUI textObject { get; }
    public void OnInteraction(GameObject sender);
    public InteractionType GetInteractionType();
    public void HandleUi();
}

  

