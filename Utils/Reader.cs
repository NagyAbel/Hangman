using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace NagyAbel.Utils
{
    static class Reader
    {
        public static string ReadString(string pre_text, params string[] valid_inputs)
        {
            bool valid = false;
            string response = "";
            while (!valid){
                Writer.Write(pre_text, Globals.fast);

                response = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(response))continue;
                response = response.Trim().ToLower();
                //All response are valid
                if(valid_inputs.Length == 0)return response;

                //Allow only specific responses
                foreach (var option in valid_inputs){
                    if (response == option.ToLower()){
                                return response;
                    }
                }
            }
            return response;
        }

        public static int ReadInt(string pre_text, params int[] valid_inputs)
        {
            bool valid = false;
            int response = -1;
            while (!valid)
            {
                Writer.Write(pre_text, Globals.fast);
                string input = Console.ReadLine() ?? "";
                int.TryParse(input,out response);
                foreach (var option in valid_inputs){
                    if (response == option){
                            return response;
                    }
                }                
            }
            return response;
        }

        public static char ReadChar(string pre_text){
            bool valid = false;
            string response = "";
            while (!valid)
            {
                Writer.Write(pre_text, Globals.fast);
                response = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(response))continue;
                response = response.Trim().ToLower();
                if (response.Length > 1 || char.IsDigit(response[0]))continue;
                return response[0];
            }
            return response[0];
        }



    }
}