using UnityEngine;

namespace DapperDino.BuildingBlocks
{
    public class DestroyAfterTime : MonoBehaviour
    {
        [SerializeField] private float duration = 5f;

        private void Start() => Destroy(gameObject, duration);
    }
}
