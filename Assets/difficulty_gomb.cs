using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class difficulty_gomb : MonoBehaviour,  IPointerClickHandler
{
    public Button button;
    private TextMeshProUGUI buttonText;
    public settings settings_object;
    

    void Start()
    {
        
        button = GetComponent<Button>();
        buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
        
        
        

        switch (settings_object.difficulty)
        {
            case 1: 
                buttonText.text = "Difficulty: Easy";
                break;
            case 2:
                buttonText.text = "Difficulty: Medium";
                break;
            case 3:
                buttonText.text = "Difficulty: Hard";
                break;
                
        }
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
        switch (settings_object.difficulty)
        {
            case 1: 
                buttonText.text = "Difficulty: Medium";
                settings_object.difficulty = 2;
                break;
            case 2:
                buttonText.text = "Difficulty: Hard";
                settings_object.difficulty = 3;
                break;
            case 3:
                buttonText.text = "Difficulty: Easy";
                settings_object.difficulty = 1;
                break;
                
        }
        
    }
    
    
}
