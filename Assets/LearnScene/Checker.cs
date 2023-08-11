using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Checker : MonoBehaviour
{
    public Button[]   Buttn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var Timern =Time.deltaTime;
      Debug.Log(Timern +"yes");  
    }




    public void OnClickBtn()
    {
       {
        foreach (Button button in Buttn)
        {
            if (button.gameObject == UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject)
            {
                // The button is currently pressed
                var Pickup =  button.colors.pressedColor;
                Debug.Log(Pickup);
            }
        }

        // No button is currently pressed or not found in the list
        // You can return a default color or null in this case
       
    
    }
}
}
