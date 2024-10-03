using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EasyTransition
{ 
    public class MeleeDamage : MonoBehaviour
    {
        [SerializeField] bool canDealDamage;
        [SerializeField] bool hasDealDamage;

        [SerializeField] float damageRange;
        [SerializeField] int damagePoints;

        private UnityEngine.AI.NavMeshAgent navMeshAgent;
        private MaquinaEstados maquinaEstados;
        public Animator enemyAnim;

        private void OnEnable() 
        {
            maquinaEstados = GetComponentInParent<MaquinaEstados>();
            navMeshAgent = GetComponentInParent<UnityEngine.AI.NavMeshAgent>();
            enemyAnim = GetComponent<Animator>();  
            canDealDamage = true;
            hasDealDamage = false; 
            enemyAnim.SetTrigger("ataque");
        }

        // Update is called once per frame
        void Update()
        {
            if (canDealDamage && !hasDealDamage)
            {
                RaycastHit hit;

                if (Physics.Raycast(transform.position, transform.forward, out hit, damageRange))
                {
                    hasDealDamage = true;
                    PlayerHealth player = hit.transform.GetComponent<PlayerHealth>();
                    player.DamagePlayer(damagePoints, "D0g3");
                }
            }
        }

        public void StartDealDamage()
        {
            canDealDamage = true;
            hasDealDamage = false; 
        }

        public void EndDealDamage()
        {
            canDealDamage = false;
            maquinaEstados.ActivarEstado(maquinaEstados.EstadoPersecucion);
        }
    }
}