using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class zene_kibe : MonoBehaviour, IPointerClickHandler
{

    
    public Button button;
    private TextMeshProUGUI buttonText;
    public settings settings_object;
    

    void Start()
    {
        
        button = GetComponent<Button>();
        buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
        

        
        if (settings_object.zene_switch)
        {
            buttonText.text = "Music: On";

        }
        else buttonText.text = "Music: Off";



    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
        if (settings_object.zene_switch)
        {
            buttonText.text = "Music: Off";
            settings_object.zene_switch = false;
        }
        else
        {
            buttonText.text = "Music: On";
            settings_object.zene_switch = true;
        }
    }
    
    

    
}