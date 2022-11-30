using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class RunAction :MyBaseAction
{
    float gravity;          //�������ٶ�
    float speed;            //ˮƽ�ٶ�
    Vector3 direction;      //���з���
    float time;             //ʱ��

    //��������(����ģʽ)
    public static RunAction GetSSAction(Vector3 direction, float speed)
    {
        RunAction action = ScriptableObject.CreateInstance<RunAction>();
        action.gravity = 9.8f;
        action.time = 0;
        action.speed = speed;
        action.direction = direction;
        return action;
    }

    public override void Start()
    {

    }

    public override void Update()
    {
        time += Time.deltaTime;
        transform.Translate(Vector3.down * gravity * time * Time.deltaTime);
        transform.Translate(direction * speed * Time.deltaTime);
        //����ɵ�����ײ����������������лص�
        if (this.transform.position.y < -6)
        {
            this.destroy = true;
            this.enable = false;
            this.callback.BaseActionEvent(this);
        }

    }
}
