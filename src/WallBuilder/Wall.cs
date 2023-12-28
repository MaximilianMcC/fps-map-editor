using System.Numerics;

class Wall
{
	// Wall dimension thingys
	public float Height { get; set; }
	public Vector2 PointA { get; set; }
	public Vector2 PointB { get; set; }
	public Vector3 TopLeft { get; set; }
	public Vector3 TopRight { get; set; }
	public Vector3 BottomLeft { get; set; }
	public Vector3 BottomRight { get; set; }



	//! All measurements are in meters btw
	public Wall(Vector2 pointA, Vector2 pointB)
	{
		// Set a default height
		// TODO: Make a way to change this
		Height = 2;

		// Assign the points
		PointA = pointA;
		PointB = pointB;


		// Get all four vertices of the wall
		// TODO: Don't use the build in RayLib way of doing this. Instead write the OBJ files
		TopLeft = new Vector3(PointA.X, Height, PointA.Y);
		TopRight = new Vector3(PointB.X, Height, PointB.Y);
		BottomLeft = new Vector3(PointA.X, 0, PointA.Y);
		BottomRight = new Vector3(PointB.X, 0, PointB.Y);
	}
}