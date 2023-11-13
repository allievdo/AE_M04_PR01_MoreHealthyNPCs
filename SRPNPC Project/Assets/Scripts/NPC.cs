using System;
using UnityEngine;

public class NPC : MonoBehaviour
{
    //[SerializeField] private float moveSpeed = 4f;
    //[SerializeField] private float turnSpeed = 90f;
    //[SerializeField] private int startingHp = 100;

    //[SerializeField] private UnityEngine.UI.Slider hpBarSlider = null;
    //[SerializeField] private ParticleSystem deathParticlePrefab = null;

    //private int currentHp;

    //private float CurrentHpPct 
    //{ 
    //    get { return (float) currentHp / (float) startingHp; } 
    //}

    //public event Action<float> OnHPPctChanged = delegate { };
    //public event Action OnNPCDied = delegate { };

    //private void Start()
    //{
    //    currentHp = startingHp;
    //}
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
            Debug.Log("Damage taken");
        }

        AddHealth(0.01f);

        //if(Input.GetKeyDown(KeyCode.W))
        //{
        //    AddHealth(5);
        //}
    }
    internal void TakeDamage(float amount)
    {
        GetComponent<IHealth>().TakeDamage(amount);
    }

    internal void AddHealth(float amount)
    {
       GetComponent<IHealth >().AddHealth(amount);
    }
    //private void UpdateUI()
    //{
    //    var currentHpPct = (float)currentHp / (float)startingHp;

    //    hpBarSlider.value = currentHpPct;
    //}

    //private void Die()
    //{
    //    OnNPCDied();
    //    GameObject.Destroy(this.gameObject);
    //}

    //private void PlayDeathParticle()
    //{
    //    var deathparticle = Instantiate(deathParticlePrefab, transform.position, deathParticlePrefab.transform.rotation);
    //    Destroy(deathparticle, 4f);
    //}

    //private void Update()
    //{
    //    transform.position += transform.forward * moveSpeed * Time.deltaTime;
    //    transform.Rotate(0f, turnSpeed * Time.deltaTime, 0f);
    //    hpBarSlider.transform.LookAt(Camera.main.transform);

    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        TakeDamage(startingHp / 10);
    //    }
    //}
}