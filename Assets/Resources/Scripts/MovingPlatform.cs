using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private SliderJoint2D _sliderJoint2D = null;

    private bool _isLeft = false;

    // Start is called before the first frame update
    void Start()
    {
        _sliderJoint2D = GetComponent<SliderJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        SwitchMoveDirection();
    }

    /// <summary>
    /// Двигает платформу влево и вправо
    /// </summary>
    private void SwitchMoveDirection()
    {
        if ((_sliderJoint2D.jointTranslation <= _sliderJoint2D.limits.min) && !_isLeft)
        {
            JointMotor2D jointMotor = new JointMotor2D();
            jointMotor = _sliderJoint2D.motor;
            jointMotor.motorSpeed *= -1; 

            _sliderJoint2D.motor = jointMotor;
            _isLeft = true;
        }
        if(_sliderJoint2D.jointTranslation >= _sliderJoint2D.limits.max && _isLeft)
        {
            JointMotor2D jointMotor = new JointMotor2D();
            jointMotor = _sliderJoint2D.motor;
            jointMotor.motorSpeed *= -1;

            _sliderJoint2D.motor = jointMotor;
            _isLeft = false;
        }
    }
}
