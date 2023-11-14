import javax.swing.JFrame;
import javax.swing.JLabel;

public class Window extends JFrame {

	public Window() {

		// Set up the window
		super("m 2");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setSize(400, 300);

		add(new JLabel("map edior"));

		setVisible(true);
	}
}