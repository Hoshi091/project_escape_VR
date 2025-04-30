using UnityEngine;

public class GlowFade : MonoBehaviour
{
    public GameObject glowEffect;
    public float disableDistance = 3f;

    private Transform player;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogWarning("Player not found. Make sure the player GameObject has the 'Player' tag.");
        }
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(player.position, transform.position);

        if (distance < disableDistance)
        {
            if (glowEffect.activeSelf)
                glowEffect.SetActive(false);
        }
        else
        {
            if (!glowEffect.activeSelf)
                glowEffect.SetActive(true);
        }
    }
    void LateUpdate()
    {
        if (glowEffect != null)
        {
            glowEffect.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        }
    }
}
