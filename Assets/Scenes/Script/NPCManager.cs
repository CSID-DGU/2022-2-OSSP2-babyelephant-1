using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCMove
{
    [Tooltip("NPCMove를 체크하면 NPC가 움직임")]
    public bool NPCmove;

    public string[] direction;

    [Range(1, 5)]
    [Tooltip("1=천천히, 2=조금 천천히, 3=보통, 4=빠르게, 5=연속적으로")]
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
    [Tooltip("NPCMOVE를 체크하면 NPC가 움직임")]
    public bool NPCMove;
    public string[] direction;
    [Range(1,5)]
    public int frequency; // npc가 얼마나 빠른 속도로 움직일 것인가
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
