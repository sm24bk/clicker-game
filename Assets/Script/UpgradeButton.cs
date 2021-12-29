using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public DataController dataController;

    public Text upgradeDisplayer;
    public string upgradeName;

    public int goldByUpgrade;
    public int startGoldByUpgrade = 1;
   
    public int currentCost; //장비를 업그레이드 하기 위한 비용
    public int startCurrentCost = 1;

    public int level = 1;


    public float upgradePow = 2.14f; //레벨 업그레이들 할 때 마다  
    public float costPow = 3.14f; //레벨이 업그래이드 될 때 마다 비용 
    
   
    // Start is called before the first frame update
    void Start()
    {
        dataController.LoadUpgradeButton(this);
        UpdateUI(); //처음에 정보가 뜨게 ui 프로세스 호출

    }

    public void PurchaseUpgrade() //구매했을 때 onclick 이벤트로 작동
    {
        if (dataController.GetGold() >= currentCost) //가진 돈, 업그레이드현재 비용 비교
        {
            
            //업그레이드 클릭시 골드량 감소
            dataController.SubGold(currentCost);            //가격만큼 골드 감소
            level += 1;                                     //레벨 1 증가
            dataController.AddGoldPerClick(goldByUpgrade);  //클릭당 골드량 증가
            
            //클릭당 골드 변경된 부분을 저장하는 부분
            UpdateUpgrade(); //업그레이드 프로세스 호출
            UpdateUI(); //ui 프로세스 호출
            dataController.SaveUpgradeButton(this);

        }
    }

    public void UpdateUpgrade()
    {
        goldByUpgrade = startGoldByUpgrade * (int)Mathf.Pow(upgradePow, level); //클릭당 레벨 별 업그레이드 계산
        currentCost = startCurrentCost * (int)Mathf.Pow(costPow, level); //레벨 별 업그레이드 비용 계산
    }

    public void UpdateUI()
    {
        upgradeDisplayer.text = "부위이름 : " + upgradeName +"\n"+ "필요 비용 : "+ currentCost + "\n" + "레벨 : " +level + "\n" + "획득 가능 골드 : "+ goldByUpgrade; 
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
