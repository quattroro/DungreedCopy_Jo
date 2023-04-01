using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////
///조민익 작업
///플레이어와 상호작용가능한 오브젝트들에 붙여서 사용합니다.
///PlayerInteraction 컴포넌트를 가지고 있는 모든 오브젝트들은 
///캐릭터가 가까이오면 상호작용키를 보여주고
///해당 키가 눌리면 AddKeydownAction()함수를 이용해 미리
///설정된 함수가 실행되도록 합니다.
///상호작용 범위를 지정할 boxcollider가 객체에 필요합니다.
/////////////////////////////////////////////////////////////////////

public class PlayerInteraction : MonoBehaviour
{
    public LayerMask PlayerLayer;

    //현재값
    [System.Serializable]
    public class CurrentValues
    {
        public bool PlayerEnter;
        public float CheckSecond;
    }


    //캐릭터 상호작용 거리
    public CircleCollider2D Circlerange;
    //public BoxCollider2D Boxrange;

    //마지막으로 체크한 시간
    public float lastTime;
    //상호작용 키
    public KeyCode InteractionKey = KeyCode.F;
    //현재 값
    public CurrentValues current = new CurrentValues();
    //상호작용 액션
    public delegate void KeyDownAction();
    //캐릭터가 범위 안에 들어왔을때, 나갔을때 액션
    public delegate void EnterAction();
    public delegate void OutAction();

    public KeyDownAction keydownaction;
    public EnterAction enteraction;
    public OutAction outaction;

    public GameObject EnterPopUp;


    //액션 추가, 삭제
    public void AddOutAction(OutAction action)
    {
        this.outaction += action;
    }

    public void DeleteOutAction(OutAction action)
    {
        this.outaction -= action;
    }

    public void AddEnterAction(EnterAction action)
    {
        this.enteraction += action;
    }

    public void DeleteEnterAction(EnterAction action)
    {
        this.enteraction -= action;
    }


    //주변에 플레이어가 있을때만 f를 눌르면 설정된 action을 실행한다.
    public void AddKeydownAction(KeyDownAction action, KeyCode key)
    {
        this.keydownaction += action;
        this.InteractionKey = key;
    }

    public void AddKeydownAction(KeyDownAction action)
    {
        this.keydownaction += action;
    }

    public void DeleteKeydownAction(KeyDownAction action)
    {
        this.keydownaction -= action;
    }

    //주변에 플레이어가 있는지 확인한다.
    public void CheckPlayer()
    {
        
        if (Time.time >= lastTime + current.CheckSecond)
        {
            lastTime = Time.time;
            RaycastHit2D hit;
            hit = Physics2D.CircleCast(this.transform.position, Circlerange.radius, new Vector2(1, 1), 0, PlayerLayer);
            //
            if (hit)
            {
                if(!current.PlayerEnter)
                {
                    //유저가 범위에 들어오면 한번만 실행
                    if (enteraction != null)
                    {
                        enteraction();
                    }

                }
                current.PlayerEnter = true;
            }
            else
            {
                if(current.PlayerEnter)
                {
                    if (enteraction != null)
                    {
                        outaction();
                    }

                }
                current.PlayerEnter = false;
            }
        }
    }
    
    //키 다운 감지
    public void CheckKeyDown()
    {
        if (current.PlayerEnter)
        {
            if (Input.GetKeyDown(InteractionKey))
            {
                if (keydownaction != null)
                {
                    keydownaction();
                }
            }
        }
    }

    //팝업을 보여주고 숨긴다.
    public void ShowPopUp()
    {
        if (EnterPopUp != null)
            EnterPopUp.SetActive(true);
    }

    public void ClosePopUp()
    {
        if (EnterPopUp != null)
            if (EnterPopUp.activeSelf)
                EnterPopUp.SetActive(false);

    }

    private void Awake()
    {
        EnterPopUp = transform.Find("EnterPopUp").gameObject;
        EnterPopUp.SetActive(false);
        Circlerange = GetComponentInChildren<CircleCollider2D>();
        AddEnterAction(ShowPopUp);
        AddOutAction(ClosePopUp);
    }


    void Update()
    {
        CheckPlayer();
        CheckKeyDown();
    }
}
