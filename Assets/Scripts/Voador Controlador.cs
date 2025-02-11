using UnityEngine;

public class VoadorControlador : MonoBehaviour
{

    public float deslocamentoObjeto;
    internal int sentidoV;
    internal Vector3 posicaoObj;

    public float posInicialX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sentidoV = 1;
        posicaoObj = transform.position;
        posInicialX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        //Se eu quisesse simplificar poderia usar posicaoObj.y +=
        posicaoObj.y = posicaoObj.y + (deslocamentoObjeto * sentidoV * Time.deltaTime);
        posicaoObj.x += deslocamentoObjeto * Time.deltaTime;


        transform.position = posicaoObj;

        //Limitadores verticais 
        if (transform.position.y > 471)
            sentidoV = -1;
        else if (transform.position.y < 27)
            sentidoV = 1;

        
    }
}
