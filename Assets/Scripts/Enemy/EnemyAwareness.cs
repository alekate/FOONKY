using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAwareness : MonoBehaviour
{
    public float awarenessRadius = 15f;
    public float followingRadius = 30f;
    private Transform playerTransform;
    public Animator enemyAnim;
    public bool isAggro;

    public float audioPlayInterval = 5f; // Adjust this value as needed
    public float delayBetweenClips = 2f; // Adjust this value as needed
    private float timeSinceLastAudioPlay;

    public AudioSource audioSource;
    public AudioClip clip;

    private void Start()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        GetComponentInChildren<Animation>();
        //audioSource = GetComponent<AudioSource>(); 
        //audioSource.clip = clip;
        timeSinceLastAudioPlay = 0f; 
    }

    private void Update()
    {
        enemyAnim.SetBool("isAggro", isAggro);

        var dist = Vector3.Distance(transform.position, playerTransform.position);

        if (dist < awarenessRadius)
        {
            isAggro = true;
            if (Time.time - timeSinceLastAudioPlay >= audioPlayInterval)
            {
                StartCoroutine(PlayAudioWithDelay());
            }
        }
        else
        {
            isAggro = false;
            audioSource.Stop(); // Stop playing the audio clip when the player is out of range
        }
    }

    private IEnumerator PlayAudioWithDelay()
    {
        audioSource.PlayOneShot(clip);
        timeSinceLastAudioPlay = Time.time;
        yield return new WaitForSeconds(delayBetweenClips);
    }
}