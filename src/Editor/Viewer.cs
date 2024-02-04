using System.Numerics;
using Raylib_cs;

class Viewer
{
	public static Camera3D Camera;
	public static Vector3 Position { get; set; } = new Vector3(0, 0, 0);
	public static float Pitch { get; set; } = 0;
	public static float Yaw { get; set; } = 0;

	private static float sensitivity = 150f;
	private static float speed = 70f;

	private static Vector3 forward;
	private static Vector3 forwardDirection;
	private static Vector3 right;
	private static Vector3 up;

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
		MouseMovement();
		KeyboardMovement();

		// Update the camera
		Camera.position = Position;
		Camera.target = Camera.position + forwardDirection;
	}

	private static void MouseMovement()
	{
		// Get the mouse movement in degrees
		Vector2 mouseDelta = Raylib.GetMouseDelta() * sensitivity;
		float mouseX = mouseDelta.X / Raylib.GetScreenWidth();
		float mouseY = mouseDelta.Y / Raylib.GetScreenHeight();

		// Update the pitch and yaw values
		Pitch -= mouseY;
		Yaw -= mouseX;

		// Clamp the pitch from -90 to 90 in degrees
		// and keep yaw between 0 and 360 degrees
		// TODO: Remove gimbal lock
		Pitch = Math.Clamp(Pitch, -90f, 90f);
		Yaw %= 360f;

		// Convert into a quaternion to make working with rotations easier
		Quaternion rotation = Quaternion.CreateFromYawPitchRoll(DegreesToRadians(Yaw), DegreesToRadians(Pitch), 0);

		// Calculate target for moving forwards and right
		forward = Vector3.Transform(new Vector3(0, 0, -1), rotation);
		right = Vector3.Transform(new Vector3(1, 0, 0), rotation);

		// Assign the direction Forward for controlling camera rotation
		forwardDirection = Vector3.Transform(new Vector3(0, 0, -1), rotation);
	}


	private static void KeyboardMovement()
	{
		float dt = Raylib.GetFrameTime();  // Delta time - time since last frame

		// Move forward
		if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
			Position += forward * speed * dt;

		// Move backward
		if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
			Position -= forward * speed * dt;

		// Strafe right
		if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
			Position += right * speed * dt;

		// Strafe left
		if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
			Position -= right * speed * dt;
	}


	private static float DegreesToRadians(float degrees)
	{
		return degrees * (MathF.PI / 180);
	}
}