using System.Collections;
using UnityEngine;

public class HandgunFire : MonoBehaviour
{

    [SerializeField] AudioSource gunFire;
    [SerializeField] GameObject handgun;
    [SerializeField] bool canFire = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            StartCoroutine(FiringGun());
        }
    }

    IEnumerator FiringGun()
    {
        gunFire.Play();
        handgun.GetComponent<Animator>().Play("HandgunFire");
        yield return new WaitForSeconds(0.5f);
        handgun.GetComponent<Animator>().Play("Idle");
        yield return new WaitForSeconds(0.01f);
        canFire = true;
    }
}
