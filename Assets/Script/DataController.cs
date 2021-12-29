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
    

    private int m_gold = 0;  //public���� ����ϸ� �ٸ� class������ �ҷ��ͼ� ��� 
    private int m_goldPerClick = 0; //private�� ����ϸ� �� class���� ��� ����
    //private int m_goldPerSec = 0;
    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
        m_gold = PlayerPrefs.GetInt("Gold");    //playerprefs �� Gold��� ���ǵǾ� �ִ� �����͸� �ε�
        m_goldPerClick = PlayerPrefs.GetInt("GoldPerClick", 1);   //playerprefs �� GoldPerClick��� ���ǵǾ� �ִ� �����͸� �ε�, �⺻�� 1 ����

        itemButtons = FindObjectsOfType<ItemButton>();
    }

    public void SetGold (int newGold)   // ��差�� ������Ʈ���� �����ϴ� �޼ҵ�
    {
        m_gold = newGold;
        PlayerPrefs.SetInt("Gold", m_gold); 
    }

    public void AddGold(int newGold)      // ��差 ������ ó���ϴ� �޼ҵ�
    {
        m_gold += newGold;
        SetGold(m_gold);
    }
    
    public void SubGold(int newGold)    //��差 ���Ҹ� ó���ϴ� �޼ҵ�
    {
        m_gold -= newGold;
        SetGold(m_gold);
        Debug.Log(m_gold);

    }

    public int GetGold()    //���� ��差�� int ������ ǥ��
    {
        return m_gold;      //m_gold���� ����
    }

    public void SetGoldPerClick(int newGoldPerClick)        //Ŭ���� ��� ��ȭ��
    {
        m_goldPerClick = newGoldPerClick;                       //m_goldperclick���� newGoldPerClick ���� �־��� 
        PlayerPrefs.SetInt("GoldPerClick", m_goldPerClick);     //������ ��尪�� GoldPerClick���� ����
    }

    public int GetGoldPerClick()
    {
        return m_goldPerClick;
    }


    public void AddGoldPerClick(int newGoldPerClick)
    {
        m_goldPerClick += newGoldPerClick;  //m_goldPerClick�� m_goldPerClick���� ���
        SetGoldPerClick(m_goldPerClick);
    }

    public void LoadUpgradeButton(UpgradeButton upgradeButton)  //�ϴ� ��ư �ϳ� ����
    {
        string key = upgradeButton.upgradeName; //������ key�� ����
        upgradeButton.level = PlayerPrefs.GetInt(key + "_level", 1); //�ʱⰪ�� 1�� ����
        upgradeButton.goldByUpgrade = PlayerPrefs.GetInt(key + "_goldByUpgrade", upgradeButton.startGoldByUpgrade);
        upgradeButton.currentCost = PlayerPrefs.GetInt(key + "_cost", upgradeButton.startCurrentCost);  //�ʱ� ���� �ҷ���
        
    }

    public void SaveUpgradeButton(UpgradeButton upgradeButton)
    {
        string key = upgradeButton.upgradeName; //������ key�� ����
        PlayerPrefs.SetInt(key + "_level", upgradeButton.level);    //���� ���� �ҷ���
        PlayerPrefs.SetInt(key + "_goldByUpgrade", upgradeButton.goldByUpgrade);
        PlayerPrefs.SetInt(key + "_cost", upgradeButton.currentCost);   //�ʱⰪ���ٰ� ���� ���� ���� �����صδ� ����
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
