using UnityEngine;

namespace DapperDino.BuildingBlocks
{
    public class Oscillator : MonoBehaviour
    {
        [SerializeField] private float amplitude = 1f;
        [SerializeField] private float speed = 1f;
        [SerializeField] private Vector3 axis = new Vector3();

        private Vector3 startingPos;

        private void Start()
        {
            Vector3 position = transform.position;
            startingPos = position;
        }

        private void Update()
        {
            transform.position = startingPos + axis * Mathf.Cos(Time.time * speed / Mathf.PI) * amplitude;
        }
    }
}
