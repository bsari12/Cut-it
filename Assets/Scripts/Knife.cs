using UnityEngine;

public class Knife : MonoBehaviour
{
    public float speed = 30f;
    private bool isActive = true;
    private Rigidbody2D rb;
    private BoxCollider2D knifeCollider;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        knifeCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (isActive)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isActive) return;

        if (other.CompareTag("Target"))
        {
            StickToTarget(other.transform);
        }
        else if (other.CompareTag("Knife"))
        {
            GameManager.instance.GameOver();
        }
    }

    void StickToTarget(Transform target)
    {
        isActive = false;
        transform.SetParent(target);
        
        RotatingTarget targetScript = target.GetComponent<RotatingTarget>();
        if (targetScript != null)
        {
            targetScript.OnHit();
        }
        
    }
}