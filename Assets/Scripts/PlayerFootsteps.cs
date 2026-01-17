using System.Collections;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    public AudioClip footstep;

    private PlayerMovement movement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movement = GetComponent<PlayerMovement>();
        StartCoroutine(PlayFootsteps());
    }

    IEnumerator PlayFootsteps()
    {
        while (true)
        {
            if (movement.move.magnitude > 0.1)
            { 
                AudioManager.instance.PlaySFX(footstep);
            }

            yield return new WaitForSeconds(0.35f);
        }
    }
}
