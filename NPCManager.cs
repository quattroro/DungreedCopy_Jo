using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////
///������ �۾�
///npc���� �ڽ��� �����Ǹ� �˾Ƽ� npc�Ŵ����� �ڽ��� �־ �Ŵ����� ������ �±��.
/////////////////////////////////////////////////////////////////////

public class NPCManager : MonoBehaviour
{

    public List<BaseNPC> npclist;


    public void AddToNpcList(BaseNPC obj)
    {
        npclist.Add(obj);
    }
    
    public void DeleteToNpcList(BaseNPC obj)
    {
        npclist.Remove(obj);
    }

}
