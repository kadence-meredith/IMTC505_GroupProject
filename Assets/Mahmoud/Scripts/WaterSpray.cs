using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Firefighter hose: put this on the Right Controller.
// Hold the trigger -> blue water sprays out of the controller,
// and wherever you point, the surface gets covered in blue water puddles.
public class WaterSpray : MonoBehaviour
{
    [Header("Button that sprays (pick: XRI Right Interaction/Activate)")]
    public InputActionReference sprayAction;

    [Header("Water spray particles (child of this controller)")]
    public ParticleSystem sprayParticles;

    [Header("Blue puddle left where the water lands")]
    public GameObject puddlePrefab;
    public float maxDistance = 15f;
    public float timeBetweenPuddles = 0.15f;
    public int maxPuddles = 60;

    private float nextPuddleTime;
    private readonly Queue<GameObject> puddles = new Queue<GameObject>();

    private void OnEnable()
    {
        if (sprayAction != null)
            sprayAction.action.Enable();
    }

    private void Update()
    {
        bool spraying = sprayAction != null && sprayAction.action.IsPressed();

        // Turn the water stream on/off
        if (sprayParticles != null)
        {
            if (spraying && !sprayParticles.isPlaying)
                sprayParticles.Play();
            else if (!spraying && sprayParticles.isPlaying)
                sprayParticles.Stop();
        }

        // Leave puddles where we are pointing
        if (spraying && Time.time >= nextPuddleTime)
        {
            nextPuddleTime = Time.time + timeBetweenPuddles;
            MakePuddle();
        }
    }

    private void MakePuddle()
    {
        if (puddlePrefab == null)
            return;

        // Shoot an invisible line straight out of the controller
        if (!Physics.Raycast(transform.position, transform.forward, out RaycastHit hit,
                             maxDistance, ~0, QueryTriggerInteraction.Ignore))
            return;

        // Lay the puddle flat on whatever we hit (floor, wall, bench...)
        Vector3 position = hit.point + hit.normal * 0.01f;
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
        GameObject puddle = Instantiate(puddlePrefab, position, rotation);

        // Small random spin and size so it looks natural
        puddle.transform.Rotate(0f, Random.Range(0f, 360f), 0f, Space.Self);
        float size = Random.Range(0.7f, 1.3f);
        puddle.transform.localScale = Vector3.Scale(puddle.transform.localScale, new Vector3(size, 1f, size));

        // Remove the oldest puddles so the scene doesn't fill up
        puddles.Enqueue(puddle);
        if (puddles.Count > maxPuddles)
            Destroy(puddles.Dequeue());
    }
}
