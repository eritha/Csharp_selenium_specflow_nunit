using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using NUnit.Framework;

public enum Method
{
    GET,
    POST,
    PUT,
    DELETE
}

namespace Csharp_selenium_specflow_nunit.Utility
{
    public class HttpSendRequest
    {
        public static void Main(string[] args)
        {
            Configs.InitDataConfig();
            SendGETRequest("/users");

            //var client = new Client();
            //client.ApiDomain = ApiEndPoint;
            //client.Method = Verb.GET;
            //var pdata = client.PostData;
            //var response = client.Request("/users");
        }

        public static void SendGETRequest(string apiEndPoint, Boolean saveFile = true)
        {
            var client = new Client();
            client.Method = Method.GET;
            var response = client.SendRequest(apiEndPoint, HttpStatusCode.OK);
            if (saveFile)
            {
                // Save response to JSON File
                FileUtils.WriteStringToFile(response, client.Method + "_RESPONSE" + apiEndPoint.Replace('/', '_') + ".json");
                FileUtils.ReadJsonArray(client.Method + "_RESPONSE" + apiEndPoint.Replace('/', '_') + ".json", "$.name");
            }
        }

        public void SendPOSTRequest(string apiEndPoint, string postData, Boolean saveFile = true)
        {
            var client = new Client(Configs.varApiDomain, Configs.varApiAuthorization, Method.POST, postData);
            var response = client.SendRequest(apiEndPoint, HttpStatusCode.Created);
            if (saveFile)
            {
                // Save response to JSON File
                FileUtils.WriteStringToFile(response, client.Method + "_RESPONSE" + apiEndPoint.Replace('/', '_') + ".json");
            }
        }

        public void SendPUTRequest(string apiEndPoint, string putData, Boolean saveFile = true)
        {
            var client = new Client(Configs.varApiDomain, Configs.varApiAuthorization, Method.PUT, putData);
            var response = client.SendRequest(apiEndPoint, HttpStatusCode.OK);
            if (saveFile)
            {
                // Save response to JSON File
                FileUtils.WriteStringToFile(response, client.Method + "_RESPONSE" + apiEndPoint.Replace('/', '_') + ".json");
            }
        }
        public static void SendDELETERequest(string apiEndPoint)
        {
            var client = new Client();
            client.Method = Method.DELETE;
            var response = client.SendRequest(apiEndPoint, HttpStatusCode.OK);
        }
    }
    public class Client
    {
        //private static string fResponseJson = "_".Concat(PropertiesUtils.environmentTest).concat("_response.json");

        private string _apiDomain = Configs.varApiDomain;
        private string _authorization = Configs.varApiAuthorization;
        private string _contentType = "application/json";
        private string _accept = "application/json";
        private string _acceptLanguage = "en-US";
        public string ApiDomain
        {
            get;
            set;
        }
        public Method Method
        {
            get;
            set;
        }
        public string Author
        {
            get;
            set;
        }
        public string ContentType
        {
            get;
            set;
        }

        public string Accept
        {
            get;
            set;
        }

        public string AcceptLanguage
        {
            get;
            set;
        }
        public string BodyData
        {
            get;
            set;
        }

        public Client()
        {
            ApiDomain = _apiDomain;
            //Method = Method.GET;
            //Author = _authorization;
            //ContentType = _contentType;
            //Accept = _accept;
            //AcceptLanguage = _acceptLanguage;
            //BodyData = "";
        }

        public Client(string domain, string authorization, Method method, string postData)
        {
            ApiDomain = domain;
            Method = method;
            Author = _authorization;
            ContentType = _contentType;
            Accept = _accept;
            AcceptLanguage = _acceptLanguage;
            BodyData = postData;
        }

        //public string Request()
        //{
        //    return Request("");
        //}

        public string SendRequest(string apiEndPoint, HttpStatusCode httpStatusCode)
        {
            var request = (HttpWebRequest)WebRequest.Create(ApiDomain + apiEndPoint);
            request.Method = Method.ToString();
            if (!string.IsNullOrEmpty(Author)) request.Headers["Authorization"] = Author;
            request.ContentType = ContentType;
            //if (string.IsNullOrEmpty(BodyData))
            //{

            //}
            var responseValue = string.Empty;

            if (Method.Equals(Method.POST) || Method.Equals(Method.PUT))
            {
                byte[] data = Encoding.ASCII.GetBytes(BodyData);
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);

                    var response = (HttpWebResponse)request.GetResponse();

                    Console.WriteLine("Code >>> " + response.StatusCode.ToString());
                    if (response.StatusCode != httpStatusCode)
                    {
                        var message = String.Format("Faile: Received HTTP {0}", response.StatusCode);
                        throw new ApplicationException(message);
                    }

                    using (var responseStream = response.GetResponseStream())

                    {
                        if (responseStream != null)
                            using (var reader = new StreamReader(responseStream))
                            {
                                responseValue = reader.ReadToEnd();
                            }
                    }
                    Console.WriteLine("Value >>> " + responseValue.ToString());

                }
            }
            else
            {
                request.ContentLength = 0;
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    Console.WriteLine("Code >>> " + response.StatusCode.ToString());
                    if (response.StatusCode != httpStatusCode)
                    {
                        var message = String.Format("Faile: Received HTTP {0}", response.StatusCode);
                        throw new ApplicationException(message);
                    }

                    using (var responseStream = response.GetResponseStream())

                    {
                        if (responseStream != null)
                            using (var reader = new StreamReader(responseStream))
                            {
                                responseValue = reader.ReadToEnd();
                            }
                    }
                    Console.WriteLine("Value >>> " + responseValue.ToString());

                }
            }
            return responseValue;
        }
    }
}
//    //  http GET request
//    public static String sendingGetRequest(String authorization, String pathRequest, String fileName)
//    {
//        try
//        {
//            String urlRequest = APIData.SERVER_API.concat(pathRequest);
//            URL obj = new URL(urlRequest);
//            HttpURLConnection con = ((HttpURLConnection)(obj.openConnection()));
//            LogUtils.info(("sending GET with api: " + pathRequest));
//            //  optional default is GET
//            con.setRequestMethod(APIData.GET_METHOD);
//            //  add request header
//            con.setRequestProperty(HttpHeaders.CONTENT_TYPE, APIData.CONTENT_TYPE);
//            con.setRequestProperty(HttpHeaders.AUTHORIZATION, authorization);
//            int responseCode = con.getResponseCode();
//            //             System.out.println("Response code is: "+responseCode);
//            LogUtils.info(("Response code is: " + responseCode));
//            BufferedReader in = new BufferedReader(new InputStreamReader(con.getInputStream()));
//            String inputLine;
//            StringBuffer response = new StringBuffer();
//            while ((in.readLine() != null)) {
//                response.append(inputLine);
//            }

//            in.close();
//                //  Read response
//                //             System.out.println("Response data GET: " + response.toString());
//                //  Save string to File Name
//                if ((fileName.length() != 0))
//                {
//                    FileUtils.writeStringToFile(response.toString(), APIData.GET_METHOD.concat(File.separator).concat(fileName).concat(fResponseJson));
//                }

//                return response.toString();
//            }
//            catch (Exception e)
//            {
//                Result.checkFail(("Class HttpSendRequest | Method sendingGetRequest | Exception desc : " + e.getMessage()));
//                return null;
//            }

//        }

//        //  http POST request
//        public static String sendingPostRequest(String authorization, String pathRequest, String bodyData, String fileName)
//        {
//            try
//            {
//                String urlRequest = APIData.SERVER_API.concat(pathRequest);
//                System.out.println(APIData.SERVER_API.concat(pathRequest));
//                LogUtils.info(("sending POST with bodyData: "
//                                + (bodyData + (" and api: " + pathRequest))));
//                //  Create request connection
//                URL obj = null;
//                try
//                {
//                    obj = new URL(urlRequest);
//                }
//                catch (MalformedURLException e)
//                {
//                    e.printStackTrace();
//                }

//                HttpURLConnection con = null;
//                try
//                {
//                    assert obj;
//                    null;
//                    con = ((HttpURLConnection)(obj.openConnection()));
//                }
//                catch (IOException e)
//                {
//                    e.printStackTrace();
//                }

//                //  optional default is POST
//                assert con;
//                null;
//                con.setRequestMethod(APIData.POST_METHOD);
//                //  add request header
//                con.setRequestProperty(CONTENT_ENCODING, "UTF-8");
//                con.setRequestProperty(HttpHeaders.CONTENT_TYPE, APIData.CONTENT_TYPE);
//                if ((authorization.length() != 0))
//                {
//                    con.setRequestProperty(HttpHeaders.AUTHORIZATION, authorization);
//                }

//                //  send post request
//                con.setDoOutput(true);
//                DataOutputStream wr = new DataOutputStream(con.getOutputStream());
//                //             String data = "{\"username\": \"shopdeal1@yopmail.com\",\"password\": \"123456\",\"rememberMe\": true}";
//                if ((bodyData.length() != 0))
//                {
//                    wr.writeBytes(bodyData);
//                }

//                wr.flush();
//                wr.close();
//                int responseCode = con.getResponseCode();
//                LogUtils.info(("Response Code : " + responseCode));
//                //             System.out.println("Response Code : " + responseCode);
//                BufferedReader in = new BufferedReader(new InputStreamReader(con.getInputStream()));
//                String output;
//                //  get response after post successfully
//                StringBuffer response = new StringBuffer();
//                while ((in.readLine() != null)) {
//                    response.append(output);
//                }

//            in.close();
//                //  printing result from response
//                System.out.println(("Response data POST: " + response.toString()));
//                //  save response to file
//                if ((fileName.length() != 0))
//                {
//                    FileUtils.writeStringToFile(response.toString(), APIData.POST_METHOD.concat(File.separator).concat(fileName).concat(fResponseJson));
//                }

//                return response.toString();
//            }
//            catch (Exception e)
//            {
//                Result.checkFail(("Class HttpSendRequest | Method sendingPostRequest | Exception desc : "
//                                + (e.getMessage() + ("\n+++++++Body data++++++++\n" + bodyData))));
//                return null;
//            }

//        }

//        //  http PUT request
//        public static void sendingPutRequest(String authorization, String pathRequest)
//        {
//            try
//            {
//                String urlRequest = APIData.SERVER_API.concat(pathRequest);
//                LogUtils.info(("sending PUT with api: " + pathRequest));
//                //  Create request connection
//                URL obj = null;
//                try
//                {
//                    obj = new URL(urlRequest);
//                }
//                catch (MalformedURLException e)
//                {
//                    e.printStackTrace();
//                }

//                HttpURLConnection con = null;
//                try
//                {
//                    assert obj;
//                    null;
//                    con = ((HttpURLConnection)(obj.openConnection()));
//                }
//                catch (IOException e)
//                {
//                    e.printStackTrace();
//                }

//                //  Setting basic put request
//                assert con;
//                null;
//                con.setRequestMethod(APIData.PUT_METHOD);
//                //             con.setRequestProperty(USER_AGENT, "Mozilla/5.0");
//                con.setRequestProperty(CONTENT_TYPE, APIData.CONTENT_TYPE);
//                con.setRequestProperty(AUTHORIZATION, authorization);
//                //  Send put request
//                con.setDoOutput(true);
//                DataOutputStream wr = new DataOutputStream(con.getOutputStream());
//                wr.flush();
//                wr.close();
//                int responseCode = con.getResponseCode();
//                LogUtils.info(("Response Code : " + responseCode));
//                //             System.out.println("Response Code : " + responseCode);
//            }
//            catch (Exception e)
//            {
//                Result.checkFail(("Class HttpSendRequest | Method sendingPutRequest | Exception desc : " + e.getMessage()));
//            }

//        }

//        //  http PUT request
//        public static String sendingPutRequest(String authorization, String pathRequest, String bodyData, String fileName)
//        {
//            try
//            {
//                String urlRequest = APIData.SERVER_API.concat(pathRequest);
//                System.out.println(APIData.SERVER_API.concat(pathRequest));
//                //  Create request connection
//                URL obj = null;
//                try
//                {
//                    obj = new URL(urlRequest);
//                }
//                catch (MalformedURLException e)
//                {
//                    e.printStackTrace();
//                }

//                HttpURLConnection con = null;
//                try
//                {
//                    assert obj;
//                    null;
//                    con = ((HttpURLConnection)(obj.openConnection()));
//                }
//                catch (IOException e)
//                {
//                    e.printStackTrace();
//                }

//                //  optional default is PUT
//                assert con;
//                null;
//                con.setRequestMethod(APIData.PUT_METHOD);
//                //  add request header
//                con.setRequestProperty(CONTENT_ENCODING, "UTF-8");
//                con.setRequestProperty(HttpHeaders.CONTENT_TYPE, APIData.CONTENT_TYPE);
//                if ((authorization.length() != 0))
//                {
//                    con.setRequestProperty(HttpHeaders.AUTHORIZATION, authorization);
//                }

//                //  send post request
//                con.setDoOutput(true);
//                DataOutputStream wr = new DataOutputStream(con.getOutputStream());
//                //             String data = "{\"username\": \"shopdeal1@yopmail.com\",\"password\": \"123456\",\"rememberMe\": true}";
//                if ((bodyData.length() != 0))
//                {
//                    wr.writeBytes(bodyData);
//                }

//                wr.flush();
//                wr.close();
//                int responseCode = con.getResponseCode();
//                LogUtils.info(("Response Code : " + responseCode));
//                //             System.out.println("Response Code : " + responseCode);
//                BufferedReader in = new BufferedReader(new InputStreamReader(con.getInputStream()));
//                String output;
//                //  get response after put successfully
//                StringBuffer response = new StringBuffer();
//                while ((in.readLine() != null)) {
//                    response.append(output);
//                }

//            in.close();
//                //  save response to file
//                if ((fileName.length() != 0))
//                {
//                    FileUtils.writeStringToFile(response.toString(), APIData.PUT_METHOD.concat(File.separator).concat(fileName).concat(fResponseJson));
//                }

//                return response.toString();
//            }
//            catch (Exception e)
//            {
//                Result.checkFail(("Class HttpSendRequest | Method sendingPutRequest | Exception desc : "
//                                + (e.getMessage() + ("\n+++++++Body data++++++++\n" + bodyData))));
//                return null;
//            }

//        }

//        //  http DELETE request
//        public static void sendingDeleteRequest(String authorization, String pathRequest)
//        {
//            try
//            {
//                String urlRequest = APIData.SERVER_API.concat(pathRequest);
//                LogUtils.info(("sending DELETE with api: " + pathRequest));
//                //  Create request connection
//                URL obj = null;
//                try
//                {
//                    obj = new URL(urlRequest);
//                }
//                catch (MalformedURLException e)
//                {
//                    e.printStackTrace();
//                }

//                HttpURLConnection con = null;
//                try
//                {
//                    assert obj;
//                    null;
//                    con = ((HttpURLConnection)(obj.openConnection()));
//                }
//                catch (IOException e)
//                {
//                    e.printStackTrace();
//                }

//                //  Setting basic post request
//                assert con;
//                null;
//                con.setRequestMethod(APIData.DELETE_METHOD);
//                //             con.setRequestProperty(USER_AGENT, "Mozilla/5.0");
//                con.setRequestProperty(CONTENT_TYPE, APIData.CONTENT_TYPE);
//                con.setRequestProperty(AUTHORIZATION, authorization);
//                //  Send delete request
//                con.setDoOutput(true);
//                DataOutputStream wr = new DataOutputStream(con.getOutputStream());
//                wr.flush();
//                wr.close();
//                int responseCode = con.getResponseCode();
//                LogUtils.info(("Response Code : " + responseCode));
//                //             System.out.println("Response Code : " + responseCode);
//            }
//            catch (Exception e)
//            {
//                Result.checkFail(("Class HttpSendRequest | Method sendingDeleteRequest | Exception desc : " + e.getMessage()));
//            }

//        }

//        public static void main(String[] args)
//        {
//            HttpSendRequest.sendingGetRequest(@"Bearer eyJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJiZWVjb3d1c2VyX3ZuIiwiYXV0aCI6IlJPTEVfR1VFU1QsUk9MRV9CRUVDT1ciLCJkaXNwbGF5TmFtZSI6IkJlZWNvdyBWaWV0bmFtIEJlZWNvdyBWaWV0bmFtIiwidXNlcklkIjo4LCJsb2NhdGlvbkNvZGUiOiJWTi1TRyIsImV4cCI6MTU2MzM2NzY0OX0.aOgIb6h8nWURT65szAyNtXRdjO_aP-0-l82HahDElMSs6R51WWXomnEVptbhwlF-IeHntJYx2g53xVZc17ZHGg", "api/account", "api_account");
//        }
//    }
// }