using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FirstController : MonoBehaviour, ISceneController, IUserAction
{
    public RunActionManager actionManager;                   //����������
    public UFO_factory ufoFactory;                         //�ɵ�����
    int[] roundDisks;           //��Ӧ�ִεķɵ�����
    bool isInfinite;            //��Ϸ��ǰģʽ
    int points;                 //��Ϸ��ǰ����
    int round;                  //��Ϸ��ǰ�ִ�
    int sendCnt;                //��ǰ�ѷ��͵ķɵ�����
    float sendTime;             //����ʱ��

    void Start()
    {
        LoadResources();
    }

    public void LoadResources()
    {
        MyDirector.GetInstance().CurrentScenceController = this;
        gameObject.AddComponent<UFO_factory>();
        gameObject.AddComponent<RunActionManager>();
        gameObject.AddComponent<UserGUI>();
        ufoFactory = once<UFO_factory>.Instance;
        sendCnt = 0;
        round = 0;
        sendTime = 0;
        points = 0;
        isInfinite = false;
        roundDisks = new int[] { 3, 5, 8, 13, 21 };
    }

    public void SendDisk()
    {
        //�ӹ�������һ���ɵ�
        GameObject disk = ufoFactory.GetDisk(round);
        //���÷ɵ������λ��
        disk.transform.position = new Vector3(-disk.GetComponent<UFO_info>().direction.x * 7, UnityEngine.Random.Range(0f, 8f), 0);
        disk.SetActive(true);
        //���÷ɵ��ķ��ж���
        actionManager.Fly(disk, disk.GetComponent<UFO_info>().speed, disk.GetComponent<UFO_info>().direction);
    }

    public void Hit(Vector3 position)
    {
        Camera ca = Camera.main;
        Ray ray = ca.ScreenPointToRay(position);

        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray);

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            if (hit.collider.gameObject.GetComponent<UFO_info>() != null)
            {
                //���ɵ������׶ˣ��������ж����Ļص�
                hit.collider.gameObject.transform.position = new Vector3(0, -7, 0);
                //����
                points += hit.collider.gameObject.GetComponent<UFO_info>().points;
                //����GUI����
                gameObject.GetComponent<UserGUI>().points = points;
            }
        }
    }

    public void Restart()
    {
        gameObject.GetComponent<UserGUI>().gameMessage = "";
        round = 0;
        sendCnt = 0;
        points = 0;
        gameObject.GetComponent<UserGUI>().points = points;
    }

    public void SetMode(bool isInfinite)
    {
        this.isInfinite = isInfinite;
    }

    void Update()
    {
        sendTime += Time.deltaTime;
        //ÿ��1s����һ�ηɵ�
        if (sendTime > 1)
        {
            sendTime = 0;
            //ÿ�η�������5���ɵ�
            for (int i = 0; i < 5 && sendCnt < roundDisks[round]; i++)
            {
                sendCnt++;
                SendDisk();
            }
            //�ж��Ƿ���Ҫ�����ִΣ�����Ҫ�������Ϸ����
            if (sendCnt == roundDisks[round] && round == roundDisks.Length - 1)
            {
                if (isInfinite)
                {
                    round = 0;
                    sendCnt = 0;
                    gameObject.GetComponent<UserGUI>().gameMessage = "";
                }
                else
                {
                    gameObject.GetComponent<UserGUI>().gameMessage = "Game Over!";
                }
            }
            //�����ִ�
            if (sendCnt == roundDisks[round] && round < roundDisks.Length - 1)
            {
                
                sendCnt = 0;
                round++;
                UserGUI.myrounds = round+1;
            }
        }
    }
}

