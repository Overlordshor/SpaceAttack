using UnityEngine;

public class Ship : MonoBehaviour
{
    public GameObject LaserPrefab;

    public int Lifes = 5;

    protected float speed;
    protected float timeFire = 0.5f;
    protected float timeReloadFire;
    
    
    public Ship()
    {
        speed = 5f;
        timeReloadFire = timeFire; 
    }

    protected virtual void LaserFire()
    {
        if (timeReloadFire > 0)
        {
            timeReloadFire -= Time.deltaTime;
        }
    }

}
