using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextAdventureGame
{
    public class Enemy : Character
    {
        public override void TakeDamage(int amount)
        {
            base.TakeDamage(amount);
            Debug.Log("This also happens, but only on enemy! not other characters.");
        }
        
        public override void Die()
        {
            Debug.Log("Character died, was enemy.");
        }
    }
}
