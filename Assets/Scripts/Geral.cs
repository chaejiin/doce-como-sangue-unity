using UnityEngine;
using UnityEngine.UI;

public class Geral : MonoBehaviour
{
    internal int placarJogadorNum, recordeNum;
    public Text placarJogadorTexto, recordeTexto;
    public AudioSource somPontoGanho;

    public GameObject telaBoasVindas, telaGameOver;
    public VoadorControlador objetoVoador;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        placarJogadorNum = 0;
        //recordeNum = 0;

        AtualizarTextoPlacar();

        Time.timeScale = 0;
    }

    public void MarcarPonto ()
    {
        placarJogadorNum += 1;

        if (recordeNum < placarJogadorNum)
            recordeNum += 1;

        AtualizarTextoPlacar();

        somPontoGanho.Play();
    }

    public void AtualizarTextoPlacar()
    {
        placarJogadorTexto.text = "Itens coletados:" + placarJogadorNum;
        recordeTexto.text = "Recorde atual: " + recordeNum;

    }

    public void ComecarJogo()
    {
        //"Descongelar" o tempo
        Time.timeScale = 1;

        //Sumir com as telas de boas vindas OU a de Game Over
        telaBoasVindas.SetActive(false);
        telaGameOver.SetActive(false);

        //Voltar o objeto voador à sua posição original
        objetoVoador.deslocamentoAbs = objetoVoador.deslocamentoObjeto;
        objetoVoador.posicaoObj.x = objetoVoador.posInicialX;

        //Zerar o placar
        placarJogadorNum = 0;
        AtualizarTextoPlacar ();
    }

   
}
