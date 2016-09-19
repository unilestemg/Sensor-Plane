using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace CompiladorDeChaves
{
    class Program
    {
        public static SerialPort portaSerial;


        static void Main(string[] args)
        {
            portaSerial = new SerialPort();
            conexaoSerial();
            Console.ReadLine();
            Console.ReadKey();
        }


        private static void conexaoSerial()
        {
            try
            {
                var portas = SerialPort.GetPortNames();
                foreach (var com in portas)
                {
                    portaSerial.PortName = com.ToString();
                }
               
                portaSerial.Open();
                MessageBox.Show("Conectado na porta serial: " + portaSerial.PortName.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            portaSerial.DataReceived += PortaSerial_DataReceived1;
        }

        private static void PortaSerial_DataReceived1(object sender, SerialDataReceivedEventArgs e)
        {
            string dado = portaSerial.ReadExisting();

            if (dado.ToString().Equals("w"))
            {
                SendKeys.SendWait("^{w}");
            }
            else
            {
                SendKeys.SendWait("^{DOWN}");
            }
            Console.WriteLine(dado.ToString());
        }
    }
}
