//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Gate : MonoBehaviour
//{
//    public enum GateType { START, END };

//    //public LayerMask PlayerLayer;

//    public GateType type;
//    public PlayerInteraction interaction;
//    public Animator ani;
//    public MapManager.STAGE stage;

//    private bool isopen;

//    public bool IsOpen
//    {
//        get
//        {
//            return isopen;
//        }
//        set
//        {
//            isopen = value;
//            if(isopen)
//            {
//                if(ani!=null)
//                    ani.SetTrigger("GateOpen");
//                if(interaction!=null)
//                    interaction.enabled = true;
//            }
//            else
//            {
//                if (ani != null)
//                    ani.SetTrigger("GateClose");
//                if (interaction != null)
//                    interaction.enabled = false;
//            }
//        }
//    }

//    public void StageClear()
//    {
//        MapManager.Instance.NextStage();

//    }

//    private void Awake()
//    {
//        interaction = GetComponentInChildren<PlayerInteraction>();

//        if (interaction != null)
//            interaction.AddKeydownAction(StageClear);

//        ani = GetComponentInChildren<Animator>();

//        if (type==GateType.START)
//        {
//            IsOpen = false;

//        }
//        else
//        {
//            IsOpen = true;

//        }

//    }

//}
