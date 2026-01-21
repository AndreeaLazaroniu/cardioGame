using UnityEngine;

public class HeartContiniousRotation : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 50, 0);
    public AudioClip heartBeat;
    public float beatInterval = 1.0f; // Seconds between beats
    private float timer;

    void Update()
    {
        // 1. Smooth rotation independent of frame rate
        transform.Rotate(rotationSpeed * Time.deltaTime);

        // 2. Safe Audio Timer (Replaces the while loop)
        timer += Time.deltaTime;
        if (timer >= beatInterval)
        {
            // Only play if references are assigned to avoid errors
            if (heartBeat != null && AudioManager.instance != null)
            {
                AudioManager.instance.PlaySFX(heartBeat);
            }
            timer = 0f; // Reset the timer
        }
    }
}
