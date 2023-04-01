using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////
///������ �۾�
///�̴ϸ� �Դϴ�.
///�̴ϸʵ� Ÿ�ϵ�� �̷���� �ֽ��ϴ�. ��������� �̴ϸ��� ����� �°�
///��ҽ�Ű�� ȭ�� ũ�⿡ �°� �ø��� �����ؼ� �����ݴϴ�.
///��� Ÿ�� �������� MapManager���� �ʱ�ȭ�� �̴ϸʿ� �Ѱ��ݴϴ�.
/////////////////////////////////////////////////////////////////////
public class MinimapTile : MonoBehaviour
{
    public enum MinimapElement { BackGround, Wall, Moveable, Door, Player, Monster, ElementMax };

    [SerializeField]
    private MinimapElement tiletype;

    public Sprite[] ElementSprite;

    public Sprite PlayerSprite;

    public Sprite EmenySprite;

    public bool IsPlayer;
    //public Transform player;
    public bool IsMonster;

    public Image image;

    Vector2Int index;

    Vector3 worldpos;



    public MinimapElement p_tiletype
    {
        get
        {
            return tiletype;
        }
        set
        {
            tiletype = value;
            image.sprite = ElementSprite[(int)value];
        }

    }

    private void Awake()
    {
        image = GetComponent<Image>();
    }

}
