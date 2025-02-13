using UnityEngine;

public class ControladorJogador : MonoBehaviour
{

    public float taxaMovimentacao;
    public Geral juizDoJogo;

   

    // Update is called once per frame
    void Update()
    {
        float altX, altY;

        // Para cima e para baixo mexe com o Y
        // O && significa "e" em programação, essa parte foi usada para limitar o movimento da luva para cima
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < 471)
            altY = 60 * Time.deltaTime * taxaMovimentacao;
        else if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > 27)
            altY = -60 * Time.deltaTime * taxaMovimentacao;
        else
            altY = 0;

        // Para os lados mexe com o Y
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > 30 )
            altX = -60 * Time.deltaTime * taxaMovimentacao;
        else if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 932)
            altX = 60 * Time.deltaTime * taxaMovimentacao;
        else
            altX = 0;

        // Modificar posição:

        Vector3 novaPos = new Vector3(altX, altY, 0);
        transform.position += novaPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Voador")
        { 
            //Marcando um ponto no placar
            juizDoJogo.MarcarPonto();

            //Volta o objeto para a posição horizontal original
            collision.GetComponent<VoadorControlador>().posicaoObj.x =
                collision.GetComponent<VoadorControlador>().posInicialX;

            //Atualizar a posição vertical do objeto
            float posicaoY = Random.value * 471; 
            collision.GetComponent<VoadorControlador>().posicaoObj.y = posicaoY;

            //Trocar a imagem do objeto a ser coletado 
            collision.GetComponent<VoadorControlador>().MudarImagem();
        
        
        }
        
    }
}
