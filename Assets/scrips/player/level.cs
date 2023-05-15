using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class level : MonoBehaviour
{
    public int levels=1;
    public int maxlevel=100;
    public int minlevel=1;
    public int exp=0;
    public int staringexp=500;
    public int requiredxp;
    public TextMeshProUGUI leveltext;
    public takehealth health;
    public int enenmycount;
    private int gainep;
    // Start is called before the first frame update
    void Start()
    {

        levels=minlevel;
        requiredxp=staringexp*levels;
        Updatlevl();
        health= GetComponent<takehealth>();
        health.addmoreheatlh();
        
    }

    // Update is called once per frame
    void Update()
    {
        Updatlevl();
        requiredxp=staringexp*levels;
        if (exp>=requiredxp)
        {
            levels++;
            Debug.Log("level up");
            setexp(levels);
            exp=0;
            health.addmoreheatlh();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            gainexp(100000000);
        }


        
    }
    public void roundup()
    {
        gainep=requiredxp/2;
        gainexp(gainep);
    }

    public void gainexp(int amount)
    {
        exp +=amount;
        Updatlevl();
    }

    void setexp(int level)
    {
        requiredxp=staringexp*level;
    }

    public void Updatlevl()
    {
        leveltext.text="lv."+levels;
    }
    void OnCollisionEnter(Collision collision)
    {
        // check if the collided object has a "Player" tag
        if (collision.gameObject.CompareTag("exp"))
        {
            gainexp(100);
            Destroy(collision.gameObject);
            // Debug.Log("you have gain"+"100"+levels);
        }
    }
}
