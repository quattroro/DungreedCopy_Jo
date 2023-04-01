using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



/////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////
///조민익 작업
///모든 NPC들의 기본 클래스
///PlayerInteraction 컴포넌트를 가지고 있는 모든 오브젝트들은 
///캐릭터가 가까이오면 상호작용키를 보여주고
///해당 키가 눌리면 AddKeydownAction()함수를 이용해 미리
///설정된 함수가 실행되도록 합니다.
/////////////////////////////////////////////////////////////////////

public class BaseNPC : MonoBehaviour
{
    public string NPCName;

    public string NPCAction;
    public string NPCNick;

    public PlayerInteraction interaction;

    public bool NowQuest;

    public GameObject EnterPopUp;

    public GameObject QuestPopUp;

    public GameObject Body;

    [SerializeField]
    private GameObject DialogBox;
    [SerializeField]
    private GameObject Btn;
    private Button m_Btn_Action;

    public void InitSetting()
    {
        interaction = GetComponent<PlayerInteraction>();
        Body = this.transform.Find("Body").gameObject;
        EnterPopUp = transform.Find("EnterPopUp").gameObject;
        EnterPopUp.SetActive(false);
        //interaction.AddEnterAction(ShowPopUp);
        //interaction.AddOutAction(ClosePopUp);
        interaction.AddKeydownAction(ShowKeyDownPopUp);
        if (DialogBox == null)
        {
            DialogBox = GameObject.FindGameObjectWithTag("MainCanvas").transform.GetChild(0).gameObject;
            Btn = DialogBox.transform.GetChild(2).transform.GetChild(1).gameObject;
        }
    }


    //해당 기능들은 PlayerInteraction 으로 이전
    ////현재 퀘스트가 있으면 퀘스트팝업을 띄우고 유저가 가까이 오면 f 상포작용 팝업을 띄운다.
    //public void ShowPopUp()
    //{
    //    if (EnterPopUp != null)
    //        EnterPopUp.SetActive(true);
    //}

    //public void ClosePopUp()
    //{
    //    if (EnterPopUp != null)
    //        if (EnterPopUp.activeSelf)
    //            EnterPopUp.SetActive(false);

    //}

    //public void ShowQuestPopUp()
    //{
    //    if (QuestPopUp != null)
    //        QuestPopUp.SetActive(true);
    //}

    public void ShowKeyDownPopUp()
    {

        DialogBox.SetActive(true);
        DialogBox.GetComponent<Dialog>().findNpc(this);

        m_Btn_Action.onClick.RemoveAllListeners();
        btnAction();
    }

    public void btnAction()
    {
        string name = NPCName;
        m_Btn_Action.onClick.AddListener(delegate () { ActionManager.instance.actionOn(name); });
    }

    private void Start()
    {
        InitSetting();

        m_Btn_Action = Btn.GetComponent<Button>();
    }

}
