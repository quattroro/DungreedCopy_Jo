using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////
///조민익 작업
///던전 안에 존재하는 오브젝트
/////////////////////////////////////////////////////////////////////
///
public class DungeonGear : MonoBehaviour
{
    public enum GearDir { Right,Left};

    public GameObject body;

    public CircleCollider2D coll;

    public float spinspeed;

    public GearDir spindirection;

    public bool NowSpin = false;
    private void Awake()
    {
        body = transform.Find("body").gameObject;
        coll = GetComponent<CircleCollider2D>();
        spinspeed *= (spindirection == GearDir.Right) ? 1 : -1;
    }


    private void OnEnable()
    {
        NowSpin = true;
    }

    private void OnDisable()
    {
        NowSpin = false;
    }

    public void GearSpin()
    {
        if(NowSpin)
        {
            body.transform.Rotate(new Vector3(0, 0, spinspeed * Time.deltaTime));
        }
    }

    void Update()
    {
        GearSpin();
    }
}
