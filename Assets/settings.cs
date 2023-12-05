using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settings : MonoBehaviour
{
    public settings settings_object;
    
    public static settings singleton = null;
    
    public bool zene_switch = true;

    public int difficulty = 1;
    // Start is called before the first frame update
    void Start()
    {
        settings_object = GetComponent<settings>();
        DontDestroyOnLoad(settings_object);
        if(singleton == null)
        {
            singleton = settings_object;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
