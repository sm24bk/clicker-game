//���� �����̽��� ȣ��(�������� Ŭ���� �� ����ü)
using System.Collections;//�ڷᱸ��
using System.Collections.Generic;//�ڷᱸ��
using UnityEngine;  //����Ƽ���� �����ϴ� api ȣ���Ͽ� ��밡��

public class ClickButton : MonoBehaviour
    //MonoBehavior ����Ƽ���� ������Ʈ�鿡�� �޽��� ����
{
    public DataController dataController;   //datacontroller�� �ν��Ͻ�
    
    public void onClick() 
        //��ư�� Ŭ������ �� ����Ǵ� �޼ҵ�
    {
        int goldPerClick = dataController.GetGoldPerClick();
        //Ŭ���� �� ����  ��带 dataController ��ũ��Ʈ���� �޼��� ���� �ҷ�����
       
        dataController.AddGold(goldPerClick);
        //Ŭ���� �� ���� goldperPerClick ��ŭ AddGold�ϱ�
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
