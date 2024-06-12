using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    [Header("Gun valores")]
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 3f;
    private float nextTimeToFire = 0f;
    public Backpack backpack;

    [Header("Tipo de arma")]
    public bool isPistol;
    public bool isShotgun;
    public bool isRifle;

    public int currentAmmo;
    public string tag;

    [SerializeField] private TextMeshProUGUI ammo;

    public ParticleSystem[] muzzleFlashes;
    public Transform fpsCam;
    public AudioSource audioSource;
    public GameObject bulletImpact;

    [Header("Animator")]
    public Animator canAnim;
    private bool isReloading;
    private bool isShootingPistol;
    private bool isShootingShotgun;
    private bool isShootingRifle;

    private void OnEnable() 
    {
        Debug.Log("lol");
        BulletFind();  
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        backpack = FindObjectOfType<Backpack>();
        tag = gameObject.tag;
        BulletFind();  
    }

    void Update()
    {
        ammo.text = currentAmmo.ToString();
        canAnim.SetBool("isShootingPistol", isShootingPistol);
        canAnim.SetBool("isShootingShotgun", isShootingShotgun);
        canAnim.SetBool("isShootingRifle", isShootingRifle);


        if(currentAmmo <= 0)
        {
            canAnim.SetBool("isReloading", isReloading);
            isReloading = Input.GetButtonDown("Fire1");
            
            canAnim.SetBool("isShootingPistol", false);
            canAnim.SetBool("isShootingShotgun", false);
            canAnim.SetBool("isShootingRifle", false);
            
            return; //detiene el metodo para que no continue
        }

        
        if (gameObject.name == "RIFLE NAME PLACEH")  //soluciones rudimentarias no juzgen, es para hacer el rifle automatico (GetButton para hacerlo autommatica)
        {
            canAnim.SetBool("isRifle", true);
            canAnim.SetBool("isShotgun", false);
            canAnim.SetBool("isPistol", false);

            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
            {
                
                isShootingRifle = Input.GetButton("Fire1");

                Shoot();
                foreach (ParticleSystem muzzleFlash in muzzleFlashes)
                {
                    muzzleFlash.Play();
                }
                nextTimeToFire = Time.time + 1f / fireRate;
                audioSource.Play();
                
            }
            else
            {
                canAnim.SetBool("isShootingRifle", false);
            }
        }

        else
        {
            
            
            if (gameObject.name == "Spraycan (Pistol)")
            {
                canAnim.SetBool("isPistol", true);
                canAnim.SetBool("isShotgun", false);
                canAnim.SetBool("isShootingShotgun", false);

                if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
                {
                    Shoot();
                    muzzleFlashes[0].Play();
                    isShootingPistol = Input.GetButtonDown("Fire1");
                    audioSource.Play();
                    nextTimeToFire = Time.time + 1f / fireRate;
                }
                else
                {
                    canAnim.SetBool("isShootingPistol", false);
                }
                    
            }
                
            if (gameObject.name == "Shotspray (Shotgun)") 
            {
                canAnim.SetBool("isShotgun", true);
                canAnim.SetBool("isPistol", false);
                canAnim.SetBool("isShootingPistol", false);

                if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
                {
                    Shoot();
                    muzzleFlashes[1].Play();
                    muzzleFlashes[2].Play();
                    isShootingShotgun = Input.GetButtonDown("Fire1");
                    audioSource.Play();
                    nextTimeToFire = Time.time + 1f / fireRate;
                }
                else
                {
                    canAnim.SetBool("isShootingShotgun", false);
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
        backpack.AmmoUsed(tag);

    }

    private void BulletFind()
    {
        switch (tag)
        {
            case "Rifle": currentAmmo = backpack.currentRifleAmmo; 
            break;

            case "Pistol": currentAmmo = backpack.currentPistolAmmo; 
            break;

            case "Shotgun": currentAmmo = backpack.currentShotgunAmmo; 
            break;

            default:
            return;
        }
    }
}
