using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Use")]
public class Use : Action
{
    public override void RespondToInput(GameController1 controller1, string noun)
    {
        //check items in room
        if (UseItems(controller1, controller1.player.currentLocation.items, noun))
            return;

        //check items in inventory
        if (UseItems(controller1, controller1.player.inventory, noun))
            return;

        //if item isn't available to the player
        controller1.currentText.text = "There is no " + noun;
    }

    //private bool CheckItems(GameController1 controller1, List<Item> items, string noun)
    private bool UseItems(GameController1 controller1, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            //here I had noun.item written
            if (item.itemName == noun)
            {
                //if (item.InteractWith(controller1, "examine"))
                //disabling this method will cause the response to happen before reaching serpent
                if (controller1.player.CanUseItem(controller1, item))
                {
                    //if anything else added as targetItem on staff, and in location, will error
                    if (item.InteractWith(controller1, "use"))
                    {
                        return true;
                    }

                    controller1.currentText.text = item.description;
                }
                controller1.currentText.text = "The " +noun+ " does nothing!";
                return true;
            }
        }
        return false;
    }

}


/*
 public override void RespondToInput(GameController1 controller1, string noun)
    {
        //check items in room
        if (CheckItems(controller1, controller1.player.currentLocation.items, noun))
            return;

        //check items in inventory
        if (CheckItems(controller1, controller1.player.inventory, noun))
            return;

        //if item isn't available to the player
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
*/