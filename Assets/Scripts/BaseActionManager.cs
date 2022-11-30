using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaseActionManager : MonoBehaviour
{
    //动作集，以字典形式存在
    private Dictionary<int, MyBaseAction> actions = new Dictionary<int, MyBaseAction>();
    //等待被加入的动作队列(动作即将开始)
    private List<MyBaseAction> waitingAdd = new List<MyBaseAction>();
    //等待被删除的动作队列(动作已完成)
    private List<int> waitingDelete = new List<int>();

    protected void Update()
    {
        //将waitingAdd中的动作保存
        foreach (MyBaseAction ac in waitingAdd)
            actions[ac.GetInstanceID()] = ac;
        waitingAdd.Clear();

        //运行被保存的事件
        foreach (KeyValuePair<int, MyBaseAction> kv in actions)
        {
            MyBaseAction ac = kv.Value;
            if (ac.destroy)
            {
                waitingDelete.Add(ac.GetInstanceID());
            }
            else if (ac.enable)
            {
                ac.Update();
            }
        }

        //销毁waitingDelete中的动作
        foreach (int key in waitingDelete)
        {
            MyBaseAction ac = actions[key];
            actions.Remove(key);
            Destroy(ac);
        }
        waitingDelete.Clear();
    }

    //准备运行一个动作，将动作初始化，并加入到waitingAdd
    public void Run(GameObject gameObject, MyBaseAction action,MyActionCallback manager)
    {
        action.gameObject = gameObject;
        action.transform = gameObject.transform;
        action.callback = manager;
        waitingAdd.Add(action);
        action.Start();
    }

    // Start is called before the first frame update
    protected void Start()
    {

    }

}
