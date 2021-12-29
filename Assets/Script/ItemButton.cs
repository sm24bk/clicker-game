using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemButton : MonoBehaviour
{
    public DataController dataController;

    public Text itemDisplayer;
    public string itemName;
    public int level;
    public int currentCost; //���籸�Ժ��
    public int startCurrentCost;    //�ʱ� ���� ���
    public int goldPerSec;  //�ʴ� ��� ȹ�淮
    public int startGoldPerSec;
    public float costPow = 2.14f;   //���� ���
    public float upgradePow = 1.14f;    //���׷��̵� ���
    public bool isPurchased = false;    //���Կ���

    // Start is called before the first frame update
    void Start()
    {
        dataController.LoadItemButton(this);
        StartCoroutine("AddGoldLoop");
        UpdateUI();
    }


    public void PurchaseItem()
    {
        if(dataController.GetGold() >= currentCost)
        {
            isPurchased = true;     //���� �ؾ� �� �ڵ�
            dataController.SubGold(currentCost);
            level += 1;
            
            UpdateItem();
            UpdateUI();
            dataController.SaveItemButton(this);
        }
    }

    IEnumerator AddGoldLoop()       //���� ����
    {
        while(true)                 
        {
            if(isPurchased)
            {
                dataController.AddGold(goldPerSec);
            }
            yield return new WaitForSeconds(1.0f);      //���ϵ� ��(1�ʸ���) ���� ����
        }
    }

    public void UpdateItem()
    {
        goldPerSec = goldPerSec + startGoldPerSec * (int)Mathf.Pow(upgradePow, level);
        currentCost = currentCost + startCurrentCost * (int)Mathf.Pow(costPow, level);
    }

    public void UpdateUI()
    {
        itemDisplayer.text = "�������̸� : "+ itemName + "\n" + "���� : " + level + "\n" + "���ź�� : " + currentCost + "\n" + "�ʴ���ȹ�� : " + goldPerSec + "\n" + "���ſ��� : " + isPurchased;
    }






    

    // Update is called once per frame
    void Update()
    {
        
    }
}
