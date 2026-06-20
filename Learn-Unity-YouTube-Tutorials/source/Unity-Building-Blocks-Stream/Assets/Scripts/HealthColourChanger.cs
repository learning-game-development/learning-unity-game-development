using UnityEngine;

namespace DapperDino.BuildingBlocks
{
    public class HealthColourChanger : MonoBehaviour
    {
        [SerializeField] private HealthBehaviour healthBehaviour = null;
        [SerializeField] private Color fullHealthColour = new Color(0f, 1f, 0f, 1f);
        [SerializeField] private Color noHealthColour = new Color(1f, 0f, 0f, 1f);
        [SerializeField] private Renderer[] renderers = new Renderer[0];

        private void Start()
        {
            HandleHealthChanged(healthBehaviour.Health, healthBehaviour.MaxHealth);

            healthBehaviour.OnHealthChanged += HandleHealthChanged;
        }

        private void OnDestroy() => healthBehaviour.OnHealthChanged -= HandleHealthChanged;

        private void HandleHealthChanged(int health, int maxHealth)
        {
            foreach (var renderer in renderers)
            {
                renderer.material.SetColor("_BaseColor", Color.Lerp(noHealthColour, fullHealthColour, (float)health / maxHealth));
            }
        }
    }
}
