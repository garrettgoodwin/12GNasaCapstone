using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scatter : MonoBehaviour
{
        public float minForce = 2f;
        public float maxForce = 5f;

        void Start()
        {
            // Iterate over each child (piece of the broken object)
            foreach (Transform piece in transform)
            {
                // Add a random force to each piece
                var rb = piece.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    Vector2 randomDirection = Random.insideUnitCircle.normalized;
                    float randomForce = Random.Range(minForce, maxForce);
                    rb.AddForce(randomDirection * randomForce, ForceMode2D.Impulse);
                }
            }
        }
    }
