using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModulesScript : MonoBehaviour
{
    public int modulus = 5;
    public int target = 100;

    // Start is called before the first frame update
    void Start()
    {
        for (int i  = 0; i < target; i++) {
            if (i % target == 0) {
                Debug.Log(i.ToString() + " is a multiple of " + modulus.ToString());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
