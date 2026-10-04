using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class BasketScore : MonoBehaviour
{
    public Rigidbody ball;
    public Transform basket;
    public GameObject fireEffect;

    private bool extinguished;
    private XRGrabInteractable grab;

    private void Start()
    {
        if (ball != null)
            grab = ball.GetComponent<XRGrabInteractable>();

        SetBoxColor(Color.red);

        if (fireEffect != null)
            fireEffect.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (extinguished || ball == null || basket == null)
            return;

        if (other.attachedRigidbody != ball)
            return;

        // 拿着水球进入箱子时不触发，需要先松手。
        if (grab != null && grab.isSelected)
            return;

        extinguished = true;
        SetBoxColor(Color.green);

        if (fireEffect != null)
            fireEffect.SetActive(false);

        Debug.Log("Fire extinguished! 灭火成功！");
    }

    private void SetBoxColor(Color color)
    {
        if (basket == null)
            return;

        foreach (MeshRenderer part in
                 basket.GetComponentsInChildren<MeshRenderer>())
        {
            if (part.enabled)
                part.material.color = color;
        }
    }
}
