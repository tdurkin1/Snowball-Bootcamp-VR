using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] int targetScore = 5;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.GetComponent<Snowball>())
        {
            Debug.Log("hit");
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            scoreManager.addScore(targetScore);
        }

    }
}
