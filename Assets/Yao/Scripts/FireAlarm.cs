using System.Collections;
using UnityEngine;

public class FireAlarm : MonoBehaviour
{
    [SerializeField] private AudioSource alarmSound;
    [SerializeField] private Transform buttonTop;
    private Vector3 startPosition;
    private bool buttonMoving;

    private void Awake()
    {
        startPosition = buttonTop.localPosition;
    }

    // The same button starts and stops the alarm.
    public void Press()
    {
        if (buttonMoving)
            return;

        if (alarmSound.isPlaying)
            alarmSound.Stop();
        else
            alarmSound.Play();

        StartCoroutine(MoveButton());
    }

    private IEnumerator MoveButton()
    {
        buttonMoving = true;
        buttonTop.localPosition = startPosition + Vector3.down * 0.04f;
        yield return new WaitForSeconds(0.25f);
        buttonTop.localPosition = startPosition;
        buttonMoving = false;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        buttonTop.localPosition = startPosition;
        alarmSound.Stop();
        buttonMoving = false;
    }
}
