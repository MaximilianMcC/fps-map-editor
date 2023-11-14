import javax.swing.SwingUtilities;

public class Main {
	
	public static void main(String[] args) {		
		System.out.println("ok");

		SwingUtilities.invokeLater(() -> {
			new Window();
		});
	}
}
