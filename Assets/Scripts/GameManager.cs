using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool lista2 =false;
    public List<GameObject> listaDeExpressoes;
    public GameObject expressao;
    public List<GameObject> expressoes;
    public int indiceExpressao;
    public int tentativas;
    public Text textTentativas;
    public float tempoAteEscolher;
    public float tempoAtual;
    public List<GameObject> escolhas;
    public int indiceEscolha = 0;
    public GameObject escolha;
    public int pontuacao;
    //Variável para mostrar a pontuação na tela de jogo
    public Text textPontuacao;
    // Variável para mostrar a pontuação final na tela de game over
    public Text textPontuacaoFinal;
    public bool jogoPausado;
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
        if (tentativas == 0) {
            quadro.SetActive(false);
            gameOverPanel.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Return)) {
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
        }
        tempoAtual -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.RightArrow) && tempoAtual <= 0) {
            tempoAtual = 0.25f;
            indiceEscolha = (indiceEscolha + 1) % 10;
            escolha = escolhas[indiceEscolha];
            FindObjectOfType<Movement>().destination = escolha;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tempoAtual <= 0) {
            tempoAtual = 0.25f;
            indiceEscolha = (indiceEscolha + 9) % 10;
            escolha = escolhas[indiceEscolha];
            FindObjectOfType<Movement>().destination = escolha;
        }
        if (Input.GetKeyDown(KeyCode.Return)) {
            if (expressao.GetComponent<Expressao>().resposta == escolha){
                FindObjectOfType<Movement>().destination = expressao;
                expressao.GetComponent<Expressao>().acertou = true;
                indiceExpressao += 1;
                expressao = expressoes[indiceExpressao];
                expressao.SetActive(true);
                tempoAtual = tempoAteEscolher;
                FindObjectOfType<AudioManager>().respostaCorreta.Play();
            } else {
                tentativas -= 1;
                textTentativas.text = tentativas.ToString();
                FindObjectOfType<AudioManager>().respostaIncorreta.Play();
            }
            if (tentativas == 0) {
                FindObjectOfType<AudioManager>().musicaDeFundo.Stop();
                FindObjectOfType<AudioManager>().somGameOver.Play();
            }
        }
        if (tempoAtual <= 0 && indiceExpressao>=5) {
            listaDeExpressoes[0].SetActive(false);
            listaDeExpressoes[1].SetActive(true);
        }
    }

    // Aumenta a pontuação do jogador.
    public void aumentaPontuacao()
    {
        pontuacao++;
        textPontuacao.text = pontuacao.ToString();
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
        FindObjectOfType<AudioManager>().musicaDeFundo.Play();
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
