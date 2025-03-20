using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextAdventureGame
{
    public class Raccoon : Enemy
    {
        // Start is called before the first frame update
        void Start()
        {
            Energy = 10;
            //MaxEnergy = 10;
            Attack = 8;
            Defence = 3;
            Gold = 20;            
            Inventory.Add("Bandit Mask");
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
