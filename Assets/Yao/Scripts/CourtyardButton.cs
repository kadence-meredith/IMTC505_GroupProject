using System.Collections;
using UnityEngine;

public class CourtyardButton : MonoBehaviour
{
    [SerializeField] private ParticleSystem confetti;
    [SerializeField] private Transform buttonTop;
    private Vector3 startPosition;
    private bool isPlaying;

    private void Awake()
    {
        startPosition = buttonTop.localPosition;
    }

    // Called by the button's XR Simple Interactable Select Entered event.
    public void Press()
    {
        if (!isPlaying)
            StartCoroutine(PlayConfetti());
    }

    private IEnumerator PlayConfetti()
    {
        isPlaying = true;
        buttonTop.localPosition = startPosition + Vector3.down * 0.04f;
        confetti.Play(true);
        yield return new WaitForSeconds(0.25f);
        buttonTop.localPosition = startPosition;
        yield return new WaitForSeconds(1.75f);
        isPlaying = false;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        buttonTop.localPosition = startPosition;
        confetti.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        isPlaying = false;
    }
}
