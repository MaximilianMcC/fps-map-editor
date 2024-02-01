using System.Numerics;
using Raylib_cs;

class Viewer
{
	public static Camera3D Camera;

	public static void Start()
	{
		// Setup the camera stuff
		Camera = new Camera3D()
		{
			position = new Vector3(-10f, 5f, 0f),
			target = Vector3.Zero,
			up =  Vector3.UnitY,
			fovy = 60,
			projection = CameraProjection.CAMERA_PERSPECTIVE
		};

		Raylib.DisableCursor();
	}

	public static void Update()
	{
		Raylib.UpdateCamera(ref Camera, CameraMode.CAMERA_FREE);
	}
}