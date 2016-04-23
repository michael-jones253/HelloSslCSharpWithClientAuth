using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examples.System.Net;
using System.Security.Cryptography;

namespace HelloSsl
{
    public class Program
    {
        static int Main(string[] args)
        {
            string certificate = null;
            bool authClient = false;
            bool checkRevoke = false;

            for (var argc = 0; argc < args.Length; argc++)
            {
                if (args[argc] == "--cert")
                {
                    certificate = args[++argc];
                }

                if (args[argc] == "--authclient")
                {
                    authClient = true;
                }

                if (args[argc] == "--checkrevoke")
                {
                    checkRevoke = true;
                }
            }

            try
            {
                var server = new SslTcpServer(certificate, authClient, checkRevoke);
                server.Run();
            }
            catch (CryptographicException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
            }
            return 0;
        }
    }
}
