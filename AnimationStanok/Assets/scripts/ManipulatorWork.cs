using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulatorWork : MonoBehaviour
{
    TelegaRide telega;
    GameObject spawner;
    [SerializeField] GameObject rawMaterial;
    [SerializeField] GameObject textureManipulator;
   // Animator animator;
    void Start()
    {
        telega = FindAnyObjectByType<TelegaRide>();
        spawner = GameObject.FindWithTag("Spawner");
        rawMaterial.GetComponent<Rigidbody>().isKinematic = true;
        //animator = GetComponent<Animator>();
    }

    bool naklon = false;
    private void Update()
    {
        if (naklon)
        {
            Naklon();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        StartCoroutine(waitseconds());
    }

    IEnumerator waitseconds()
    {
        telega.stop = true;
        naklon = true;

        yield return new WaitForSeconds(3);

        Instantiate(rawMaterial, spawner.transform.position, spawner.transform.rotation, textureManipulator.transform);

    }

    void Naklon()
    {
        if (textureManipulator.transform.localEulerAngles.x <= 33)
            textureManipulator.transform.localEulerAngles +=
                new Vector3(10 * Time.deltaTime, 0, 0);
        else
            naklon = false;
    }
}
