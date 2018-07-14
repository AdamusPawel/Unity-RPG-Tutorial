using UnityEngine;

public class Interactable : MonoBehaviour
{

    public float radius = 3f;

    bool isFocus = false;
    bool hasInteracted = false;

    Transform player;

    void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radius)
            {
                Debug.Log("INTERACT");
                hasInteracted = true;
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefcused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
