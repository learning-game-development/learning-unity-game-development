using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popper : MonoBehaviour
{
    public int points = 1;
    public int clicksToPop = 5;
    public float scaleIncreasePerClick = 0.1f;
    public ScoreManager scoreManager;

    private void OnMouseDown() {
        clicksToPop -= 1;
        transform.localScale += Vector3.one * scaleIncreasePerClick;

        if (clicksToPop <= 0)
        {
            scoreManager.IncreaseScore(points);
            Destroy(gameObject);
        }
    }
}
