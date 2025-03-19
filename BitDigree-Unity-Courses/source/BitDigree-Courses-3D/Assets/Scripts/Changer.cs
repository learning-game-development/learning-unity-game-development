using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changer : MonoBehaviour
{
    public GameObject[] tools;
    private int currentWeapon = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetWeaponActive();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            currentWeapon = 0;
            SetWeaponActive();
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)) {
            currentWeapon = 1;
            SetWeaponActive();
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)) {
            currentWeapon = 2;
            SetWeaponActive();
        }
    }

    void SetWeaponActive() {
        for (int i = 0; i < tools.Length; i++) {
            if (i != currentWeapon) {
                tools[i].SetActive(false);
            } else {
                tools[i].SetActive(true);
            }
        }
    }
}
