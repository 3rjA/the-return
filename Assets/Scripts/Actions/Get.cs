using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Get")]
public class Get : Action
{
    public override void RespondToInput(GameController1 controller1, string noun)
    {
        foreach (Item item in controller1.player.currentLocation.items)
        {   //lets player take an item, removes item from location afterwards.
            if (item.itemEnabled && item.itemName == noun)
            {
                if (item.playerCanTake)
                {
                    controller1.player.inventory.Add(item);
                    controller1.player.currentLocation.items.Remove(item);
                    controller1.currentText.text = "You take the " + noun;
                    return;
                }
            }
        }
        controller1.currentText.text = "You can't get that";
    }
}
