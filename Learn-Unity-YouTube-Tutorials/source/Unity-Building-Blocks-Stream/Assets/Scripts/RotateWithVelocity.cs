using UnityEngine;

namespace DapperDino.BuildingBlocks
{
    public class RotateWithVelocity : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb = null;

        private void Update()
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }
    }
}
