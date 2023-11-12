class CreateNewMap
{
	// Window UI elements
	private TextInput mapName;
	private Button submitButton;
	private Paragraph text;

	public CreateNewMap()
	{
		// Make a new window
		Window window = new Window("New map", 10, 10, 500, true);
		Editor.Windows.Add(window);

		// Instantiate all of the UI elements
		mapName = new TextInput("Map Name:");
		submitButton = new Button("Create", () => MakeNewMap());
		text = new Paragraph();

		// Add all of the UI elements
		window.AddElement(mapName);
		window.AddElement(submitButton);
		window.AddElement(text);
	}

	// Make a new map
	private void MakeNewMap()
	{
		Console.WriteLine("Making new map rn");

		// Make the file name
		// Remove spaces, and remove illegal filename characters
		string mapFileName = mapName.Text.ToLower();
		mapFileName = mapFileName.Replace(' ', '-');
		mapFileName = mapFileName.Replace('\\', '\0').Replace('/', '\0').Replace(':', '\0').Replace('*', '\0').Replace('?', '\0').Replace('"', '\0').Replace('<', '\0').Replace('>', '\0').Replace('|', '\0').Replace('#', '\0');
		mapFileName += ".map";

		// Check for if the name is empty/noting
		if (mapFileName == "") return;

		// Make the start/beginning of the file
		string contents = mapName.Text;

		// Make the actual file for the map
		File.WriteAllText(mapFileName, contents);
	}
}