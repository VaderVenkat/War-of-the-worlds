using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float OnscreenDelay = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(this.gameObject, OnscreenDelay);

    }

    // Update is called once per frame
}
