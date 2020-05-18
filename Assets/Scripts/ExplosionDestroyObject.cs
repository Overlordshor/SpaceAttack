using UnityEngine;

public class ExplosionDestroyObject : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 3f);
    }
}
