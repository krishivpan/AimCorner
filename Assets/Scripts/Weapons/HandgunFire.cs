using System.Collections;
using UnityEngine;

public class HandgunFire : MonoBehaviour
{

    [SerializeField] AudioSource gunFire;
    [SerializeField] GameObject handgun;
    [SerializeField] bool canFire = true;



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
