using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Inventory")]
public class Inventory : Action
{
    public override void RespondToInput(GameController1 controller1, string noun)
    {
        if (controller1.player.inventory.Count == 0)
        {
            controller1.currentText.text = "You have nothing!";
            return;
        }

        string result = "You have ";

        bool first = true;
        foreach (Item item in controller1.player.inventory)
        {
            if (first)
                result += " a " +item.itemName;
            else
            
                result += " and a " +item.itemName;
                first = false;
            
        }
        controller1.currentText.text = result;
    } 
}
