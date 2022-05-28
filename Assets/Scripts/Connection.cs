using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Connection : MonoBehaviour
{
    public string connectionName;

    public string description;

    public Location location;

    public bool connectionEnabled;

    public bool itemEnabled;

    public Connection(bool connectionEnabled)
    {
        this.connectionEnabled = connectionEnabled;
    }

   
}