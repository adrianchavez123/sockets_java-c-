using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace ClienteGUI
{
    public partial class Form1 : Form
    {
         TcpClient tc;
        NetworkStream ns;
        StreamWriter sw;
        StreamReader sr;
        Thread recibir;
        delegate void MyDelegado(string text);
        MySqlConnection Conexion = new MySqlConnection();
        String conexionString;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect();
        }

        private void connect()
        {
              try
              {
                  string ip = textBoxIp.Text;
                  int puerto = Convert.ToInt16(textBoxPuerto.Text);
                tc=new TcpClient(ip,puerto);
                // Console.WriteLine("Server invoked"); 
                 ns=tc.GetStream(); 
                 sw=new StreamWriter(ns);
                 //sw.WriteLine("My name is Pramod.A");
                 //sw.Flush();
                 sr = new StreamReader(ns);
                 recibir = new Thread(new ThreadStart(recibir_mensaje));
                 recibir.Start();

                 visibleA(false);
                
              }
              catch(Exception e)
              {
                  MessageBox.Show(e.ToString(), "Error");
                } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string mensaje = textBoxMensaje.Text;
            if (mensaje.Equals("salir"))
            {
                sw.WriteLine(mensaje);
                sw.Flush();
                textBoxMensaje.Clear();
                conversacion.AppendText(mensaje + "\n");
                desconectar();
            }
            else
            {
                sw.WriteLine(mensaje);
                sw.Flush();
                textBoxMensaje.Clear();
                conversacion.AppendText(mensaje + "\n");
                insertar(mensaje);
            }

        }

        private void visibleA(bool b)
        {
            textBoxIp.Enabled = b;
            textBoxPuerto.Enabled = b;
            lblIp.Enabled = b;
            lblPuerto.Enabled = b;
            button1.Enabled = false;

        }
        private void desconectar()
        {
            try
            {
                recibir.Abort();
                sw.Close();
                sr.Close();
                tc.Close();
                visibleA(true);
            }
            catch (Exception e) { }
            
        }

        private void recibir_mensaje()
        {
            while (true)
            {
                try
                {
                    String mensaje = sr.ReadLine();
                    if (mensaje.Equals("salir"))
                    {
                        desconectar();
                    }
                    else
                    {
                        //MessageBox.Show(mensaje, "recibido");
                        MyDelegado MD = new MyDelegado(append);
                        this.Invoke(MD, new object[] { mensaje });
                        //append(mensaje);
                    }
                    Thread.Sleep(100);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(), "Error");

                }
            }
        }

        private void insertar(String mensaje)
        {
            try
            {
                conexionString = "Server=localhost; Database=socket;Uid=root; Pwd=1234;";
                Conexion.ConnectionString = conexionString;
                Conexion.Open();
                string consulta = " insert into cliente values(null,'" + mensaje + "',now())";
                MySqlCommand c = new MySqlCommand(consulta, Conexion);
                c.BeginExecuteNonQuery();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Ocurrio un error al conectar", "Error");
            }

            Conexion.Close();
        }

        private void append(string mensaje)
        {
            conversacion.AppendText(mensaje + "\n");
        }

        
    }
}
