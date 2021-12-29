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
    public int currentCost; //현재구입비용
    public int startCurrentCost;    //초기 구입 비용
    public int goldPerSec;  //초당 골드 획득량
    public int startGoldPerSec;
    public float costPow = 2.14f;   //구입 비용
    public float upgradePow = 1.14f;    //업그레이드 비용
    public bool isPurchased = false;    //구입여부

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
            isPurchased = true;     //주의 해야 할 코드
            dataController.SubGold(currentCost);
            level += 1;
            
            UpdateItem();
            UpdateUI();
            dataController.SaveItemButton(this);
        }
    }

    IEnumerator AddGoldLoop()       //병렬 수행
    {
        while(true)                 
        {
            if(isPurchased)
            {
                dataController.AddGold(goldPerSec);
            }
            yield return new WaitForSeconds(1.0f);      //리턴될 때(1초마다) 까지 수행
        }
    }

    public void UpdateItem()
    {
        goldPerSec = goldPerSec + startGoldPerSec * (int)Mathf.Pow(upgradePow, level);
        currentCost = currentCost + startCurrentCost * (int)Mathf.Pow(costPow, level);
    }

    public void UpdateUI()
    {
        itemDisplayer.text = "아이템이름 : "+ itemName + "\n" + "레벨 : " + level + "\n" + "구매비용 : " + currentCost + "\n" + "초당골드획득 : " + goldPerSec + "\n" + "구매여부 : " + isPurchased;
    }






    

    // Update is called once per frame
    void Update()
    {
        
    }
}
