using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MyDirector : System.Object
{
    private static MyDirector _instance;
    public ISceneController CurrentScenceController { get; set; }
    public static MyDirector GetInstance()
    {
        if (_instance == null)
        {
            _instance = new MyDirector();
        }
        return _instance;
    }
}
