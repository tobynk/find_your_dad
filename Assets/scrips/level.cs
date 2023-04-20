using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level : MonoBehaviour
{
    public int levels;
    public int maxlevel=100;
    public int minlevel=1;
    public int exp=0;
    public int staringexp=500;
    public int requiredxp;
    // Start is called before the first frame update
    void Start()
    {
        levels=minlevel;
        requiredxp=staringexp*levels;
        
    }

    // Update is called once per frame
    void Update()
    {
        requiredxp=staringexp*levels;
        if (exp>requiredxp)
        {
            levels++;
            Debug.Log("level up");
            setexp(levels);
            exp=0;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            gainexp(100);
        }
        
    }

    void gainexp(int amount)
    {
        exp +=amount;
    }

    void setexp(int level)
    {
        requiredxp=staringexp*level;
    }
}
