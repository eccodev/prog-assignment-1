using Unity.VisualScripting;
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
        float angle = 30.0f * Mathf.Deg2Rad;
        ballinToWhere = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    }

    // Update is called once per frame
    void Update()
    {
        // floats for constraining calculations to time, ball speed, and paddle speed
        float dt = Time.deltaTime;
        float ballinSwiftly = 16.0f;
        float paddleSpd = 10.0f

        // Move Left paddle up or down with W or S
        if (Input.GetKey(KeyCode.W))
        {
            LPaddle.transform.position = Vector3.up * paddleSpd * dt;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            LPaddle.transform.position = Vector3.down * paddleSpd * dt;
        }

        // Move Right paddle up or down with ArrowUp or ArrowDown

        if (Input.GetKey(KeyCode.UpArrow))
        {
            RPaddle.transform.position = Vector3.up * paddleSpd * dt;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            RPaddle.transform.position = Vector3.down * paddleSpd * dt;
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

        // Ball collision logic

        if (ballin.transform.position.x > 44.0f || ballin.transform.position.x < -44.0f) // Vinny taught me about how to use the "||" operator, props to him
        {
            ballinToWhere.x = -ballinToWhere.x;
        }
        if (ballin.transform.position.y > 44.0f || ballin.transform.position.y > -44.0f)
        {
            ballinToWhere.y = -ballinToWhere.y;
        }

        // Ball movement logic
        Vector3 ballinAndShiftin = ballinToWhere * ballinSwiftly * dt;
        ballin.transform.position += ballinAndShiftin;

        // TODO: SCORING AND RESETTING BALL
    }
}
