using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MyBaseAction : ScriptableObject
{
    public bool enable = true;
    public bool destroy = false;

    public GameObject gameObject { get; set; }
    public Transform transform { get; set; }
    public MyActionCallback callback { get; set; }

    protected MyBaseAction()
    {

    }

    // Start is called before the first frame update
    public virtual void Start()
    {
        throw new System.NotImplementedException();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        throw new System.NotImplementedException();
    }
}
