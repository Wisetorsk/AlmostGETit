using System;

public class Vector2D
{
	public Vector2D(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public void Add(Vector2D vector)
    {
        this.x += vector.x;
        this.y += vector.y;
    }

    public void Mult(Vector2D vector)
    {

    }

    public void Dec(Vector2D vector)
    {

    }

    public void Dot(Vector2D vector)
    {

    }

    public void Cross(Vector2D vector)
    {

    }

    public void Scale(double scalar)
    {
        this.x *= scalar;
        this.y *= scalar;
    }

    public void Invert()
    {
        this.y = -this.y;
        this.x = -this.x;
    }

    public double Mag()
    {
        return Math.Sqrt(this.x^2 + this.y^2);
    }
}
