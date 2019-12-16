using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Remote
{
    public class Dummy : Remote
    {
        private readonly float MIN_SPEED = 0.04f;
        private readonly int NO_MOVE_TIMEOUT = 300;
        private bool isMoving;
        private int noMove;
        private bool goForward;

        private float GenerateAccelerator()
        {
            goForward = !goForward;
            return (goForward ? 1.0f : -1.0f) * (0.5f + Random.Range(0.0f, 0.5f));
        }

        private float GenerateWheel()
        {
            return Random.Range(-1.0f, 1.0f);
        }

        void Start()
        {
            robot.Brake = false;
            isMoving = false;
            noMove = 0;

            goForward = false;
            robot.Accelerator = GenerateAccelerator();

            robot.Wheel = GenerateWheel();
        }

        void Update()
        {
            if (isMoving || noMove > NO_MOVE_TIMEOUT)
            {
                if (robot.Body.velocity.sqrMagnitude < MIN_SPEED)
                {
                    isMoving = false;
                    noMove = 0;
                    robot.Accelerator = GenerateAccelerator();
                    robot.Wheel = GenerateWheel();
                }
            }
            else
            {
                noMove += 1;
                if (robot.Body.velocity.sqrMagnitude > MIN_SPEED)
                {
                    isMoving = true;
                }

            }
        }
    }
}
