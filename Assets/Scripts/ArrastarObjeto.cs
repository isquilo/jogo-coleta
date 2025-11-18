using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrastarObjeto : MonoBehaviour
{
    private Vector3 offset;
    private float zCoord;

    // Garante que o objeto tem um Collider, o que é essencial para OnMouseDown funcionar.
    // Geralmente, isso é um BoxCollider, SphereCollider ou MeshCollider.
    // O objeto deve ter um componente Collider para detectar cliques do mouse.

    /// <summary>
    /// Chamado quando o botão do mouse é pressionado sobre este Collider.
    /// </summary>
    void OnMouseDown()
    {
        // Pega a coordenada Z do objeto na tela, que é a distância da câmera.
        zCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        // Armazena o 'offset' (deslocamento) entre a posição do objeto no mundo
        // e a posição do mouse no mundo, para evitar que o objeto 'salte'
        // para o centro do cursor imediatamente ao clicar.
        offset = gameObject.transform.position - GetMouseWorldPosition();
    }

    /// <summary>
    /// Converte a posição atual do mouse na tela para uma posição no mundo.
    /// </summary>
    /// <returns>A posição do mouse no mundo 3D.</returns>
    private Vector3 GetMouseWorldPosition()
    {
        // Pega a coordenada de tela (Screen Point) do mouse.
        Vector3 mousePoint = Input.mousePosition;

        // Define a coordenada Z como a distância Z que salvamos em OnMouseDown.
        mousePoint.z = zCoord;

        // Converte a coordenada de tela (Screen Point) para a coordenada do mundo (World Point).
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    /// <summary>
    /// Chamado a cada frame enquanto o botão do mouse é mantido pressionado sobre o Collider.
    /// </summary>
    void OnMouseDrag()
    {
        // Move o objeto para a nova posição do mouse no mundo,
        // aplicando o 'offset' calculado anteriormente.
        transform.position = GetMouseWorldPosition() + offset;
    }

    // void OnMouseUp()
    // {
    //     // Chamado quando o botão do mouse é liberado.
    //     // Você pode adicionar lógica aqui, como soltar o objeto ou finalizar uma ação.
    // }

    // Não precisamos de Start() ou Update() para esta funcionalidade, mas eles podem ser usados para outras coisas.
    // void Start() { }
    // void Update() { }
}