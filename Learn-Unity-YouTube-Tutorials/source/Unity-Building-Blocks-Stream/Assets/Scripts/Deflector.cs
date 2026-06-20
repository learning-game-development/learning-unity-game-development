using UnityEngine;

namespace DapperDino.BuildingBlocks
{
    public class Deflector : MonoBehaviour
    {
        [SerializeField] private float deflectionSpeed = 20f;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<BelongsTo>(out var belongsTo))
            {
                return;
            }

            if (!other.TryGetComponent<Rigidbody>(out var rb))
            {
                return;
            }

            rb.useGravity = false;
            rb.velocity = (belongsTo.Owner.transform.position - other.transform.position).normalized * deflectionSpeed;
        }
    }
}
