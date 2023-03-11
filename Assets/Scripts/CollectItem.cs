using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectItem : MonoBehaviour
{
    public GameObject player;
    public float distanceThreshold = 1f;

    [SerializeField]
    private Sprite podstava;

    [SerializeField]
    private Sprite podstavaDark;

    [SerializeField]
    private Sprite raketa;

    [SerializeField]
    private Sprite raketaDark;

    [SerializeField]
    private Sprite cannon;

    [SerializeField]
    private Sprite cannonDark;

    [SerializeField]
    private GameObject podstavaObj;

    [SerializeField]
    private GameObject raketaObj;

    [SerializeField]
    private GameObject cannonObj;

    void Start()
    {
        Podstava(false);
        Raketa(false);
        Cannon(false);
    }

    public void Raketa(bool status)
    {
        if (status)
        {
            raketaObj.GetComponent<Image>().sprite = raketa;
        }
        else
        {
            raketaObj.GetComponent<Image>().sprite = raketaDark;
        }
    }
    public void Podstava(bool status)
    {
        if (status)
        {
            podstavaObj.GetComponent<Image>().sprite = podstava;
        }
        else
        {
            podstavaObj.GetComponent<Image>().sprite = podstavaDark;
        }
    }
    public void Cannon(bool status)
    {
        if (status)
        {
            cannonObj.GetComponent<Image>().sprite = cannon;
        }
        else
        {
            cannonObj.GetComponent<Image>().sprite = cannonDark;
        }
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < distanceThreshold)
        {
            if (gameObject.name == "StartingMechanism5.1(Clone)")
            {
                Podstava(true);
                Debug.Log("podstava");
            }
            else if(gameObject.name == "StartingMechanism5.2(Clone)")
            {
                Cannon(true);
                Debug.Log("canon");
            }
            else if (gameObject.name == "StartingMechanism5.3(Clone)")
            {
                Raketa(true);
                Debug.Log("raketa");
            }
                
            Destroy(gameObject);
            
        }
    }
}
