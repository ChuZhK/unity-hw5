using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO_factory : MonoBehaviour
{
    public GameObject UFO;              //�ɵ�Ԥ��

    private List<UFO_info> used;                //����ʹ�õķɵ�
    private List<UFO_info> free;                //���еķɵ�

    public void Start()
    {
        used = new List<UFO_info>();
        free = new List<UFO_info>();
        UFO = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/UFO"), Vector3.zero, Quaternion.identity);
        UFO.SetActive(false);
    }

    public GameObject GetDisk(int round)
    {
        GameObject disk;
        //����п��еķɵ�����ֱ��ʹ�ã���������һ���µ�
        if (free.Count > 0)
        {
            disk = free[0].gameObject;
            free.Remove(free[0]);
        }
        else
        {
            disk = GameObject.Instantiate<GameObject>(UFO, Vector3.zero, Quaternion.identity);
            disk.AddComponent<UFO_info>();
        }

        //����round�����÷ɵ�����
        //�ɵ��ĵȼ� = 0~2֮�������� * �ִ���
        //0~4:  ��ɫ�ɵ�  
        //4~7:  ��ɫ�ɵ�  
        //7~10: ��ɫ�ɵ�
        float level = UnityEngine.Random.Range(0, 2f) * (round + 1);
        if (level < 4)
        {
            disk.GetComponent<UFO_info>().points = 1;
            disk.GetComponent<UFO_info>().speed = 4.0f;
            disk.GetComponent<UFO_info>().direction = new Vector3(UnityEngine.Random.Range(-1f, 1f) > 0 ? 2 : -2, 1, 0);
            disk.GetComponent<Renderer>().material.color = Color.red;
        }
        else if (level > 7)
        {
            disk.GetComponent<UFO_info>().points = 3;
            disk.GetComponent<UFO_info>().speed = 8.0f;
            disk.GetComponent<UFO_info>().direction = new Vector3(UnityEngine.Random.Range(-1f, 1f) > 0 ? 2 : -2, 1, 0);
            disk.GetComponent<Renderer>().material.color = Color.blue;
        }
        else
        {
            disk.GetComponent<UFO_info>().points = 2;
            disk.GetComponent<UFO_info>().speed = 6.0f;
            disk.GetComponent<UFO_info>().direction = new Vector3(UnityEngine.Random.Range(-1f, 1f) > 0 ? 2 : -2, 1, 0);
            disk.GetComponent<Renderer>().material.color = Color.green;
        }

        used.Add(disk.GetComponent<UFO_info>());

        return disk;
    }

    public void FreeDisk(GameObject disk)
    {
        //�ҵ�ʹ���еķɵ��������߳������뵽���ж���
        foreach (UFO_info UFO_info in used)
        {
            if (UFO_info.gameObject.GetInstanceID() == disk.GetInstanceID())
            {
                disk.SetActive(false);
                free.Add(UFO_info);
                used.Remove(UFO_info);
                break;
            }

        }
    }
}



