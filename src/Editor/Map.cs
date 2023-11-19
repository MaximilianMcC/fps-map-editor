using System.Numerics;
using System.Text;
using Raylib_cs;

struct Location
{
	public Model Model { get; set; }
	public Vector3 Position { get; set; }
	public Vector3 Rotation { get; set; }
	public Texture2D Texture { get; set; }
}

class Map
{
	public string Name { get; set; }
	public List<Texture2D> Textures { get; set; }
	public List<Model> Models { get; set; }
	public List<Location> Things { get; set; }

	// Make a new map file
	public Map(string path, string name)
	{
		Console.WriteLine("Making map");

		// Get the filename
		string fileName = name.ToLower();
		fileName = fileName.Replace(' ', '-');
		fileName = fileName.Replace('\\', '\0').Replace('/', '\0').Replace(':', '\0').Replace('*', '\0').Replace('?', '\0').Replace('"', '\0').Replace('<', '\0').Replace('>', '\0').Replace('|', '\0').Replace('#', '\0');
		if (fileName == "") fileName = "myVeryFirstMapThatImMakingWithFPSMapEditor";

		// Write to the file. Add the name, and end section
		string contents = $"{name}\n---\nend";

		// Make the actual file for the map
		fileName = $"{path}/{fileName}.map";
		File.WriteAllText(fileName, contents);

		// Load the map that we just made
		Parse(fileName);
	}

	// Load a map file
	public Map(string filepath)
	{
		Parse(filepath);
	}

	// Load a map
	private void Parse(string filePath)
	{
		// Reset map
		Textures = new List<Texture2D>();
		Models = new List<Model>();
		Things = new List<Location>();

		// Get the contents of the filepath
		string[] contents = File.ReadAllLines(filePath);

		// Remove comments
		// TODO: Add support for `//` style also
		List<string> contentsNoComments = new List<string>();
		const string commentPrefix = "#";
		for (int i = 0; i < contents.Length; i++)
		{
			// Get the current line
			string line = contents[i];

			// Check for if the entire line is a comment or empty
			if (line == "" || line.StartsWith(commentPrefix)) continue;

			// Check for if a portion of a line is a comment
			int commentIndex = line.IndexOf(commentPrefix);
			if (commentIndex >= 0) line = line.Substring(0, commentIndex);

			// Add the line without comment to the list of comment-less lines
			contentsNoComments.Add(line);
		}
		contents = contentsNoComments.ToArray();

		// Split up the map into little "chunks" that are deduced by lines
		// Also clean the chunks to get rid of the crap like newlines and whatnot
		string[][] chunks;
		List<string[]> chunksCleaned = new List<string[]>();
		foreach (string chunk in string.Join('\n', contents).Split("---"))
		{
			List<string> currentChunk = new List<string>();
			foreach (string item in chunk.Split('\n'))
			{
				Console.WriteLine($"{item}");
				// Filter out all the crap
				if (!string.IsNullOrWhiteSpace(item)) currentChunk.Add(item.Trim());
				
			}
			chunksCleaned.Add(currentChunk.ToArray());
		}
		chunks = chunksCleaned.ToArray();

		// TODO: Split up all of the parsing for different chunks (except this one) into different methods
		// Check for if the ending chunk is there. If its not then there is something
		// wrong with the map and it will need to be regenerated or something
		//! if (chunks[chunks.Length - 1] != "end")
		//! {
		//! 	Console.WriteLine("Error while reading map file (no end) (please add one)👲");
		//! 	return;
		//! }

		// Get the map name
		Name = chunks[0][0].Trim();

		// Get the map model paths, then load them
		foreach (string item in chunks[1])
		{
			// Get the path of the model
			// TODO: Add the `./assets/textures` part somewhere in the file and not hardcode
			string modelPath = item.Split(' ')[1];
			modelPath = $"./assets/models/{modelPath}.obj";

			// Load the model and add the model into the model list
			Model model = Raylib.LoadModel(modelPath);
			Models.Add(model);

			Console.WriteLine("Loaded" + modelPath);
		}

		// Get the map texture paths, then load them
		foreach (string item in chunks[2])
		{
			// Get the path of the texture
			// TODO: Add the `./assets/textures` part somewhere in the file and not hardcode
			string texturePath = item.Split(' ')[1];
			texturePath = $"./assets/textures/{texturePath}.png";

			// Load the texture and add the texture into the texture list
			Texture2D texture = Raylib.LoadTexture(texturePath);
			Textures.Add(texture);

			Console.WriteLine("Loaded" + texturePath);
		}

		// Get the positions of everything in the map (the actual map)
		foreach (string item in chunks[3])
		{
			// Split up the position into all of its different sections
			string[] positionInfoString = item.Split(" ");
			int[] positionInfo = positionInfoString.Select(int.Parse).ToArray();

			// Get all of the sections
			Location location = new Location();
			location.Model = Models[positionInfo[0]];
			location.Position = new Vector3(positionInfo[1], positionInfo[2], positionInfo[3]);
			location.Rotation = new Vector3(positionInfo[4], positionInfo[5], positionInfo[6]);
			location.Texture = Textures[positionInfo[7]];
			
			// Add them to the list
			Things.Add(location);
		}

	}
}