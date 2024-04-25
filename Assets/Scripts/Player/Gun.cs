using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    [Header("Gun valores")]
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 3f;
    private float nextTimeToFire = 0f;

    [Header("Tipo de arma")]
    public bool isPistol;
    public bool isShotgun;
    public bool isRifle;

    public int maxAmmo;
    public int currentAmmo;

    [SerializeField] private TextMeshProUGUI ammo;

    public ParticleSystem[] muzzleFlashes;
    public Transform fpsCam;
    public AudioSource audioSource;
    public GameObject bulletImpact;

    [Header("Animator")]
    public Animator canAnim;
    private bool isReloading;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void GiveAmmo (int amount, GameObject pickup)
    {

        if(currentAmmo < maxAmmo)
        {
            currentAmmo += amount;
            Destroy(pickup);
        }

        if(currentAmmo > maxAmmo)
        {
            currentAmmo = maxAmmo;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ammo.text = currentAmmo.ToString();

        if(currentAmmo <= 0)
        {
            canAnim.SetBool("isReloading", isReloading);
            isReloading = Input.GetButtonDown("Fire1");
            
            return; //detiene el metodo para que no continue
        }

        if (gameObject.name == "RIFLE NAME PLACEH")  //soluciones rudimentarias no juzgen, es para hacer el rifle automatico (GetButton para hacerlo autommatica)
        {
            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
            {
                Shoot();
                foreach (ParticleSystem muzzleFlash in muzzleFlashes)
                {
                    muzzleFlash.Play();
                }
                nextTimeToFire = Time.time + 1f / fireRate;
                audioSource.Play();
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire) //Fire1 es el LMB en Unity 
            {
                Shoot();
                muzzleFlashes[0].Play();
                nextTimeToFire = Time.time + 1f / fireRate;
                audioSource.Play();

                if (gameObject.name == "Shootspray (Shootgun)") //para que la falta de sistema de particulas no de error en codigo
                {
                    muzzleFlashes[1].Play();
                    muzzleFlashes[2].Play();
                }
            }
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
                Instantiate(bulletImpact, hit.point, Quaternion.LookRotation(hit.normal));
                return;
            }

            EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Instantiate(bulletImpact, hit.point, Quaternion.LookRotation(hit.normal));
                return;
            }

            Instantiate(bulletImpact, hit.point, Quaternion.LookRotation(hit.normal));

        }

        currentAmmo--;

    }


}