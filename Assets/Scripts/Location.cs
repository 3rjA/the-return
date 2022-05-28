using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{ 

    public string locationName;

    [TextArea]
    public string description;

    public Connection[] connections;

    //adding a list of items, initilize to new list

    public List<Item> items = new List<Item>();

    


    public string GetConnectionsText()
    {
        string result = "";
        foreach(Connection connection in connections)
        {
            if (connection.connectionEnabled)
                result += connection.description + "\n";

        }
        return result;
    }

    public Connection GetConnection(string connectionNoun)
    {
        foreach(Connection connection in connections)
        {
            if (connection.connectionName.ToLower() == connectionNoun.ToLower())
            {
                return connection;
            }
        }
        return null;
    }

    internal bool HasItem(Item itemToCheck)
    {
        foreach (Item item in items)
        {
            if (item == itemToCheck && item.itemEnabled)

                return true;
        }
        return false;
    }


    //if there are items, create a new string for result
    //add a boolean to see if theres only one item

    public string GetItemsText()
        {
            if (items.Count == 0) return "";

            
            string result = "You see ";
            
            bool first = true;
            foreach (Item item in items)
            {
                if (item.itemEnabled)
                {
                    if (!first) result += " and ";
                    result += item.description;
                    first = false;
                }
            }
            result += "\n";
            return result;
        }





}