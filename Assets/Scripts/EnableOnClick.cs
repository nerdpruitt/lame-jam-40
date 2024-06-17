using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnClick : MonoBehaviour
{
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
    }

    public void OnClick(){
        if(menu.activeSelf == true){
            menu.SetActive(false);
            Time.timeScale = 1;
        }
        else{
            menu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
