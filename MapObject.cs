using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




/////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////
///조민익 작업
///맵에 있는 박스나, 책상 같은 작은 오브젝트들 입니다.
///캐릭터나 몬스터와 충돌하면 작은 조각들로 부서지고 
///일정 시간 뒤에 사라집니다.
/////////////////////////////////////////////////////////////////////

public class MapObject : MonoBehaviour
{
    public enum ObjectType { Destructible, Indestructible };//파괴가능/파괴 불가능
    public ObjectType type;

    //public Sprite[] Particles;

    public List<Sprite> particles = new List<Sprite>();

    public List<GameObject> particlesobj = new List<GameObject>();

    public GameObject particle;

    public BoxCollider2D coll;

    public bool isdestroy;

    public bool SettingOver = false;

    //public LayerMask groundmask;

    private void OnCollisionEnter(Collision collision)
    {
        if(SettingOver)
        {
            if (!isdestroy)
            {
                for (int i = 0; i < particlesobj.Count; i++)
                {
                    particlesobj[i].SetActive(true);
                    particlesobj[i].transform.position = this.transform.position;
                    Destroy(particlesobj[i], 10f);
                }
                this.gameObject.SetActive(false);
                Destroy(this.gameObject, 10f);
                isdestroy = true;
                
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (SettingOver)
        {
            if (!isdestroy)
            {
                if (collision.gameObject.layer != LayerMask.NameToLayer("Wall") && collision.gameObject.layer != LayerMask.NameToLayer("Moveable"))
                {
                    for (int i = 0; i < particlesobj.Count; i++)
                    {
                        particlesobj[i].SetActive(true);
                        particlesobj[i].transform.position = this.transform.position;
                        Destroy(particlesobj[i], 10f);
                    }
                    this.gameObject.SetActive(false);
                    Destroy(this.gameObject, 10f);
                    isdestroy = true;
                    
                }

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (SettingOver)
        {
            if (!isdestroy)
            {
                if (collision.gameObject.layer != LayerMask.NameToLayer("Wall") && collision.gameObject.layer != LayerMask.NameToLayer("Moveable"))
                {
                    for (int i = 0; i < particlesobj.Count; i++)
                    {
                        particlesobj[i].SetActive(true);
                        particlesobj[i].transform.position = this.transform.position;
                        Destroy(particlesobj[i], 10f);
                    }
                    this.gameObject.SetActive(false);
                    Destroy(this.gameObject, 10f);
                    isdestroy = true;
                    
                }

            }
        }
    }

    public void CheckCollision()
    {

    }

    public void InitSetting()
    {
        if (type==ObjectType.Destructible)
        {
            for (int i=0;i<particles.Count;i++)
            {
                GameObject obj = GameObject.Instantiate(particle);
                
                obj.GetComponent<SpriteRenderer>().sprite = particles[i];
                //obj.transform.parent = this.transform;
                obj.SetActive(false);
                particlesobj.Add(obj);
            }
        }
        particle.SetActive(false);
        isdestroy = false;
        SettingOver = true;
    }

    private void Awake()
    {
        particle = transform.Find("Particle").gameObject;
        coll = GetComponent<BoxCollider2D>();
        InitSetting();

    }
}
