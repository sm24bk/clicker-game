//네임 스페이스를 호출(여러가지 클래스 및 구조체)
using System.Collections;//자료구조
using System.Collections.Generic;//자료구조
using UnityEngine;  //유니티에서 제공하는 api 호출하여 사용가능

public class ClickButton : MonoBehaviour
    //MonoBehavior 유니티에서 컴포넌트들에게 메시지 전달
{
    public DataController dataController;   //datacontroller를 인스턴스
    
    public void onClick() 
        //버튼을 클릭했을 때 실행되는 메소드
    {
        int goldPerClick = dataController.GetGoldPerClick();
        //클릭할 때 마다  골드를 dataController 스크립트에서 메서드 값을 불러오기
       
        dataController.AddGold(goldPerClick);
        //클릭할 때 마다 goldperPerClick 만큼 AddGold하기
    }
        
        
        
    /*// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
