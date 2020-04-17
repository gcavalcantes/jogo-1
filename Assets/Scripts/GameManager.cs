using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> escolhas;
    public int indiceEscolha = 1;
    public GameObject escolha;
    public int pontuacao;
    //Variável para mostrar a pontuação na tela de jogo
    public Text textPontuacao;
    // Variável para mostrar a pontuação final na tela de game over
    public Text textPontuacaoFinal;
    public bool jogoPausado;
    public GameObject optionPanel;
    // Mostra painel de Game over
    public GameObject gameOverPanel;
    public GameObject quadro;
    public GameObject menuInicial;
    public GameObject menuCredito;
    // Start is called before the first frame update
    void Start()
    {
        // Variável para a pontuação
        // pontuacao = 0;
        // Mostra o resultado do jogador na caixa de texto
        //textPontuacao.text = pontuacao.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            janelaOpcoes();
        }

        if(Input.GetMouseButtonDown(0))
        {

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            indiceEscolha = (indiceEscolha + 1) % 10;
            escolha = escolhas[indiceEscolha];
            FindObjectOfType<Movement>().destination = escolha;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            indiceEscolha = (indiceEscolha + 9) % 10;
            escolha = escolhas[indiceEscolha];
            FindObjectOfType<Movement>().destination = escolha;
        }
        if (Input.GetKeyDown(KeyCode.Return)) {
            
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

    // Método para iniciar jogo
    public void iniciarJogo()
    {
        //SceneManager.LoadScene(1);
    }

    // Método para reiniciar jogo
    public void reiniciarJogo(){
        //SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void mostrarQuadro()
    {
        menuInicial.SetActive(false);
        menuCredito.SetActive(false);
        quadro.SetActive(true);
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

    //Método para sair do jogo.
    public void sairDoJogo(){
        Debug.Log("Clicou em SAIR");
        Application.Quit();
    }
}
