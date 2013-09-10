using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Security.Principal;
using System.Net;
using System.IO;
using System.Text;


namespace ICTGWS.Handlers
{
    // This class handles the HTTP Basic Authentication process
    // There are plenty of refactoring opportunities;
    // we'll do that later after you learn the process

    public class OAuth2MessageHandler : DelegatingHandler
    {
        // Authentication header strings
        private const string Header = "WWW-Authenticate";
        private const string HeaderValue = "Bearer";

        // SendAsync method is in the System.Net.Http.MessageProcessingHandler class
        // It handles an HTTP request as an async operation
        // It returns a Task<T>, which is an object that represents the async operation

        protected override System.Threading.Tasks.Task<HttpResponseMessage>
            SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            // Fetch the request's authorization header
            AuthenticationHeaderValue authValue = request.Headers.Authorization;

            // If it has useful data, continue
            // authValue.Scheme is "Basic" in our example 
            // authValue.Parameter is a Base64-encoded string with credentials

            if (authValue != null && !String.IsNullOrWhiteSpace(authValue.Parameter))
            {
                // Decode the credentials:
                // HTTP Basic Authentication credentials are in the format...
                // username:password
                // ...and then Base64-encoded
                string urlAndToken = string.Format("{0}?token={1}",
                   "http://warp.senecac.on.ca:81/bti420_121a42/AuthServerTokenValidate.aspx",
                   authValue.Parameter);

                // Create an HttpClient request object
                HttpClient client = new HttpClient();
                // Send the request, and return the response as a string
                string tokenStatus = client.GetStringAsync(urlAndToken).Result;

                string contents = null;

                Encoding enc8 = Encoding.UTF8;

                byte[] binaryData;


                if (tokenStatus == "valid")
                {
                    binaryData = System.Convert.FromBase64String(authValue.Parameter);
                    contents = enc8.GetString(binaryData);
                    //contents = System.Text.Encoding.GetEncoding("Windows-1251").GetString(binaryData);

                    string[] split = contents.Split(new Char[] { '.' });
                    string[] myRoles = split[1].Split(new Char[] { ',' });


                    // We will decode them into a two-element string array
                    // string[] credentials =
                    //    System.Text.Encoding.ASCII.GetString
                    //    (Convert.FromBase64String(authValue.Parameter)).Split(new[] { ':' });

                    // Lookup user in the credential store
                    // RepoCredentials r = new RepoCredentials();
                    //var credential = r.GetCredentialByValues(credentials[0], credentials[1]);

                    // if (credential != null)
                    // {
                    // Successful match...
                    // Now, create a new generic user
                    // An identity object represents the user on whose behalf the code is running
                    var identity = new GenericIdentity("myusername");    //split[0]);  //(credential.Username);

                    // Next, set this request's current principal
                    // A principal object represents the security context of the user,
                    // on whose behalf the code is running
                    // It includes the user's identity object, and a string array
                    // of roles to which the user belongs

                    IPrincipal principal =
                        new GenericPrincipal(identity, myRoles);   //new[] { "Faculty" });   //
                    Thread.CurrentPrincipal = principal;
                    //}

                }
            }

            // Finally, after the code above has executed, return the result
            return base.SendAsync(request, cancellationToken).ContinueWith(task =>
            {
                // Create a response object
                var response = task.Result;
                // If the user was unable to authenticate, 
                // and authentication is required, add the appropriate header
                if (response.StatusCode == HttpStatusCode.Unauthorized
                    && !response.Headers.Contains(Header))
                {
                    response.Headers.Add(Header, HeaderValue);
                }

                return response;
            });

        }

    }

}
///////////////////////////////////////////////////////////////////
    /*
namespace ICTGWS.Handlers
{
    // This class handles a simple OAuth2 authorization process

    public class OAuth2MessageHandler : DelegatingHandler
    {
        // Authentication header strings
        private const string Header = "WWW-Authenticate";
        private const string HeaderValue = "Bearer";

        string contents = null;

        Encoding enc8 = Encoding.UTF8;

        byte[] binaryData;


        protected override System.Threading.Tasks.Task<HttpResponseMessage>
            SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            // Fetch the request's authorization header
            AuthenticationHeaderValue authValue = request.Headers.Authorization;

            // If it has useful data, continue
            // authValue.Scheme is "Bearer" in our example 
            // authValue.Parameter is a string token

            if (authValue != null && !String.IsNullOrWhiteSpace(authValue.Parameter))
            {
                // Validate the token

                // First, create a string to hold the token validator URL, and the token
                string urlAndToken = string.Format("{0}?token={1}",
                    "http://warp.senecac.on.ca:81/bti420_121a42/AuthServerTokenValidate.aspx",
                    authValue.Parameter);

                // Create an HttpClient request object
                HttpClient client = new HttpClient();
                // Send the request, and return the response as a string
                string tokenStatus = client.GetStringAsync(urlAndToken).Result;

                if (tokenStatus == "valid")
                {
                    Console.WriteLine("User belongs to the NetworkUser role.");

                    binaryData = System.Convert.FromBase64String(authValue.Parameter);
                    contents = enc8.GetString(binaryData);
                    //contents = System.Text.Encoding.GetEncoding("Windows-1251").GetString(binaryData);

                    string[] split = contents.Split(new Char[] { '.' });
                    string[] myRoles = split[1].Split(new Char[] { ',' });

                    // Successful match...
                    // Now, create a new generic user
                    // An identity object represents the user on whose behalf the code is running
                    var identity = new GenericIdentity(split[0]);   // ("WebApiUser");

 

                    // Next, set this request's current principal
                    // A principal object represents the security context of the user,
                    // on whose behalf the code is running
                    // It includes the user's identity object, and a string array
                    // of roles to which the user belongs

                    IPrincipal principal =
                        new GenericPrincipal(identity, new[] { "Public" });  //myRoles);    //
                    Thread.CurrentPrincipal = principal;
                }

            }

            // Finally, after the code above has executed, return the result
            return base.SendAsync(request, cancellationToken).ContinueWith(task =>
            {
                // Create a response object
                var response = task.Result;
                // If the user was unable to authenticate, 
                // and authentication is required, add the appropriate header
                if (response.StatusCode == HttpStatusCode.Unauthorized
                    && !response.Headers.Contains(Header))
                {
                    response.Headers.Add(Header, HeaderValue);
                }

                return response;
            });
        }

    }

}




namespace ICTGWS.Handlers
{
    // This class handles a simple OAuth2 authorization process

    public class OAuth2MessageHandler : DelegatingHandler
    {
        // Authentication header strings
        private const string Header = "WWW-Authenticate";
        private const string HeaderValue = "Bearer";

        protected override System.Threading.Tasks.Task<HttpResponseMessage>
            SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            // Fetch the request's authorization header
            AuthenticationHeaderValue authValue = request.Headers.Authorization;

            // If it has useful data, continue
            // authValue.Scheme is "Bearer" in our example 
            // authValue.Parameter is a string token

            if (authValue != null && !String.IsNullOrWhiteSpace(authValue.Parameter))
            {
                // Validate the token

                // First, create a string to hold the token validator URL, and the token
                //replace the format items in a specified string with the string representation of two specified objects
                string urlAndToken = string.Format("{0}?token={1}",
                    "http://warp.senecac.on.ca:81/bti420_121a42/AuthServerTokenValidate.aspx",
                    authValue.Parameter);

                // Create an HttpClient request object
                HttpClient client = new HttpClient();
                // Send the request, and return the response as a string
                string tokenStatus = client.GetStringAsync(urlAndToken).Result;

                string contents=null;

                Encoding enc8 = Encoding.UTF8;


                if (tokenStatus == "valid")
                {
                    Console.WriteLine("User belongs to the NetworkUser role.");

                    //string myToken_base64String = string.Format("?token={0}",
                          //    "http://warp.senecac.on.ca:81/bti420_121a42/AuthServerTokenValidate.aspx",
                           //   authValue.Parameter);

                    // Convert the Base64 UUEncoded input into binary output.
                    byte[] binaryData;
                    try
                    {
                        binaryData = System.Convert.FromBase64String(authValue.Parameter);
                        contents = enc8.GetString(binaryData);

                        string [] split = contents.Split(new Char [] {'.'});
                        string [] myRoles = split[1].Split(new Char [] {','});

                        // Retrieve the generic identity of the GenericPrincipal object.
                        //GenericIdentity principalIdentity =
                         //   (GenericIdentity)genericPrincipal.Identity;

                        var identity = new GenericIdentity(split[0]);   // ("WebApiUser");
                        //GenericIdentity currentIdentity = GetGenericIdentity();

                                // Retrieve a GenericPrincipal that is based on the current user's
        // WindowsIdentity.
                        GenericPrincipal genericPrincipal = new System.Security.Principal.GenericPrincipal(identity, myRoles);

                        //IPrincipal principal =
                       //new GenericPrincipal(identity, new[] { "Member" });
                        Thread.CurrentPrincipal = genericPrincipal;

/*
        // Display the identity name and authentication type.
        if (principalIdentity.IsAuthenticated)
        {
            Console.WriteLine(principalIdentity.Name);
            Console.WriteLine("Type:"+principalIdentity.AuthenticationType);
        }

        // Verify that the generic principal has been assigned the
        // NetworkUser role.
        if (genericPrincipal.IsInRole("Anonymous") || genericPrincipal.IsInRole("Public"))
        {
            Console.WriteLine("User belongs to the NetworkUser role.");


        }
                        

                    }
                    catch (System.ArgumentNullException)
                    {
                        System.Console.WriteLine("Base 64 string is null.");
                        return null;
                    }
                    catch (System.FormatException)
                    {
                        System.Console.WriteLine("Base 64 string length is not " +
                           "4 or is not an even multiple of 4.");
                        return null;
                    }

                    // Successful match...
                    // Now, create a new generic user
                    // An identity object represents the user on whose behalf the code is running
                        ////var identity1 = new GenericIdentity("mli101_stu");

                    // Next, set this request's current principal
                    // A principal object represents the security context of the user,
                    // on whose behalf the code is running
                    // It includes the user's identity object, and a string array
                    // of roles to which the user belongs

                    ////IPrincipal principal =
                      ////  new GenericPrincipal(identity1, new[] { "Student" });
                    ////Thread.CurrentPrincipal = principal;
                }//end of if token is valid

            }//end of if (authValue != null && !String.IsNullOrWhiteSpace(authValue.Parameter))

            // Finally, after the code above has executed, return the result
            return base.SendAsync(request, cancellationToken).ContinueWith(task =>
            {
                // Create a response object
                var response = task.Result;
                // If the user was unable to authenticate, 
                // and authentication is required, add the appropriate header
                if (response.StatusCode == HttpStatusCode.Unauthorized
                    && !response.Headers.Contains(Header))
                {
                    response.Headers.Add(Header, HeaderValue);
                }

                return response;
            });
        }

        // Create a generic principal based on values from the current
        // WindowsIdentity.
        private static GenericPrincipal GetGenericPrincipal()
        {
            // Use values from the current WindowsIdentity to construct
            // a set of GenericPrincipal roles.
            WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();
            string[] roles = new string[10];
            if (windowsIdentity.IsAuthenticated)
            {
                // Add custom NetworkUser role.
                //roles[0] = "NetworkUser";
                roles[0] = "NetworkUser";
            }

            if (windowsIdentity.IsGuest)
            {
                // Add custom GuestUser role.
                //roles[1] = "GuestUser";
                roles[1] = "Public";
            }

            if (windowsIdentity.IsSystem)
            {
                // Add custom SystemUser role.
                //roles[2] = "SystemUser";
                roles[2] = "SystemUser";
            }

            // Construct a GenericIdentity object based on the current Windows
            // identity name and authentication type.
            string authenticationType = windowsIdentity.AuthenticationType;
            string userName = windowsIdentity.Name;
            GenericIdentity genericIdentity =
                new GenericIdentity(userName, authenticationType);

            // Construct a GenericPrincipal object based on the generic identity
            // and custom roles for the user.
            GenericPrincipal genericPrincipal =
                new GenericPrincipal(genericIdentity, roles);

            return genericPrincipal;
        }

    }
}


*/