using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Help")]
public class Help : Action
{
    public override void RespondToInput(GameController1 controller1, string noun)
    {
        controller1.currentText.text = "Type a verb followed by a noun(e.g. \"go north\")";
        controller1.currentText.text += "\nAllowed verbs:\nGo, Examine, Get, Use, Inventory, TalkTo, Say, Read, Help";
    }
}
