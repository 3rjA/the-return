using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Go")]
public class Go : Action
{
    public override void RespondToInput(GameController1 controller1, string noun)
    {
        if (controller1.player.ChangeLocation(controller1, noun))
        {
            controller1.DisplayLocation();
        }
        else 
        {
            controller1.currentText.text = "You can't go that way.";
        }
    }

}
