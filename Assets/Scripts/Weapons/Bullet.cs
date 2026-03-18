
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bullet;

    public float shootForce, upwardForce;

    public float timeBetweenShooting, timeBetweenShots;
    public int bulletsPerTap;

    bool shooting, readyToShoot;

    public Rigidbody playerRigidBody;
    public float recoilForce;

    public Camera fpsCam;
    public Transform attackPoint;

    // Graphics
    public GameObject muzzleFlash;

    public bool allowInvoke = true;

    private void Awake()
    {
        // Make sure magazine gets filled up
        readyToShoot = true;
    }

    private void Update()
    {
        MyInput();
    }

    private void MyInput()
    {
        shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (readyToShoot && shooting)
        {
            Shoot();
        }
    }


    private void Shoot()
    {
        readyToShoot = false;

        Ray ray = fpsCam.ViewportPointToRay(new UnityEngine.Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        UnityEngine.Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        } else
        {
            targetPoint = ray.GetPoint(75);
        }

        // Calculate the direction between attackPoint and targetPoint, direction = |B| - |A|
        UnityEngine.Vector3 bulletDirection = targetPoint - attackPoint.position;

        // intantiate bullet
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);

        // Add bullet physics
        currentBullet.GetComponent<Rigidbody>().AddForce(bulletDirection.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

        // Add recoil
        // playerRigidBody.AddForce(-bulletDirection.normalized * recoilForce, ForceMode.Impulse);

        if (muzzleFlash != null)
        {
            Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);
        }

        // Invoke resetShot function (if not already invoked), with timeBetweenShooting
        Invoke("ResetShot", timeBetweenShooting);

    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }

}

