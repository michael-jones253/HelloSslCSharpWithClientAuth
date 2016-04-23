using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloSslClient
{
    class Program
    {
        public static int Main(string[] args)
        {
            try
            {
                string serverName = null;
                string machineName = null;
                string clientCert = null;
                int port = 8080;

                if (args == null || args.Length < 1)
                {
                    System.Console.WriteLine("Usage error");
                    return -1;
                }

                // User can specify the machine name and server name.
                // Server name must match the name on the server's certificate. 


                for (var argc = 0; argc < args.Length; argc++)
                {
                    if (args[argc] == "--clientcert")
                    {
                        clientCert = args[++argc];
                    }

                    if (args[argc] == "--machine")
                    {
                        machineName = args[++argc];
                    }

                    if (args[argc] == "--server")
                    {
                        serverName = args[++argc];
                    }

                    if (args[argc] == "--port")
                    {
                        var portNum = args[++argc];
                        port = Int32.Parse(portNum);
                    }
                }

                var client = new SslTcpClient(serverName, clientCert, machineName);
                client.RunClient(port);
                return 0;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Client exit: {0}", ex.Message);
            }
            finally
            {
            }

            return -1;
        }
    }
}
