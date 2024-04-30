using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;


public class PlayerInventory : MonoBehaviour
{
    private PlayerInventoryDisplay _playerInventoryDisplay;
    public int rewindQuantity = 0;
    private int currentRewindQuantity;
    public Dictionary<PickUp.PickUpType, int> inventory;
   

    private void Awake()
    {
        currentRewindQuantity = rewindQuantity;
        inventory = new Dictionary<PickUp.PickUpType, int>();
        _playerInventoryDisplay = GetComponent<PlayerInventoryDisplay>();
        _playerInventoryDisplay.OnChangeInventory(inventory);
    }

    private void Update()
    {
        if(currentRewindQuantity < rewindQuantity)
        {
           RemoveItem(PickUp.PickUpType.RewindPotion);
        }

    }

    public void AddItem(PickUp pickup)
    {
        PickUp.PickUpType type = pickup.type;

        int oldTotal = 0;
        if (inventory.TryGetValue(type, out oldTotal))
        {
            inventory[type] = oldTotal + 1;
        }
        else
        {
            inventory.Add(type, 1);
        }

        _playerInventoryDisplay.OnChangeInventory(inventory);

        if (type == PickUp.PickUpType.RewindPotion)
        {
            rewindQuantity++;
            currentRewindQuantity = rewindQuantity;
        }
    }


    public void RemoveItem(PickUp.PickUpType pickUp)
    {
        PickUp.PickUpType type = pickUp;
        int oldTotal = 0;
        if (inventory.TryGetValue(type, out oldTotal))
        {
            inventory[type] = oldTotal - 1;
        }
        else
        {
            inventory.Remove(type, out oldTotal);
        }

        _playerInventoryDisplay.OnChangeInventory(inventory);
        if (type == PickUp.PickUpType.RewindPotion)
        {
            rewindQuantity--;
        }
    }


    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("PickUp"))
        {
            PickUp item = hit.GetComponent<PickUp>();
            AddItem(item);
            Destroy(hit.gameObject);
        }
    }
}