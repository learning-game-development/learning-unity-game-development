using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace DapperDino.BuildingBlocks
{
    public class LaunchProjectile : MonoBehaviour
    {
        [SerializeField] private GameObject owner = null;
        [SerializeField] private GameObject projectilePrefab = null;
        [SerializeField] private Transform spawnPoint = null;
        [SerializeField] private Vector3 initialVelocity = new Vector3();

        public void Launch(CallbackContext ctx)
        {
            if (!ctx.performed) { return; }

            GameObject projectileInstance = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);

            if (projectileInstance.TryGetComponent<Rigidbody>(out var rb))
            {
                rb.velocity = spawnPoint.TransformDirection(initialVelocity);
            }

            if(projectileInstance.TryGetComponent<BelongsTo>(out var belongsTo))
            {
                belongsTo.Initialise(owner);
            }
        }
    }
}
