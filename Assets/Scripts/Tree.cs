using UnityEngine;
using System.Collections;

public class Tree : MonoBehaviour
{
    public float initialScale;
    public float finalScale;
    public float scalingSpeed;
    GameManager gameManager;

    float currentScale;

    void Start ()
    {
        currentScale = initialScale;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        currentScale -= scalingSpeed * Time.deltaTime;

        transform.localScale = new Vector3(transform.localScale.x, currentScale, transform.localScale.z);

        if (currentScale <= finalScale)
        {
            Destroy(gameObject);
            gameManager.LoseALife();
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
        {
            if (hit.collider == GetComponent<Collider>())
            {
                currentScale = initialScale;
            }
        }

    }

}
