using UnityEngine;

public class BulletParticles : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem ps;

    void Start()
    {
       
    }

    void Update()
    {
        

        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (ps != null)
        {
            ps.gameObject.SetActive(true);
            ps.Play();
            
            //ps.Play();
        }
        if (gameObject.activeSelf)
        {
            //gameObject.SetActive(false);
            Destroy(gameObject,0.5f);
        }
    }
}
