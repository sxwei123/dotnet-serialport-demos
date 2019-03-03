using System;
using System.IO.Ports;

namespace serial_read
{
    class Program
    {
        static SerialPort _serialPort;
        static void Main(string[] args)
        {
            Console.Write("Port no: ");
            string port = Console.ReadLine();
            Console.Write("baudrate: ");
            string baudrate = Console.ReadLine();
            // Create a new SerialPort on port COM7
            _serialPort = new SerialPort(port, int.Parse(baudrate));


            // Set the read/write timeouts
            _serialPort.ReadTimeout = 1500;
            _serialPort.WriteTimeout = 1500;

            _serialPort.Open();


            while (true)
            {
                Read();
            }

            _serialPort.Close();
        }

        public static void Read()
        {
            try
                {
                    string message = _serialPort.ReadLine();
                    Console.WriteLine(message);
                }
            catch (TimeoutException) { }
        }
    }
}
