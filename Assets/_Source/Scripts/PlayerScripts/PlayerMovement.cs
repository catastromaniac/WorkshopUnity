using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour{
    /*
    MonoBehavior - Ele tem a��o no jogo e acesso a recursos;
    : Significa Heran�a;
    Awake() � a primeira fun��o rodada ao carregar, seguida da OnEnable();
    OnEnable() � chamada quando um item fica ativo na cena;
    OnDisable() � chamada quando um item se torna inativo na cena;
    */

    [Header("Layers")]
    public LayerMask groundLayer;

    private NavMeshAgent nav;

    private void Start(){
    //Fazer inst�ncias, ligar refer�ncias, tudo que acontece ap�s a base ter carregado e o objeto estar ativo.

        nav = GetComponent<NavMeshAgent>();
        //GetComponent<Nome>() pega um componente do objeto do qual o script faz parte.
    }

    private void Update(){
        //Chamada a cada frame.
      ManageMovement();
    }

    private void ManageMovement(){
        if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0)){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Checar onde o mouse est�;
        Debug.DrawRay(ray.origin, ray.direction*150, Color.red);

        RaycastHit hit; //Para armazenar quando o ray bater em algo;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer)){

            if (hit.collider.CompareTag("Ground")){

                nav.SetDestination(hit.point);

            }
        }

       } 
        
    }

}