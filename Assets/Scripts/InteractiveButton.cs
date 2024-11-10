using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveButton : MonoBehaviour
{

    bool selected = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter()
    {
        selected = true;
        gameObject.GetComponent<Image>().color = Color.blue;
        Debug.Log("Object Selected");
    }

    public void OnPointerExit()
    {
        selected = false;
        gameObject.GetComponent<Image>().color = Color.red;
        Debug.Log("Object Unselected");
    }
}
