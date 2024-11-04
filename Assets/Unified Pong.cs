using UnityEngine;

public class UnifiedPong : MonoBehaviour
{
    // Aliases for the ball and paddles
    public GameObject ballin;
    public GameObject LPaddle;
    public GameObject RPaddle;

    // Box colliders
    BoxCollider2D LPaddleBox;
    BoxCollider2D RPaddleBox;
    BoxCollider2D ballinCollider;

    int scorePaddle1 = 0;
    int scorePaddle2 = 0;

    // Vector direction for the ball on start
    Vector2 ballinToWhere = Vector2.right;

    // Start is called before the first frame update
    void Start()
    {
        // Getting ball and paddle components
        LPaddleBox = LPaddle.GetComponent<BoxCollider2D>();
        RPaddleBox = RPaddle.GetComponent<BoxCollider2D>();
        ballinCollider = ballin.GetComponent<BoxCollider2D>();

        // Trig to send the ball in a direction
        float angle = Random.Range(0.0f, 360.0f) * Mathf.Deg2Rad;
        ballinToWhere = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    }

    // Update is called once per frame
    void Update()
    {
        // floats for constraining calculations to time, ball speed, and paddle speed
        float dt = Time.deltaTime;
        float ballinSwiftly = 40.0f;
        float paddleSpd = 38.0f;

        // Move Left paddle up or down with W or S
        if (Input.GetKey(KeyCode.W))
        {
            LPaddle.transform.position += Vector3.up * paddleSpd * dt;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            LPaddle.transform.position += Vector3.down * paddleSpd * dt;
        }

        // Move Right paddle up or down with ArrowUp or ArrowDown

        if (Input.GetKey(KeyCode.UpArrow))
        {
            RPaddle.transform.position += Vector3.up * paddleSpd * dt;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            RPaddle.transform.position += Vector3.down * paddleSpd * dt;
        }

        // Measuring the play objects
        // Left Paddle
        float xLPaddle = LPaddle.transform.position.x;
        float yLPaddle = LPaddle.transform.position.y;
        float hwLPaddle = LPaddleBox.size.x * LPaddle.transform.localScale.x * 0.5f;
        float hhLPaddle = LPaddleBox.size.y * LPaddle.transform.localScale.y * 0.5f;
        // Min/Max of Left Paddle
        float xMinLPaddle = xLPaddle - hwLPaddle;
        float xMaxLPaddle = xLPaddle + hhLPaddle;
        float yMinLPaddle = yLPaddle - hwLPaddle;
        float yMaxLPaddle = yLPaddle + hhLPaddle;

        // Right Paddle
        float xRPaddle = RPaddle.transform.position.x;
        float yRPaddle = RPaddle.transform.position.y;
        float hwRPaddle = RPaddleBox.size.x * RPaddle.transform.localScale.x * 0.5f;
        float hhRPaddle = RPaddleBox.size.y * RPaddle.transform.localScale.y * 0.5f;
        // Min/Max of Right Paddle
        float xMinRPaddle = xRPaddle - hwRPaddle;
        float xMaxRPaddle = xRPaddle + hhRPaddle;
        float yMinRPaddle = yRPaddle - hwRPaddle;
        float yMaxRPaddle = yRPaddle + hhRPaddle;

        // Ballin
        float xBallin = ballin.transform.position.x;
        float yBallin = ballin.transform.position.y;
        float hwBallin = ballinCollider.size.x * ballin.transform.position.x * 0.5f;
        float hhBallin = ballinCollider.size.y * ballin.transform.position.y * 0.5f;
        // Min/Max of Ballin
        float xMinBallin = xBallin - hwBallin;
        float xMaxBallin = xBallin + hwBallin;
        float yMinBallin = yBallin - hhBallin;
        float yMaxBallin = yBallin + hhBallin;

        // Keep the ball in the play area


        // Logic for ball to collide with paddles 

        if (xBallin < xMaxRPaddle && xBallin > xMinRPaddle && yBallin < yMaxRPaddle && yBallin > yMinRPaddle)
        {
            ballinToWhere = Vector2.Reflect(ballinToWhere, Vector2.right);
        }
        if (xBallin < xMaxLPaddle && xBallin > xMinLPaddle && yBallin < yMaxLPaddle && yBallin > yMinLPaddle)
        {
            ballinToWhere = Vector2.Reflect(ballinToWhere, Vector2.left);
        }

        // Keeps the ball in-bounds


        // Ball movement logic
        if (xBallin > 43.0f)
        {
            scorePaddle2++;
            Debug.Log("Paddle 2 Score: " + scorePaddle2);
            ResetBallPosition();
        }
        else if (xBallin < -43.0f)
        {
            scorePaddle1++;
            Debug.Log("Paddle 1 Score: " + scorePaddle1);
            ResetBallPosition();
        }
        else
        {
            if (xBallin > 44.0f || xBallin < -44.0f)
            {
                ballinToWhere.x = -ballinToWhere.x;
            }

            if (yBallin > 44.0f || yBallin < -44.0f)
            {
                ballinToWhere.y = -ballinToWhere.y;
            }

        }
        Vector3 ballChange = ballinToWhere * ballinSwiftly * dt;
        ballin.transform.position += ballChange;

        void ResetBallPosition()
        {
            ballin.transform.position = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-3.0f, 3.0f), 0f);
            float angle = Random.Range(0.0f, 360.0f) * Mathf.Deg2Rad;
            ballinToWhere = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            // TODO: SCORING AND RESETTING BALL
        }
    }
}
