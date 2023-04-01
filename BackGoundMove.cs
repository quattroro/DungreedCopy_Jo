using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////
///조민익 작업
///메인 마을 에서 뒤에 백그라운드 배경이 캐릭터 이동에 따라 이동하도록 해줍니다.
///캐릭터가 모두 이동한 뒤에 따라서 이동하도록 하기 위해 LateUpdate에서 동작해 줍니다.
/////////////////////////////////////////////////////////////////////



public class BackGoundMove : MonoBehaviour
{
    public BaseStage basestage;

    public Transform playerpos;

    public Vector3 MapCenterPos;

    public Transform BackGround;

    public float MoveSpeed;

    public Vector3 LastPlayerPos;

    public Vector3 direction;

    public bool SettingOver = false;

    public Vector2 renderersize;

    public Vector2 renderercenter;

    //플레이어도 화면 중앙에 있다고 치고 있다가 플레이어가 감지되면 그때 플레이어의 위치에 따라 움직인다.플레이어가 1움직일 동안 백그라운드는 0.1만큼 움직인다.
    private void Awake()
    {
        basestage = GetComponentInParent<BaseStage>();
        playerpos = basestage.playerobj.transform;
        
        renderersize = this.GetComponent<SpriteRenderer>().bounds.size;
    }


    void LateUpdate()
    {
        if (basestage.NowPlayerEnter == true)
        {

            if (playerpos.position != LastPlayerPos)
            {
                Vector3 nowpos = transform.position;
                direction = playerpos.position - LastPlayerPos;
                Vector3 temp = transform.position;
                temp = temp + (direction * MoveSpeed);
                
                if(IsMoveAble(temp, renderersize))
                {
                    transform.position = temp;
                }
                LastPlayerPos = playerpos.position;
            }
        }
    }

    //움직일 수 있으면 true 못움직이면 flase
    public bool IsMoveAble(Vector3 center, Vector2 size)
    {
        bool flag = true;
        Vector3 bottomleft = basestage.bottomleft.position;
        Vector3 topright = basestage.topright.position;
        if (center.x - size.x <= bottomleft.x || center.y - size.y <= bottomleft.y || center.x + size.x >= topright.x || center.y + size.y >= topright.y)
        {
            flag = false;
        }
        return flag;
    }

}
