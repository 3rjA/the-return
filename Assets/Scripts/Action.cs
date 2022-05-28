using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject
{
    public string keyword;

    public abstract void RespondToInput(GameController1 controller1, string noun);

}
