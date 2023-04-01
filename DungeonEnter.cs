using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////
///조민익 작업
///마을 씬에서 던전씬으로 이동 해줍니다.
///이동 하기 전에 캐릭터의 정보를 한번 저장해줍니다.
/////////////////////////////////////////////////////////////////////


public class DungeonEnter : MonoBehaviour
{
    public LayerMask playerlayer;

    public GameObject DungeonEat;

    public GameObject playerobj = null;

    void Start()
    {
        DungeonEat.SetActive(false);
    }

    //캐릭터가 텔레포트 지점으로 오면 애니메이션 객체를 출력해주고 던전 씬으로 이동 해준다.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            DungeonEat.SetActive(true);
            Vector3 temp = new Vector3(collision.transform.position.x, DungeonEat.transform.position.y);
            DungeonEat.transform.position = temp;
            playerobj = collision.gameObject;
            Save_Inventory_Info();
            SoundManager.Instance.bgmSource.PlayOneShot(SoundManager.Instance.UI_Audio[4]);
            Invoke("EnterDungeon", 1.4f);
        }
    }

    //던전 씬으로 이동 해준다.
    public void EnterDungeon()
    {
        if (playerobj != null)
        {
            DontDestroyOnLoad(playerobj);
            SceneManager.LoadScene("Main_Dungeon_Scene");
        }

    }

    //캐릭어 아이템 정보 저장
    void Save()
    {
        Player player = playerobj.GetComponent<Player>();

        for (int i = 0; i < Inventory.Instance.slots.Length; i++)
        {
            if (Inventory.Instance.slots[i].item != null)
            {
                player.slots[i] = Inventory.Instance.slots[i].item.item.itemCode;
            }
        }
        for (int i = 0; i < Inventory.Instance.equipment_1Slot.Length; i++)
        {
            if (Inventory.Instance.equipment_1Slot[i].item != null)
            {
                player.equip_Slots_1[i] = Inventory.Instance.equipment_1Slot[i].item.item.itemCode;
            }
        }
        for (int i = 0; i < Inventory.Instance.equipment_2Slot.Length; i++)
        {
            if (Inventory.Instance.equipment_2Slot[i].item != null)
            {
                player.equip_Slots_2[i] = Inventory.Instance.equipment_2Slot[i].item.item.itemCode;
            }
        }
        for (int i = 0; i < Inventory.Instance.Acc_Slot.Length; i++)
        {
            if (Inventory.Instance.Acc_Slot[i].item != null)
            {
                player.acc_Slots[i] = Inventory.Instance.Acc_Slot[i].item.item.itemCode;
            }
        }
    }

    //던전이 이동될때 씬이 이동되기 때문에 이동하기 전에 캐릭터의 정보를 저장해 준다.
    void Save_Inventory_Info()
    {
        Save();

        Player player = playerobj.GetComponent<Player>();

        string slotsArr = ""; // 문자열 생성
        string equipSlots1Arr = ""; // 문자열 생성
        string equipSlots2Arr = ""; // 문자열 생성
        string accSlotsArr = ""; // 문자열 생성

        for (int i = 0; i < player.slots.Length; i++) // 배열과 ','를 번갈아가며 tempStr에 저장
        {
            slotsArr = slotsArr + player.slots[i];
            if (i < player.slots.Length - 1) // 최대 길이의 -1까지만 ,를 저장
            {
                slotsArr = slotsArr + ",";
            }
        }

        for (int i = 0; i < player.equip_Slots_1.Length; i++) // 배열과 ','를 번갈아가며 tempStr에 저장
        {
            equipSlots1Arr = equipSlots1Arr + player.equip_Slots_1[i];
            if (i < player.equip_Slots_1.Length - 1) // 최대 길이의 -1까지만 ,를 저장
            {
                equipSlots1Arr = equipSlots1Arr + ",";
            }
        }

        for (int i = 0; i < player.equip_Slots_2.Length; i++) // 배열과 ','를 번갈아가며 tempStr에 저장
        {
            equipSlots2Arr = equipSlots2Arr + player.equip_Slots_2[i];
            if (i < player.equip_Slots_2.Length - 1) // 최대 길이의 -1까지만 ,를 저장
            {
                equipSlots2Arr = equipSlots2Arr + ",";
            }
        }

        for (int i = 0; i < player.acc_Slots.Length; i++) // 배열과 ','를 번갈아가며 tempStr에 저장
        {
            accSlotsArr = accSlotsArr + player.acc_Slots[i];
            if (i < player.acc_Slots.Length - 1) // 최대 길이의 -1까지만 ,를 저장
            {
                accSlotsArr = accSlotsArr + ",";
            }
        }

        PlayerPrefs.SetString("slotsList", slotsArr);
        PlayerPrefs.SetString("equipSlots1List", equipSlots1Arr);
        PlayerPrefs.SetString("equipSlots2List", equipSlots2Arr);
        PlayerPrefs.SetString("accSlotsList", accSlotsArr);
    }

}
