using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Bear : MonoBehaviour
{
    public NavMeshAgent nav;
    public Transform target;
    public Transform startPos;
    public Animator bearAnimator;
    public Animator playerAnimator;
    
    bool isFollowing;

    public PlayerInput playerInput;

    public AudioClip chasing;
    public AudioClip attacking;
    public AudioClip playerHitted;
    AudioSource audioSource;
    bool isSoundPlayed;
    bool isAttackSoundPlayed;
    bool playerHittedSoundPlayed;

    void Awake()
    {
        this.audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if(distance <= 10f){
            // nav.isStopped = false;
            nav.SetDestination(target.position);
            bearAnimator.SetBool("isRun", true);
            // bearAnimator.SetBool(isIdle, false);
            isFollowing = true;
            FollowSoundPlay();
            // PlaySound("Chasing");
            if (distance <= 4f){
                playerInput.enabled = false;
                bearAnimator.SetBool("isAttack", true);
                AttackSoundPlay();
                StartCoroutine(WaitForEndGame());
            }
        } else{
            nav.SetDestination(startPos.position);
            isFollowing = false;
            isSoundPlayed = false;
            audioSource.Stop();
        }

        float stopDistance = Vector3.Distance(new Vector3(transform.position.x,0,transform.position.z), new Vector3(startPos.position.x, 0, startPos.position.z));
        
        if(!isFollowing && stopDistance<=2f) {
            bearAnimator.SetBool("isRun", false);
            nav.ResetPath();
        }
    }

    public IEnumerator WaitForEndGame()
    {
        yield return new WaitForSeconds(1f);
        PlayerHittedSoundPlay();
        playerAnimator.SetBool("isDying", true);
        yield return new WaitForSeconds(3f);
        Debug.Log("Game Over");
        SceneManager.LoadScene("GameOver");
    }

    public void FollowSoundPlay() {
        if (!isSoundPlayed) {
            audioSource.clip = chasing;
            audioSource.loop = true;
            audioSource.Play();
            isSoundPlayed = true;
        }
    }

    public void AttackSoundPlay() {
        if (!isAttackSoundPlayed) {
            audioSource.clip = attacking;
            audioSource.loop = false;
            audioSource.Play();
            isAttackSoundPlayed = true;
        }
    }

    public void PlayerHittedSoundPlay() {
        if (!playerHittedSoundPlayed) {
            audioSource.clip = playerHitted;
            audioSource.loop = false;
            audioSource.Play();
            playerHittedSoundPlayed = true;
        }
    }
}