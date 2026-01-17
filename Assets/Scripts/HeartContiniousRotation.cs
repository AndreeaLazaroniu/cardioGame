using UnityEngine;

public class HeartContiniousRotation : MonoBehaviour
{
    // Adjust these values in the Inspector to change speed and axis
    public Vector3 rotationSpeed = new Vector3(0, 50, 0);

    public AudioClip heartBeat;
    public AudioSource directSource;

    // Timer variables
    public float beatInterval = 1.0f; // Seconds between beats
    private float timer;

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
        timer += Time.deltaTime;

        if (timer >= beatInterval)
        {
            Debug.Log("Beat triggered!");

            // Try playing directly from a component on the heart
            if (directSource != null && heartBeat != null)
            {
                directSource.PlayOneShot(heartBeat);
            }

            timer = 0f;
        }
    }
   }
