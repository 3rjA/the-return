using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Location currentLocation;

    public List<Item> inventory = new List<Item>();


    
    public bool ChangeLocation(GameController1 controller1, string connectionNoun)
    {
        Connection connection = currentLocation.GetConnection(connectionNoun);
        if (connection !=null)
        {
            if (connection.connectionEnabled)
            {
                currentLocation = connection.location;
                return true;
            }
        }
        return false;
    }

    internal bool CanUseItem(GameController1 controller1, Item item)
    {
        //no effect if target item added
        if (item.targetItem == null)
            return true;

        //this will cause "the staff does nothing!"-string
        //if targetItem is removed, error will occur
        if (HasItem(item.targetItem))
            //return true;

        //no effect if target item added
        if (currentLocation.HasItem(item.targetItem))
            return true;

        return false;
    }

    private bool HasItem(Item itemToCheck)
    {
        foreach (Item item in inventory)
        {
            //removing && item.targetItem does nothing
            //changed .targetItem to itemEnabled
            if (item == itemToCheck && item.itemEnabled)
                return true;
        }
        return false;
    }
    
}
