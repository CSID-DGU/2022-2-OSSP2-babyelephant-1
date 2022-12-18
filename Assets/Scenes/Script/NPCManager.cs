using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCMove
{
    [Tooltip("NPCMove�� üũ�ϸ� NPC�� ������")]
    public bool NPCmove;

    public string[] direction;

    [Range(1, 5)]
    [Tooltip("1=õõ��, 2=���� õõ��, 3=����, 4=������, 5=����������")]
    public int frequency;
}
public class NPCManager : MovingObject
{
    [SerializeField]
    public NPCMove npc;
    // Start is called before the first frame update
    void Start()
    {
        queue = new Queue<string>();
    }

    public void setMove()
    {
        StartCoroutine(MoveCoroutine());

    }

    public void SetNotMove()
    {
        StopAllCoroutines();
    }

    IEnumerator MoveCoroutine()
    {
        if (npc.direction.Length != 0)
        {
            for (int i = 0; i < npc.direction.Length; i++)
            {


                yield return new WaitUntil(() => queue.Count < 2);
                base.Move(npc.direction[i], npc.frequency);

                if (i == npc.direction.Length - 1)
                    i = -1;
            }
        }
    }
}
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCMove2
{
    [Tooltip("NPCMOVE�� üũ�ϸ� NPC�� ������")]
    public bool NPCMove;
    public string[] direction;
    [Range(1,5)]
    public int frequency; // npc�� �󸶳� ���� �ӵ��� ������ ���ΰ�
}

public class NPCManager : MonoBehaviour
{
    [SerializeField]
    public NPCMove2 npc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}*/
