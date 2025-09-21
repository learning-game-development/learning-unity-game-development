using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextAdventureGame
{
    public class Walrus : Enemy
    {
        // Start is called before the first frame update
        void Start()
        {
            Energy = 15;
            Attack = 3;
            Defence = 5;
            Gold = 30;
            Inventory.Add("Tooth");
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
