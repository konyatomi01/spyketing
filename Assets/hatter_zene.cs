using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hatter_zene : MonoBehaviour
{
    public AudioSource hatterzenelo;
    public settings Settings;
    // Start is called before the first frame update
    void Start()
    {
        hatterzenelo = GetComponent<AudioSource>();
        Settings = GameObject.FindWithTag("settings").GetComponent<settings>();
        if (!Settings.zene_switch) hatterzenelo.volume = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
