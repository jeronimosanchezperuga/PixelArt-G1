using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerKnockback : MonoBehaviour
{
    public float knockbackForce = 10f;
    public float knockbackDuration = 0.5f;
    private Rigidbody2D rb;
    private bool isKnockedBack = false;
    // Reference to a script handling player movement (you'd need this in your project)
    private ControlJugador playerMovement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<ControlJugador>(); // Get the movement script
    }

    // Call this function from the enemy/spike script when a hit occurs
    public void ApplyKnockback(Transform damageSourceTransform)
    {
        if (!isKnockedBack)
        {
            StartCoroutine(KnockbackCoroutine(damageSourceTransform));
        }
    }

    IEnumerator KnockbackCoroutine(Transform damageSourceTransform)
    {
        isKnockedBack = true;

        // Calculate direction away from the source
        Vector2 difference = (transform.position - damageSourceTransform.position).normalized;
        Vector2 force = difference * knockbackForce;

        rb.velocity = Vector2.zero; // Reset current velocity

        yield return new WaitForFixedUpdate(); // Wait for one frame to ensure physics updates correctly

        // Apply the force
        if (rb != null)
        {
            rb.AddForce(force, ForceMode2D.Impulse);
        }

        // Optional: temporarily disable player movement
        if (playerMovement != null) playerMovement.enabled = false;

        // Wait for the specified duration
        yield return new WaitForSeconds(knockbackDuration);

        // Reset state
        isKnockedBack = false;

        // Re-enable player movement
        if (playerMovement != null) playerMovement.enabled = true;
    }
}
