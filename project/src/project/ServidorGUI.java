package project;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.io.PrintWriter;
import java.net.ServerSocket;
import java.net.Socket;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.Statement;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JTextArea;
import javax.swing.JTextField;

public class ServidorGUI extends JFrame implements Runnable {

	JTextField txtPuerto = new JTextField();
	JButton conectar = new JButton("Conectar");
	JTextArea conversacion = new JTextArea(10, 30);
	JButton enviar = new JButton("Enviar");
	JTextField mensaje = new JTextField("");

	JLabel lblpuerto = new JLabel("Puerto");
	JLabel lblmen = new JLabel("Mensaje");

	ServerSocket ss;
	Socket s;
	BufferedReader br;
	PrintWriter wr;
	Thread recibir;

	public ServidorGUI() {
		setSize(500, 300);
		setDefaultCloseOperation(EXIT_ON_CLOSE);
		setLayout(null);
		init();
	}

	private void init() {

		lblpuerto.setBounds(20, 30, 100, 20);
		lblmen.setBounds(20, 70, 100, 20);

		txtPuerto.setBounds(20, 50, 100, 24);
		conectar.setBounds(300, 50, 100, 24);
		mensaje.setBounds(20, 100, 200, 24);
		enviar.setBounds(300, 100, 100, 24);
		conversacion.setBounds(20, 150, 400, 100);

		add(txtPuerto);
		add(conectar);
		add(mensaje);
		add(enviar);
		add(conversacion);
		add(lblmen);
		add(lblpuerto);

		conectar.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				int x = Integer.parseInt(txtPuerto.getText());
				connect(x);
			}
		});

		enviar.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {

				String mens = mensaje.getText();
				if (mens.equals("salir")) {
					wr.println(mens);
					desconectar();
				} else {
					wr.println(mens);
					mensaje.setText("");
					conversacion.append(mens + "\n");
					insertar(mens);
				}
			}

		});

	}

	private void connect(int puerto) {
		try {
			ss = new ServerSocket(puerto);
			s = ss.accept();
			System.out.println("Client Accepted");
			br = new BufferedReader(new InputStreamReader(s.getInputStream()));

			recibir = new Thread(this, "recibir");
			recibir.start();
			wr = new PrintWriter(new OutputStreamWriter(s.getOutputStream()),
					true);

			visible(false);

		} catch (Exception e) {
			System.out.println(e);
		}

	}

	public static void main(String[] args) {

		new ServidorGUI().setVisible(true);
	}

	@Override
	public void run() {
		// TODO Auto-generated method stub
		if (Thread.currentThread().getName().equals("recibir")) {
			while (true) {
				try {
					String mensaje = br.readLine();
					if (mensaje.equals("salir")) {
						desconectar();
					} else {
						System.out.println(mensaje);
						conversacion.append(mensaje + "\n");
						Thread.sleep(100);
					}
				} catch (Exception e) {
					JOptionPane.showMessageDialog(null, e.getMessage());
				}
			}
		}
	}

	private void desconectar() {
		try {
			recibir.destroy();
			br.close();
			wr.close();
			s.close();
			ss.close();
			visible(true);
		} catch (Exception e) {

		}
	}

	private void insertar(String mens) {

		try {
			Connection con;
			Statement stm;
			con = DriverManager.getConnection(
					"jdbc:mysql://localhost:3306/socket", "root", "1234");

			stm = con.createStatement();

			String consulta = "insert into servidor values(null,'" + mens
					+ "',now())";
			System.out.println(consulta);
			stm.executeUpdate(consulta);

			stm.close();
			con.close();
		} catch (Exception e) {
			JOptionPane.showMessageDialog(null, e.getMessage());
		}

	}

	private void visible(boolean b) {
		conectar.setEnabled(b);
		lblpuerto.setEnabled(b);
		txtPuerto.setEnabled(b);
	}
}
