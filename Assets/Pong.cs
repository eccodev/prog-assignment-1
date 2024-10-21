using UnityEngine;

public class Pong : MonoBehaviour
{
    public GameObject ball;
    public GameObject paddle1;
    public GameObject paddle2;

    BoxCollider2D paddle1Box;
    BoxCollider2D paddle2Box;
    BoxCollider2D ballBox;

    Vector2 ballDirection = Vector2.right;

    void Start()
    {
        paddle1Box = paddle1.GetComponent<BoxCollider2D>();
        paddle2Box = paddle2.GetComponent<BoxCollider2D>();
        ballBox = ball.GetComponent<BoxCollider2D>();
        float angle = Random.Range(0.0f, 360.0f) * Mathf.Deg2Rad;
        ballDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    }

    void Update()
    {
        float dt = Time.deltaTime;
        float ballSpeed = 10.0f;
        float paddleSpeed = 5.0f;
        if (Input.GetKey(KeyCode.W))
        {
            paddle1.transform.position += Vector3.up * paddleSpeed * dt;
        }
        if (Input.GetKey(KeyCode.S))
        {
            paddle1.transform.position += Vector3.down * paddleSpeed * dt;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            paddle2.transform.position += Vector3.up * paddleSpeed * dt;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            paddle2.transform.position += Vector3.down * paddleSpeed * dt;
        }

        //measurements for paddle 1
        float xP1 = paddle1.transform.position.x;
        float yP1 = paddle1.transform.position.y;
        float hwP1 = paddle1Box.size.x * paddle1.transform.localScale.x * 0.5f;
        float hhP1 = paddle1Box.size.y * paddle1.transform.localScale.y * 0.5f;

        // min/max of paddle1
        float xMinP1 = xP1 - hwP1;
        float xMaxP1 = xP1 + hwP1;
        float yMinP1 = yP1 - hhP1;
        float yMaxP1 = yP1 + hhP1;

        //measurements for paddle 2
        float xP2 = paddle2.transform.position.x;
        float yP2 = paddle2.transform.position.y;
        float hwP2 = paddle2Box.size.x * paddle2.transform.localScale.x * 0.5f;
        float hhP2 = paddle2Box.size.y * paddle2.transform.localScale.y * 0.5f;

        // min/max of paddle2
        float xMinP2 = xP2 - hwP2;
        float xMaxP2 = xP2 + hwP2;
        float yMinP2 = yP2 - hhP2;
        float yMaxP2 = yP2 + hhP2;

        //ball measurements
        float ballX = ball.transform.position.x;
        float ballY = ball.transform.position.y;
        float hwball = ballBox.size.x * ballBox.transform.localScale.x * 0.5f;
        float hhball = ballBox.size.y * ballBox.transform.localScale.y * 0.5f;

        //ball min/max
        float xMinball = ballX - hwball;
        float xMaxball = ballX + hwball;
        float yMinball = ballY - hhball;
        float yMaxball = ballY + hhball;

        //Ball Collider
        if (ball.transform.position.x < xMaxP1)
        {
            ballDirection.x = -ballDirection.x;
            ballDirection.y = -ballDirection.y;
        }
        if (ball.transform.position.x > xMinP2)
        {
            ballDirection.x = -ballDirection.x;
            ballDirection.y = -ballDirection.y;
        }
        if (ball.transform.position.x < xMinP1)
        {
            ballDirection.x = -ballDirection.x;
            ballDirection.y = -ballDirection.y;
        }
        if (ball.transform.position.x > xMaxP2)
        {
            ballDirection.x = -ballDirection.x;
            ballDirection.y = -ballDirection.y;
        }
 
        //this is to separate the movement script from the bounce script
        if (ball.transform.position.x > 10.0f || ball.transform.position.x < -10.0f)
        {
            ballDirection.x = -ballDirection.x;
        }
        if (ball.transform.position.y > 4.5f || ball.transform.position.y < -4.5f)
        {
            ballDirection.y = -ballDirection.y;
        }

        Vector3 ballChange = ballDirection * ballSpeed * dt;
        ball.transform.position += ballChange;
    }
}
