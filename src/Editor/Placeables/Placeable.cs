using System.Numerics;
using Raylib_cs;

class Placeable
{
	// Transform stuff
	public Vector3 Position { get; set; }
	public Vector3 Rotation { get; set; }
	public Vector3 Scale { get; set; }

	// 3D stuff
	public Model Model { get; private set; }





	public Placeable(string modelPath)
	{
		// Load in the model
		Model model = Raylib.LoadModel(modelPath);
		Model = model;
	}
}