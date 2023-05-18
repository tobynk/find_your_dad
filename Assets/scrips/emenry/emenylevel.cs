using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class emenylevel : MonoBehaviour
{
    public int levels=1;
    public int minlevel=1;
    public spawner spawerScript;
    // public TextMeshProUGUI leveltext;
    // public int enenmycount;
    // private int gainep;
    // Start is called before the first frame update
    void Start()
    {

        levels=minlevel;
        spawerScript = GameObject.FindObjectOfType<spawner>();

    }

    // Update is called once per frame
    void Update()
    {
        updateroudnd();
    }
    void updateroudnd()
    {
        levels =spawerScript.wavenumber*2;
    }

    // public void Updatlevl()
    // {
    //     leveltext.text="lv."+levels;
    // }
}
