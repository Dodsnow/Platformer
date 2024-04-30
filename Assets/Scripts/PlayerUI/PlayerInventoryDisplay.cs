using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerInventory))]
public class PlayerInventoryDisplay : MonoBehaviour
{
    // public TextMeshProUGUI inventoryText;
    public TextMeshProUGUI gemInventoryText;
    public TextMeshProUGUI rewindPotionInventoryText;

    


    public void OnChangeInventory(Dictionary<PickUp.PickUpType, int> inventory)
    {
       
        // inventoryText.text = "";
        gemInventoryText.text = "";
        rewindPotionInventoryText.text = "";
        
        string newGemInventoryText = "";
        string newRewindPotionInventoryText = "";
        string newHealthInventoryText = "";
        foreach (var item in inventory)
        {
         switch (item.Key)
         {
             case PickUp.PickUpType.Gem :
                 newGemInventoryText += item.Value;
                 break;
             case PickUp.PickUpType.RewindPotion:
                 newRewindPotionInventoryText += item.Value;
                 break;
                 
         }
        }      
        
        
        int numItems = inventory.Count;
        if (numItems < 1)
        {
            gemInventoryText.text = "0";
            rewindPotionInventoryText.text = "0";
            
           
        }

        gemInventoryText.text = newGemInventoryText;
        rewindPotionInventoryText.text = newRewindPotionInventoryText;
        
    }
}
