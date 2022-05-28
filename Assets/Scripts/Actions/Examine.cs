using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Examine")]
public class Examine : Action
{
    public override void RespondToInput(GameController1 controller1, string noun)
    {
        //check items in room
        if (CheckItems(controller1, controller1.player.currentLocation.items, noun))
            return;

        //check items in inventory
        if (CheckItems(controller1, controller1.player.inventory, noun))
            return;

        //if item isn't available to the player
        //"you can't see a serpent"
        //can examine other items except serpent
        controller1.currentText.text = "You can't see a " + noun;
    }

    private bool CheckItems(GameController1 controller1, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemName == noun)
            {
                if (item.InteractWith(controller1, "examine"))
                
                    return true;
                controller1.currentText.text = "You see " + item.description; 
                
                return true; 
            }
        }
        return false;
    }

}
