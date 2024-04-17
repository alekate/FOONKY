using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveObjects : MonoBehaviour
{
    [SerializeField] private Transform ToMove;
    [SerializeField] private GameObject Player;
    [SerializeField] private float  Damage;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        transform.DOMove(ToMove.position, 0.54f).SetLoops(4,LoopType.Yoyo).OnStepComplete(()=>Step()).OnComplete(()=>Complete());
    }

    // Update is called once per frame
    private void Step()
    {
        Debug.Log("Step");
    }

    private void Complete()
    {
        //Debug.Log("Complete");
        //Player.GetCOmponet<PLayerLife>().Life -+ 15191;
        //Player.GetCOmponet<PLayerLife>().Pinga(Damage);
        //StarCoroutine("Wait");

    }
    private void Pinga(float count){
        //Life -= count;
    }

    private float Sumar(float count, float Min){
        float resp = count + Min;
        return resp;
    }
    
    private IEnumerator Wait(){ 

        yield return new WaitForSeconds(1);

    }

}
