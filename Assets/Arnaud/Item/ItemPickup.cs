using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{


    public Item item;


   public void PickUp()
   {
    
    Debug.Log ("picking up " + item.name);
    Inventory.instance.Add(item);
    Destroy(gameObject);
   }
}
