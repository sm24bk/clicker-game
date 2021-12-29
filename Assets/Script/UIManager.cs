using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text goldDisplayer;
    public Text goldPerClickDisplayer;
    public Text goldPerSec;
    public DataController dataController;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        goldDisplayer.text = "Gold" + DataController.GetInstance().GetGold();
        goldPerClickDisplayer.text = "Gold Per Click : " + dataController.GetGoldPerClick();
        goldPerSec.text = "Gold Per Sec : " + DataController.GetInstance().GetGoldPerSec();
    }
}
