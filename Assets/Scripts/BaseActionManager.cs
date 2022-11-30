using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaseActionManager : MonoBehaviour
{
    //�����������ֵ���ʽ����
    private Dictionary<int, MyBaseAction> actions = new Dictionary<int, MyBaseAction>();
    //�ȴ�������Ķ�������(����������ʼ)
    private List<MyBaseAction> waitingAdd = new List<MyBaseAction>();
    //�ȴ���ɾ���Ķ�������(���������)
    private List<int> waitingDelete = new List<int>();

    protected void Update()
    {
        //��waitingAdd�еĶ�������
        foreach (MyBaseAction ac in waitingAdd)
            actions[ac.GetInstanceID()] = ac;
        waitingAdd.Clear();

        //���б�������¼�
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

        //����waitingDelete�еĶ���
        foreach (int key in waitingDelete)
        {
            MyBaseAction ac = actions[key];
            actions.Remove(key);
            Destroy(ac);
        }
        waitingDelete.Clear();
    }

    //׼������һ����������������ʼ���������뵽waitingAdd
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
