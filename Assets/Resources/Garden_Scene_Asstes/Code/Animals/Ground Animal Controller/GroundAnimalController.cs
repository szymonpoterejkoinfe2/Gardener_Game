using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class GroundAnimalController : MonoBehaviour
{
    [SerializeField]
    private AnimationClip[] animalAnimationClips;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        StartCoroutine(StartActivity());
    }

    private void Action()
    {
        float activityTime = Random.Range(5.0f, 15.0f);
        int activityType = Random.Range(0, animalAnimationClips.Length);
        StartCoroutine(PlayAndStopAnimation(animalAnimationClips[activityType], activityTime));
    }

    // Method to play an animation clip for a specified duration
    private IEnumerator PlayAndStopAnimation(AnimationClip clip, float duration)
    {
        PlayAnimation(clip);
        yield return new WaitForSeconds(duration);

        // Check if the animation is not looping and if it's over
        if (!clip.isLooping && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {

            Action();
        }
        else
        {
            // Otherwise, stop the animation
            animator.enabled = false;
        }
    }

    // Method to play an animation clip
    private void PlayAnimation(AnimationClip clip)
    {
        animator.enabled = true;
        animator.Play(clip.name);
    }

    // Coroutine to start activity
    private IEnumerator StartActivity()
    {
        while (true)
        {
            Action();
            yield return new WaitForSeconds(Random.Range(5f, 15f));
        }
    }
}

