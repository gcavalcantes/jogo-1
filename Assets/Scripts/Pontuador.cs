using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pontuador : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) {
            // Inicia o som de passar a montanha
            //FindObjectOfType<AudioManager>().somPassaMontanha.Play();
            // Incrementa a pontuação do jogador
            FindObjectOfType<GameManager>().aumentaPontuacao();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
