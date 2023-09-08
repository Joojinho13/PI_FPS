using UnityEngine;

public class MoveToRL : MonoBehaviour
{
    public float velocidade = 2.0f; // A velocidade de movimento dos objetos.
    public float tempoDeEsperaMin = 1.0f; // Tempo mínimo de espera antes de mudar de direção.
    public float tempoDeEsperaMax = 3.0f; // Tempo máximo de espera antes de mudar de direção.

    private float tempoEspera;
    private float tempoPassado;

    private Vector3 direcao;

    private void Start()
    {
        // Inicialize o tempo de espera aleatório.
        tempoEspera = Random.Range(tempoDeEsperaMin, tempoDeEsperaMax);

        // Inicialize uma direção aleatória (esquerda ou direita).
        direcao = Random.value < 0.5f ? Vector3.left : Vector3.right;
    }

    private void Update()
    {
        // Controle o tempo para mudar de direção.
        tempoPassado += Time.deltaTime;

        if (tempoPassado >= tempoEspera)
        {
            // Alterne a direção aleatoriamente.
            direcao = direcao == Vector3.left ? Vector3.right : Vector3.left;

            // Redefina o tempo de espera aleatoriamente.
            tempoEspera = Random.Range(tempoDeEsperaMin, tempoDeEsperaMax);

            // Redefina o tempo passado.
            tempoPassado = 0f;
        }

        // Movimente o objeto na direção atual.
        transform.Translate(direcao * velocidade * Time.deltaTime);
    }
}