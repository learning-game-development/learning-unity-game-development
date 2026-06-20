using UnityEngine;

namespace DapperDino.BuildingBlocks
{
    public class BelongsTo : MonoBehaviour
    {
        public GameObject Owner { get; private set; }

        public void Initialise(GameObject owner)
        {
            Owner = owner;
        }
    }
}
