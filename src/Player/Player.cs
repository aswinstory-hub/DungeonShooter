using System.Numerics;
using Raylib_cs;

class Player
{
    Vector2 pos = new Vector2(0, 0);
    Vector2 velocity = new Vector2(0, 0);
    Vector2 direction = new Vector2(0, 0);

    float acceleration = 1800f;
    float friction = 2400f;
    float maxSpeed = 260f;

    public void update()
    {
       move(); 
    }

    private void handleInput()
    {
        var keyDown = Raylib.IsKeyDown;

        direction = Vector2.Zero;

        if (keyDown(KeyboardKey.W))
        {
            direction.Y = -1;
        }
        else if (keyDown(KeyboardKey.S))
        {
            direction.Y = 1;
        }

        if (keyDown(KeyboardKey.A))
        {
            direction.X = -1;
        }
        else if (keyDown(KeyboardKey.D))
        {
            direction.X = 1;
        }
    }

    void CalculateVelocity()
    {
        float dt = Raylib.GetFrameTime();

        // Calculate X velocity
        // Accelerate
        if (direction.X != 0)
        {
            velocity.X += direction.X * acceleration * dt;
        }
        else
        {
            // Friction / deceleration
            if (velocity.X > 0)
            {
                velocity.X -= friction * dt;

                if (velocity.X < 0)
                    velocity.X = 0;
            }
            else if (velocity.X < 0)
            {
                velocity.X += friction * dt;

                if (velocity.X > 0)
                    velocity.X = 0;
            }
        }
        // Calculate Y velocity
        // Accelerate
        if (direction.Y != 0)
        {
            velocity.Y += direction.Y * acceleration * dt;
        }
        else
        {
            // Friction / deceleration
            if (velocity.Y > 0)
            {
                velocity.Y -= friction * dt;

                if (velocity.Y < 0)
                    velocity.Y = 0;
            }
            else if (velocity.Y < 0)
            {
                velocity.Y += friction * dt;

                if (velocity.Y > 0)
                    velocity.Y = 0;
            }
        }


        velocity.X = Math.Clamp(velocity.X, -maxSpeed, maxSpeed);
        velocity.Y = Math.Clamp(velocity.Y, -maxSpeed, maxSpeed);


    }

    private void move()
    {
        float dt = Raylib.GetFrameTime();

        handleInput();
        CalculateVelocity();

        pos += velocity * dt;        

    }


    public void draw()
    {
        Raylib.DrawRectangle(posX: (int)pos.X, posY: (int)pos.Y, width: 16, height: 16, color: Color.Red);
    }
}