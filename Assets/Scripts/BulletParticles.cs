using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletParticles : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem ps;

    [SerializeField]
    private LayerMask meteoritMask;

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
            Destroy(gameObject, 0.5f);
        }

        if (other.gameObject.layer == 6)
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.layer == 7)
        {
            MeteorSpawner.bossLifes--;

            //Debug.Log(MeteorSpawner.bossLifes);

            if (MeteorSpawner.bossLifes <= 0)
            {
                Destroy(other.gameObject);

                SceneManager.LoadScene("Victory");

            }
        }
    }
}
