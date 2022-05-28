using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public string itemName;

    [TextArea]
    public string description;

    public bool playerCanTake;

    public bool itemEnabled = true;

    public Interaction[] interactions;

    public Item targetItem = null;


    public bool InteractWith(GameController1 controller1, string actionKeyword, string noun = "")
    {
        foreach (Interaction interaction in interactions)
        {
            if (interaction.action.keyword == actionKeyword)
            {
                //if (noun!="" && noun.ToLower(noun != interaction.textToMatch.ToLower()))
                foreach (Item disableItem in interaction.itemsToDisable)
                    disableItem.itemEnabled = false; 

                foreach (Item enableItem in interaction.itemsToEnable)
                    enableItem.itemEnabled = true;

                foreach (Connection disableConnection in interaction.connectionsToDisable)
                    disableConnection.connectionEnabled = false;

                foreach (Connection enableConnection in interaction.connectionsToEnable)
                    enableConnection.connectionEnabled = true;

                controller1.currentText.text = interaction.response;
                controller1.DisplayLocation(true);


                return true;

                
            }
        }
    return false;
    }
   
}
