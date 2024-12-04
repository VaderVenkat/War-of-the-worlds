using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float OnscreenDelay = 3f;
public flaot venkat = 2001f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(this.gameObject, OnscreenDelay);
Debug.Log(venkat);
    }

    // Update is called once per frame
}
