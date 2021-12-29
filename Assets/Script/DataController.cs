using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    // Start is called before the first frame update


    private static DataController instance;
    public static DataController GetInstance()
    {
        if(instance==null)
        {
            instance = FindObjectOfType<DataController>();
            
            if(instance==null)
            {
                GameObject container = new GameObject("DataController");

                instance = container.AddComponent<DataController>();
            }
        }
        return instance;
    }

    private ItemButton[] itemButtons;
    

    private int m_gold = 0;  //publicㅇ로 사용하면 다른 class에서도 불러와서 사용 
    private int m_goldPerClick = 0; //private로 사용하면 이 class에서 사용 가능
    //private int m_goldPerSec = 0;
    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
        m_gold = PlayerPrefs.GetInt("Gold");    //playerprefs 에 Gold라고 정의되어 있는 데이터를 로드
        m_goldPerClick = PlayerPrefs.GetInt("GoldPerClick", 1);   //playerprefs 에 GoldPerClick라고 정의되어 있는 데이터를 로드, 기본값 1 설정

        itemButtons = FindObjectsOfType<ItemButton>();
    }

    public void SetGold (int newGold)   // 골드량을 레지스트리에 저장하는 메소드
    {
        m_gold = newGold;
        PlayerPrefs.SetInt("Gold", m_gold); 
    }

    public void AddGold(int newGold)      // 골드량 증가를 처리하는 메소드
    {
        m_gold += newGold;
        SetGold(m_gold);
    }
    
    public void SubGold(int newGold)    //골드량 감소를 처리하는 메소드
    {
        m_gold -= newGold;
        SetGold(m_gold);
        Debug.Log(m_gold);

    }

    public int GetGold()    //얻은 골드량을 int 값으로 표시
    {
        return m_gold;      //m_gold값을 리턴
    }

    public void SetGoldPerClick(int newGoldPerClick)        //클릭당 골드 변화량
    {
        m_goldPerClick = newGoldPerClick;                       //m_goldperclick값을 newGoldPerClick 값에 넣어줌 
        PlayerPrefs.SetInt("GoldPerClick", m_goldPerClick);     //저장한 골드값을 GoldPerClick으로 츨력
    }

    public int GetGoldPerClick()
    {
        return m_goldPerClick;
    }


    public void AddGoldPerClick(int newGoldPerClick)
    {
        m_goldPerClick += newGoldPerClick;  //m_goldPerClick에 m_goldPerClick값을 출력
        SetGoldPerClick(m_goldPerClick);
    }

    public void LoadUpgradeButton(UpgradeButton upgradeButton)  //일단 버튼 하나 지정
    {
        string key = upgradeButton.upgradeName; //부위를 key로 지정
        upgradeButton.level = PlayerPrefs.GetInt(key + "_level", 1); //초기값을 1로 설정
        upgradeButton.goldByUpgrade = PlayerPrefs.GetInt(key + "_goldByUpgrade", upgradeButton.startGoldByUpgrade);
        upgradeButton.currentCost = PlayerPrefs.GetInt(key + "_cost", upgradeButton.startCurrentCost);  //초기 값을 불러옴
        
    }

    public void SaveUpgradeButton(UpgradeButton upgradeButton)
    {
        string key = upgradeButton.upgradeName; //부위를 key로 지정
        PlayerPrefs.SetInt(key + "_level", upgradeButton.level);    //레벨 값을 불러옴
        PlayerPrefs.SetInt(key + "_goldByUpgrade", upgradeButton.goldByUpgrade);
        PlayerPrefs.SetInt(key + "_cost", upgradeButton.currentCost);   //초기값에다가 새로 누른 값을 설정해두는 역할
    }


    public void LoadItemButton(ItemButton itemButton)
    {
        string key = itemButton.itemName;
        itemButton.level = PlayerPrefs.GetInt(key + "_level");
        itemButton.goldPerSec = PlayerPrefs.GetInt(key + "goldPerSec");
        itemButton.currentCost = PlayerPrefs.GetInt(key + "_cost", itemButton.startCurrentCost);

        if(PlayerPrefs.GetInt(key + "_isPurchased") ==1)
        {
            itemButton.isPurchased = true;
        }
        else
        {
            itemButton.isPurchased = false;
        }
    }

    public void SaveItemButton(ItemButton itemButton)
    {
        string key = itemButton.itemName;

        PlayerPrefs.SetInt(key + "_level", itemButton.level);
        PlayerPrefs.SetInt(key + "_goldPerSec", itemButton.goldPerSec);
        PlayerPrefs.SetInt(key + "_cost", itemButton.currentCost);

        if(itemButton.isPurchased == true)
        {
            PlayerPrefs.SetInt(key + "_isPurchased", 1);
        }
        else
        {
            PlayerPrefs.SetInt(key + "_isPurchased", 0);
        }
    }
    public int GetGoldPerSec()
    {
        int goldPerSec = 0;
        for(int i = 0; i<itemButtons.Length; i++)
        {
            goldPerSec += itemButtons[i].goldPerSec;
        }

        return goldPerSec;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
