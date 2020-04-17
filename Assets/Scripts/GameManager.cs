using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int pontuacao;
    //Variável para mostrar a pontuação na tela de jogo
    public Text textPontuacao;
    // Variável para mostrar a pontuação final na tela de game over
    public Text textPontuacaoFinal;
    public bool jogoPausado;
    public GameObject optionPanel;
    // Mostra painel de Game over
    public GameObject gameOverPanel;
    public GameObject menuInicial;
    public GameObject menuCredito;
    // Start is called before the first frame update
    void Start()
    {
        // Variável para a pontuação
        // pontuacao = 0;
        // Mostra o resultado do jogador na caixa de texto
        // textPontuacao.text = pontuacao.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            janelaOpcoes();
        }
    }

    // Aumenta a pontuação do jogador.
    public void aumentaPontuacao()
    {
        pontuacao++;
        textPontuacao.text = pontuacao.ToString();
    }

    // Método da janela de opções (em jogo)
    public void janelaOpcoes()
    {
        if (jogoPausado)
        {
            jogoPausado = false;
            // Desativa a tela de opções
            optionPanel.SetActive(false);
        } else {
            jogoPausado = true;
            // Ativa a tela de opções
            optionPanel.SetActive(true);
        }
        
    }

    // Método para reiniciar jogo
    public void reiniciarJogo(){
        //SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void abrirCreditos()
    {
        menuInicial.SetActive(false);
        menuCredito.SetActive(true);
    }

    public void fecharCredito()
    {
        menuInicial.SetActive(true);
        menuCredito.SetActive(false);
    }
}
