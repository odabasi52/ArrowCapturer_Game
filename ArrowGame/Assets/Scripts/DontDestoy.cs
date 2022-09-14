using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestoy : MonoBehaviour
{
    static DontDestoy instance;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);           
        }


        else
        {         
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
            
    }

}
